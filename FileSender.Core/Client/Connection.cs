using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Client
{
    public class Connection
    {
        private Socket ClientSocket { get; set; }
        private SslStream SSLStream { get; set; }
        private CancellationTokenSource ClientCTS { get; set; } = new CancellationTokenSource();
        public string RemoteIP { get; private set; }

        private byte[] Buffer = new byte[16384];
        private int HeaderSize = 4;
        private int BufferIndex = 0;
        private int BytesToReceive = 4;
        private bool ReceivingHeaderData = true;

        public async Task<bool> Connect(string ip, int port)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            RemoteIP = ip;
            try
            {
                await ClientSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port), ClientCTS.Token);
            }
            catch (Exception ex) { return false; }
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
        public async Task ReceiveData()
        {
            while (!ClientCTS.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, ClientCTS.Token);
                if(read > 0)
                {
                    BufferIndex += read;
                    BytesToReceive -= read;
                    if (BytesToReceive == 0)
                    {
                        if (ReceivingHeaderData)
                        {
                            int receiveBytes = BitConverter.ToInt32(Buffer, 0);
                            if (receiveBytes > 0)
                            {
                                BufferIndex = 0;
                                BytesToReceive = receiveBytes;
                            }
                            else
                            {
                                //Disconnect
                            }
                        }
                        else
                        {
                            //Receive data
                            Debug.WriteLine(UTF8Encoding.UTF8.GetString(Buffer));
                        }
                    }
                }
                else
                {
                    //Disconnect
                }
            }
        }
    }
}
