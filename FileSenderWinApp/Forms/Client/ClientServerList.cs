using FileSender.Core.Client;
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
        public ClientServerList()
        {
            InitializeComponent();
        }

        private async void directConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientDirectConnect CDC = new ClientDirectConnect();
            if (CDC.ShowDialog() == DialogResult.OK)
            {
                FileSender.Core.Client.Connection con = new FileSender.Core.Client.Connection();
                bool connected = await con.Connect(CDC.IPPortTB.Text.Split(':')[0], int.Parse(CDC.IPPortTB.Text.Split(':')[1]));
                MessageBox.Show(connected.ToString());
                //await con.ReceiveData();
                if (connected)
                {
                    AddServer(con);                    
                }
            }
        }
        private void AddServer(Connection conn)
        {
            ListViewItem LVI = new ListViewItem(conn.RemoteIP);
            ClientServerListLV.Items.Add(LVI);
            FileSender.Core.Client.ServerHandler.SH.AddServer(conn);
        }
    }
}
