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
                ClientServerFileListLV.Items.Add(LVI);
            }
        }
    }
}
