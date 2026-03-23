using FileSender.Core.Packets;
using FileSender.Core.Tools;
using FileSender.Core.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
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
        public Guid FullID { get; set; }

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
        public async Task HandleClient()
        {
            while (!ServerCT.IsCancellationRequested)
            {
                await ReceiveData();
            }
        }

        public async Task SendFile(FileData file)
        {
            using (FileStream fs = new FileStream(file.FileLocation, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (GZipStream gz = new GZipStream(SSLStream, CompressionMode.Compress, leaveOpen: true))
            {
                byte[] sendBuffer = new byte[16384];
                int bytesRead;

                while ((bytesRead = await fs.ReadAsync(sendBuffer, 0, sendBuffer.Length, ServerCT)) > 0)
                {
                    await gz.WriteAsync(sendBuffer, 0, bytesRead, ServerCT);
                }

                await gz.FlushAsync();
                gz.Close();
            }
        }
    }
}
