using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Client
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
