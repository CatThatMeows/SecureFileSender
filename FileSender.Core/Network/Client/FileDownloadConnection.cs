using FileSender.Core.UI;
using Org.BouncyCastle.Asn1.X509;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;

namespace FileSender.Core.Network.Client
{
    public class FileDownloadConnection : NetworkCore
    {
        private FileData File { get; set; }
        private FileStream FS { get; set; }
        private const int ChunkSize = 16384;
        public CancellationTokenSource ClientCTS { get; set; } = new CancellationTokenSource();
        public FileDownloadConnection(FileData file)
        {
            CTS = ClientCTS;
            File = file;
            IsServer = false;
            BytesToReceiveFull = File.FileSize;
            if(file.FileSize < ChunkSize)
            {
                BytesToReceiveFull = file.FileSize;
            }
            base.Buffer = new byte[ChunkSize];
        }

        public async Task<bool> Connect(string ip, int port, PacketHandler packetHandler)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                ReceiveBufferSize = ChunkSize,
                SendBufferSize = ChunkSize
            };
            IsServer = false;
            this.PacketHandler = packetHandler;
            try
            {
                await ClientSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port), ClientCTS.Token);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
            if (ClientSocket.Connected)
            {
                string folder = ClientSocket.RemoteEndPoint.ToString().Split(':')[0];
                if (!Directory.Exists(folder)) 
                    Directory.CreateDirectory(folder); 
                FS = new FileStream(folder + "\\" + File.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
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
            try
            {
                long bytesWritten = 0;
                using (GZipStream gzip = new GZipStream(SSLStream, CompressionMode.Decompress, leaveOpen: true))
                {
                    int read;
                    while ((read = await gzip.ReadAsync(Buffer, 0, ChunkSize, CTS.Token)) > 0 && !CTS.IsCancellationRequested)
                    {
                        bytesWritten += read;
                        if (read > 0)
                        {
                            await FS.WriteAsync(Buffer, 0, read, CTS.Token);
                        }
                        else
                        {
                            break;
                        }

                        if (BytesToReceiveFull == bytesWritten)
                            break;
                    }
                    await SSLStream.FlushAsync();
                }
            }
            catch { } //Errors handled below anyway

            FS.Close();
            string folder = ClientSocket.RemoteEndPoint.ToString().Split(':')[0];
            FileInfo info = new FileInfo(folder + "\\" + File.FileName);
            if(info.Exists && info.Length != File.FileSize)
            {
                //ToDo: display error back to GUI
                System.IO.File.Delete(folder + "\\" + File.FileName);
            }
            ClientCTS.Cancel();
        }
    }
}
