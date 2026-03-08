using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Server
{
    public class ClientNode
    {
        private Socket ClientSocket {  get; set; }
        private SslStream SSLStream { get; set; }
        public ClientNode(Socket clientSocket)
        {
            ClientSocket = clientSocket;
            SSLStream = new SslStream(new NetworkStream(ClientSocket, true), false);
        }
    }
}
