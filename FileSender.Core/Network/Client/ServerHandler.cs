using FileSender.Core.Client;

namespace FileSender.Core.Network.Client
{
    public class ServerHandler
    {
        private static ServerHandler _SH { get; set; } = new ServerHandler();
        public static ServerHandler SH
        {
            get { return _SH; } 
        }

        private List<Connection> Servers = new List<Connection>();
        public void AddServer(Connection conn)
        {
            Servers.Add(conn);
        }
    }
}
