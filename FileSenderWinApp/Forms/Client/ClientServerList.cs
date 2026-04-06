using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Network.Client;
using FileSender.Core.Packets;

namespace FileSenderWinApp.Forms.Client
{
    public partial class ClientServerList : Form
    {
        private readonly PacketHandler packetHandler = new Network.ClientPacketHandler();
        public ClientServerList()
        {
            InitializeComponent();
        }

        private async void directConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientDirectConnect CDC = new ClientDirectConnect();
            if (CDC.ShowDialog() == DialogResult.OK)
            {
                string ipport = CDC.IPPortTB.Text;
                if (string.IsNullOrWhiteSpace(ipport) || ipport.Count(x => x == '.') != 3 || !ipport.Contains(':'))
                {
                    MessageBox.Show("Wrong input");
                    return;
                }
                Connection con = new FileSender.Core.Client.Connection();
                bool connected = await con.Connect(CDC.IPPortTB.Text.Split(':')[0], int.Parse(CDC.IPPortTB.Text.Split(':')[1]), packetHandler);
                if (connected)
                {
                    AddServer(con);
                    _ = con.ReceiveData();
                }
            }
        }
        private async void AddServer(Connection conn)
        {
            bool result = await conn.SendCMD(new AuthPacket());
            if (result)
            {
                ListViewItem LVI = new ListViewItem(conn.RemoteIP);
                ClientServerListLV.Items.Add(LVI);
                LVI.Tag = conn;
                ServerHandler.SH.AddServer(conn);
            }
        }

        private async void openFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ClientServerListLV.SelectedItems)
            {
                ((ClientServerFileList)FormHandler.ClientServerFileList).ClientServerFileListLV.Items.Clear();

                await ((Connection)item.Tag).SendCMD(new FileListPacketRequest());
                ((ClientServerFileList)FormHandler.ClientServerFileList).IP = ((Connection)item.Tag).RemoteIP;
                ((ClientServerFileList)FormHandler.ClientServerFileList).Port = ((Connection)item.Tag).Port;

                FormHandler.ClientServerFileList.Show();
            }
        }

        private async void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem LVI in ClientServerListLV.SelectedItems)
            {
                await ((Connection)LVI.Tag).Disconnect();
                LVI.Remove();
            }
        }
    }
}
