using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Server
{
    public class Listener
    {
        public static Listener Server { get; private set; } = new Listener();

        private Socket ServerSocket { get; set; }
        private CancellationTokenSource ServerCTS { get; set; }
        public bool IsAwaitingReset { get; private set; } = true;


        public async Task StartServer(int port)
        {
            if (IsAwaitingReset)
            {
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerCTS = new CancellationTokenSource();
            }
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            ServerSocket.Listen(100);

            IsAwaitingReset = false;

            await Listen(ServerCTS.Token);
        }

        public async Task Stop()
        {
            await ServerCTS.CancelAsync();
            ServerSocket.Dispose();
            IsAwaitingReset = true;
        }

        private async Task Listen(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    Socket clientSocket = await ServerSocket.AcceptAsync(ct);

                    _ = new ClientNode(clientSocket);
                }
                catch (OperationCanceledException)
                {
                    //Don
                }
            }            
        }
    }
}
