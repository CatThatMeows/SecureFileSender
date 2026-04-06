using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Network.Client;
using FileSender.Core.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    while (!con.CTS.IsCancellationRequested)
                    {
                        await con.ReceiveData();
                    }
                }
            }
        }
        private async void AddServer(Connection conn)
        {
            bool result = await conn.SendCMD(new AuthPacket());
            if (result) {
                ListViewItem LVI = new ListViewItem(conn.RemoteIP);
                ClientServerListLV.Items.Add(LVI);
                LVI.Tag = conn;
                ServerHandler.SH.AddServer(conn);
            }
        }

        private async void openFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in ClientServerListLV.Items)
            {
                if (item.Selected)
                {
                    ((ClientServerFileList)FormHandler.ClientServerFileList).ClientServerFileListLV.Items.Clear();

                    await ((Connection)item.Tag).SendCMD(new FileListPacketRequest());
                    ((ClientServerFileList)FormHandler.ClientServerFileList).IP = ((Connection)item.Tag).RemoteIP;
                    ((ClientServerFileList)FormHandler.ClientServerFileList).Port = ((Connection)item.Tag).Port;

                    FormHandler.ClientServerFileList.Show();
                }
            }
        }
    }
}
