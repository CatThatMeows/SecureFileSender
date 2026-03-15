using FileSender.Core.Packets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Network.Server
{
    public class Listener
    {
        public static Listener Server { get; private set; } = new Listener();
        private Socket ServerSocket { get; set; }
        private CancellationTokenSource ServerCTS { get; set; }
        public bool IsAwaitingReset { get; private set; } = true;


        public async Task StartServer(int port, PacketHandler packetHandler)
        {
            if (IsAwaitingReset)
            {
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerCTS = new CancellationTokenSource();
            }
            ServerSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            ServerSocket.Listen(100);

            IsAwaitingReset = false;

            await Listen(ServerCTS.Token, packetHandler);
        }

        public async Task Stop()
        {
            await ServerCTS.CancelAsync();
            ServerSocket.Dispose();
            IsAwaitingReset = true;
        }

        private async Task Listen(CancellationToken ct, PacketHandler packetHandler)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    Socket clientSocket = await ServerSocket.AcceptAsync(ct);

                    ClientNode node = new ClientNode();
                    node = await node.CreateNode(clientSocket, packetHandler, ct);

                    if(node != null)
                    {
                        ClientList.CL.AddClient(node);
                    }

                     _ = node.HandleClient();                    
                }
                catch (OperationCanceledException)
                {
                    //Don
                }
            }            
        }
    }
}
