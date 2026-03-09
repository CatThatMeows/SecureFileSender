using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Server
{
    public class ClientNode
    {
        private Socket ClientSocket {  get; set; }
        private SslStream SSLStream { get; set; }
        private CancellationToken ServerCT { get; set; }

        private byte[] Buffer = new byte[16384];
        private int HeaderSize = 4;
        private int BufferIndex = 0;
        private int BytesToReceive = 4;
        private bool ReceivingHeaderData = true;
        public async Task<ClientNode> CreateNode(Socket clientSocket, CancellationToken serverCT)
        {
            ClientSocket = clientSocket;
            SSLStream = new SslStream(new NetworkStream(ClientSocket, true), false);
            ServerCT = serverCT;
            await SSLStream.AuthenticateAsServerAsync(CoreSettings.CS.ServerCertificate, false, SslProtocols.Tls12, false );

            return this;
        }
        public async Task ReceiveData()
        {
            while (!ServerCT.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, ServerCT);
                if (read > 0)
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
