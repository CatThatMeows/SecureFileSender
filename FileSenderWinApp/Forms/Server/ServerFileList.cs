using FileSender.Core.UI;

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
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.Multiselect = true;

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in opf.FileNames)
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
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem LVI in ServerFileListLV.SelectedItems)
            {
                FileData.RemoveFromServerFiles((FileData)LVI.Tag);
                LVI.Remove();
            }
        }

        public void AddFromList()
        {
            foreach (FileData data in FileData.ServerFiles)
            {
                AddToList(data);
            }
        }

        private void AddToList(FileData data)
        {
            ListViewItem item = new ListViewItem(data.FileName);
            item.SubItems.Add((data.FileSize / 1024).ToString() + "kb");
            item.SubItems.Add(data.FileLocation);
            item.Tag = data;

            ServerFileListLV.Items.Add(item);
        }

        private void setPasswordForFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordInput PIF = new PasswordInput("Input a password to set for the selected file(s)", true);
            if (PIF.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem item in ServerFileListLV.SelectedItems)
                {
                    if (PIF.PasswordInputFormTB.Text == PIF.PasswordConfirmInputFormTB.Text)
                    {
                        ((FileData)item.Tag).SetPassword(PIF.PasswordInputFormTB.Text);
                        FileData.WriteToFile();
                    }
                }
            }
        }
    }
}
