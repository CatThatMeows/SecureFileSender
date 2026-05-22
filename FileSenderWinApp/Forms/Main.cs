using FileSender.Core;
using FileSender.Core.Network;
using FileSender.Core.Network.Client;
using FileSender.Core.Network.Server;
using FileSender.Core.UI;
using FileSenderWinApp.Forms.Client;
using FileSenderWinApp.Forms.Server;
using System.Net;

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

        private async void Main_Load(object sender, EventArgs e)
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

            ((ServerSettings)FormHandler.ServerSettings).networkDiscovery.Checked = CoreSettings.CS.IsDiscoveryEnabled;
            if (CoreSettings.CS.IsDiscoveryEnabled)
            {
                Discover dc = new Discover();
                List<IPAddress> ips = await dc.ConnectDummmy();

                for(int i = 0; i <  ips.Count; i++)
                    ((ClientServerList)FormHandler.ClientServerList).Connect(ips[i].ToString(), CoreSettings.CS.Port);
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
