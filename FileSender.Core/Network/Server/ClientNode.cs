using FileSender.Core.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Network.Server
{
    public class ClientNode : NetworkCore
    {
        private CancellationToken ServerCT { get; set; }
        public string IP { get; set; }
        public string FullID { get; set; }

        public async Task<ClientNode> CreateNode(Socket clientSocket, PacketHandler packetHandler ,CancellationToken serverCT)
        {
            ClientSocket = clientSocket;
            IsServer = true;
            ServerCT = serverCT;
            CT = ServerCT;
            IP = clientSocket.RemoteEndPoint.ToString();
            this.PacketHandler = packetHandler;

            try
            {
                SSLStream = new SslStream(new NetworkStream(ClientSocket, true), false);
                await SSLStream.AuthenticateAsServerAsync(CoreSettings.CS.ServerCertificate, false, SslProtocols.Tls12, false);
            }
            catch (Exception ex)
            {
                return null;
            }

            return this;
        }

        public void Send(Packet packet)
        {
            //Test
            byte[] b = packet.Serialize();
            SSLStream.Write(BitConverter.GetBytes(packet.Size));
            Debug.WriteLine(b.Length);
            byte[] a = new byte[1];
            a[0] = (byte)packet.PacketType;
            SSLStream.Write(a);
            SSLStream.Write(b);
        }
        public async Task HandleClient()
        {
            while (!ServerCT.IsCancellationRequested)
            {
                await ReceiveData();
            }
        }
    }
}
