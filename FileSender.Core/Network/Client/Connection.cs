using FileSender.Core.Network;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;

namespace FileSender.Core.Client
{
    public class Connection : NetworkCore
    {
        public string RemoteIP { get; private set; }
        public int Port { get; private set; }
        private CancellationTokenSource _CTS { get; set; } = new CancellationTokenSource();

        public async Task<bool> Connect(string ip, int port, PacketHandler packetHandler)
        {
            base.CTS = _CTS;
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            RemoteIP = ip;
            Port = port;
            IsServer = false;
            this.PacketHandler = packetHandler;
            try
            {
                await ClientSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port), CTS.Token);
            }
            catch (Exception ex) { 
                                    await CTS.CancelAsync(); 
                                    return false; 
                                 }
            if (ClientSocket.Connected)
            {
                SSLStream = new SslStream(new NetworkStream(ClientSocket, true), false,
                            userCertificateValidationCallback: (sender, certificate, chain, errors) =>
                            {
                                return true;
                            });
                try
                {
                    await SSLStream.AuthenticateAsClientAsync(ClientSocket.RemoteEndPoint.ToString().Split(':')[0], null, SslProtocols.Tls12, false);
                }
                catch (Exception ex) { Debug.WriteLine(ex); return false; }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
