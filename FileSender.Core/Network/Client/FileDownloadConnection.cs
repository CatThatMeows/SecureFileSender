using FileSender.Core.Client;
using FileSender.Core.Packets;
using FileSender.Core.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;

namespace FileSender.Core.Network.Client
{
    public class FileDownloadConnection : NetworkCore
    {
        private FileData File { get; set; }
        private FileStream FS { get; set; } = new FileStream(@"C:\Users\MeowingCat\Desktop\test.p12", FileMode.Create, FileAccess.Write, FileShare.None);
        private int ChunkSize = 32768;
        public CancellationTokenSource ClientCTS { get; set; } = new CancellationTokenSource();
        public FileDownloadConnection(FileData file)
        {
            File = file;
            IsServer = false;
            BytesToReceiveFull = File.FileSize;
            BytesToReceive = ChunkSize;
            if(file.FileSize < 32768)
            {
                BytesToReceive = (int)file.FileSize;
                BytesToReceiveFull = file.FileSize;
            }
            base.Buffer = new byte[32768];
        }

        public async Task<bool> Connect(string ip, int port, PacketHandler packetHandler)
        {
            this.CT = ClientCTS.Token;
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsServer = false;
            this.PacketHandler = packetHandler;
            try
            {
                await ClientSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port), ClientCTS.Token);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
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
            while (!CT.IsCancellationRequested)
            {
                int read = await SSLStream.ReadAsync(Buffer, BufferIndex, BytesToReceive, CT);
                Debug.WriteLine("Read: " + read);
                if (read > 0)
                {
                    BufferIndex += read;
                    BytesToReceiveFull -= read;
                    BytesToReceive -= read;
                    Debug.WriteLine(BytesToReceiveFull);
                    if(BytesToReceive == 0)
                    {
                        //Write Chunk to File
                        FS.Write(Buffer, 0, read);
                        Debug.WriteLine("FileWrite");
                        if(BytesToReceiveFull > 32768)
                        {
                            BytesToReceive = 32768;
                        }
                        else
                        {
                            BytesToReceive = (int)BytesToReceiveFull;
                        }
                    }
                    if(BytesToReceiveFull == 0)
                    {
                        FS.Close();
                        ClientCTS.Cancel();
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
