using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Client
{
    internal class Connection
    {
        private Socket ClientSocket { get; set; }
        private SslStream SSLStream { get; set; }
        private CancellationTokenSource ClientCTS { get; set; } = new CancellationTokenSource();

        public async Task Connect(string ip, int port)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await ClientSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port), ClientCTS.Token);

            SSLStream = new SslStream(new NetworkStream(ClientSocket, true), false);
            await SSLStream.AuthenticateAsClientAsync(ClientSocket.RemoteEndPoint.ToString().Split(':')[0], null, SslProtocols.Tls13, false);


        }
    }
}
