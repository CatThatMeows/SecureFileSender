using FileSender.Core.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSenderWinApp.Forms.Server
{
    public partial class ServerFileList : Form
    {
        public ServerFileList()
        {
            InitializeComponent();

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog()) {
                opf.Multiselect = true;
                
                if(opf.ShowDialog() == DialogResult.OK)
                {
                    foreach(string file in opf.FileNames)
                    {
                        FileInfo info = new FileInfo(file);
                        FileData data = new FileData()
                        {
                            FileSize = info.Length,
                            FileLocation = info.FullName,
                            FileName = info.Name,
                            ID = Guid.NewGuid()
                        };

                        FileData.AddToServerFiles(data);
                        AddToList(data);
                    }
                }
            }
        }
        public void AddFromList()
        {
            foreach(FileData data in FileData.ServerFiles)
            {
                AddToList(data);
            }
        }

        private void AddToList(FileData data)
        {
            ListViewItem item = new ListViewItem(data.FileName);
            item.SubItems.Add((data.FileSize / 1024).ToString() + "kb");
            item.SubItems.Add(data.FileLocation);

            ServerFileListLV.Items.Add(item);
        }
    }
}
