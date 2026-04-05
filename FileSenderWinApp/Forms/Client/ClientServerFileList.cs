using FileSender.Core.Client;
using FileSender.Core.Network.Client;
using FileSender.Core.Packets;
using FileSender.Core.UI;
using Org.BouncyCastle.Ocsp;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace FileSenderWinApp.Forms.Client
{
    public partial class ClientServerFileList : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IP { get; set; } = String.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Port { get; set; } = 0;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Hidden { get; set; } = false;

        public ClientServerFileList()
        {
            InitializeComponent();
        }

        public void AddFiles(in List<FileData> Files)
        {
            foreach (FileData file in Files)
            {
                ListViewItem LVI = new ListViewItem(file.FileName);
                LVI.SubItems.Add(file.FileSize.ToString());
                LVI.SubItems.Add(file.IsPassworded ? "true" : "false");
                LVI.Tag = file;
                ClientServerFileListLV.Items.Add(LVI);
            }
        }

        private async void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in ClientServerFileListLV.Items)
            {
                string password = String.Empty;
                if (item.Selected)
                {
                    FileDownloadRequest FDR = new FileDownloadRequest(((FileData)item.Tag).ID);
                    if (((FileData)item.Tag).IsPassworded)
                    {
                        PasswordInput PIF = new PasswordInput("This file is passworded. Input the password", false);
                        if(PIF.ShowDialog() == DialogResult.OK)
                        {
                            byte[] passHash = SHA512.HashData(Encoding.UTF8.GetBytes(PIF.PasswordInputFormTB.Text));
                            string passString = Convert.ToHexString(passHash);
                            FDR.ReqPasswordHash = passString;
                        }
                    }
                    FileDownloadConnection fdc = new FileDownloadConnection((FileData)item.Tag);
                    bool connected = await fdc.Connect(IP, Port, null);
                    if (connected)
                    {
                        await fdc.SendCMD(FDR);
                        while (!fdc.ClientCTS.IsCancellationRequested)
                        {
                            await fdc.ReceiveData();
                        }
                    }
                }
            }
        }
        private void HideForm(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                this.Hidden = true;
            }
        }
    }
}
