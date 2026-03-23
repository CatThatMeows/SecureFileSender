using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Network.Client;
using FileSender.Core.Network.Server;
using FileSender.Core.Packets;
using FileSender.Core.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
                LVI.Tag = file;
                ClientServerFileListLV.Items.Add(LVI);
            }
        }

        private async void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in ClientServerFileListLV.Items)
            {
                if (item.Selected)
                {
                    FileDownloadConnection fdc = new FileDownloadConnection((FileData)item.Tag);
                    bool connected = await fdc.Connect(IP, Port, null);
                    if (connected)
                    {
                        await fdc.SendCMD(new FileDownloadRequest(((FileData)item.Tag).ID));
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
