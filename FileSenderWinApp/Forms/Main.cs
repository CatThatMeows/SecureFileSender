using FileSender.Core;
using FileSender.Core.Network;
using FileSender.Core.Network.Server;
using FileSender.Core.UI;
using FileSenderWinApp.Forms.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSenderWinApp.Forms
{
    public partial class Main : Form
    {
        private readonly PacketHandler packetHandler = new Network.ServerPacketHandler(); 
        public Main()
        {
            InitializeComponent();
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.LoadForm(FormHandler.ServerFileList);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.LoadForm(FormHandler.ServerSettings);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CoreSettings.CS.CoreInit();
            FileData.InitLists();
            if (CoreSettings.CS.Port != -1)
            {
                ((ServerSettings)FormHandler.ServerSettings).SetPort(CoreSettings.CS.Port.ToString());
            }
            if (FileData.ServerFiles.Count > 0)
            {
                ((ServerFileList)FormHandler.ServerFileList).AddFromList();
            }
        }

        private async void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CoreSettings.CS.ServerCertificate != null)
            {
                if (Listener.Server.IsAwaitingReset)
                    await Listener.Server.StartServer(CoreSettings.CS.Port, packetHandler);
                else
                    MessageBox.Show("Server is already running");
            }
            else
            {
                MessageBox.Show("Import/Create a certificate before starting the server");
            }
        }

        private async void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Listener.Server.IsAwaitingReset)
                await Listener.Server.Stop();
            else
                MessageBox.Show("Server isn't running");
        }

        private void serverlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.LoadForm(FormHandler.ClientServerList);
        }
    }
}
