using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace FileSender.Core.Network.Client
{
    public class Discover
    {
        private static object SyncObject = new object();
        public async Task<List<IPAddress>> ConnectDummmy() //Basically port scan, cry about it
        {
            List<IPAddress> probablyOpen = new List<IPAddress>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus != OperationalStatus.Up)
                    continue;
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                IPInterfaceProperties ipProps = ni.GetIPProperties();
                foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                {
                    
                    if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        byte[] ip = addr.Address.GetAddressBytes();
                        List<IPAddress> ips = new List<IPAddress>();
                        //Just try the /24, if you use something else thats sad, u can still direct connect.
                        for(byte i = 0; i < 255; i++)
                        {
                            ip[3] = i;
                            ips.Add(new IPAddress(ip));
                        }
                        await Parallel.ForEachAsync(ips, new ParallelOptions { MaxDegreeOfParallelism = 3 }, 
                            async (ip, ct) => 
                            { 
                                bool result = await TryConnect(ip.ToString(), CoreSettings.CS.Port);
                                if (result)
                                {
                                    lock (SyncObject)
                                    {
                                        probablyOpen.Add(ip);
                                    }
                                }
                            });
                    }
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return probablyOpen;
        }

        private async Task<bool> TryConnect(string ip, int port)
        {
            Socket dummySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            CancellationTokenSource CTS = new CancellationTokenSource();
            Task result = TryValid(dummySocket, ip, port, CTS.Token);
            Task timeout = Task.Delay(400);

            if (await Task.WhenAny(result, timeout) == timeout)
            {
                try
                {
                    await CTS.CancelAsync();
                    await dummySocket.DisconnectAsync(false);
                    CTS.Dispose();
                }catch { } //Doesnt matter
                return false;
            }

            return true;
        }
        
        private async Task<bool> TryValid(Socket dummySocket, string ip, int port, CancellationToken CT)
        {
            await dummySocket.ConnectAsync(ip, port, CT);
            return dummySocket.Connected;
        }
    }
}
