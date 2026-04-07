namespace FileSenderWinApp.Forms.Client
{
    partial class ClientServerFileList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ClientServerFileListLV = new ListView();
            FileNameCol = new ColumnHeader();
            SizeCol = new ColumnHeader();
            SelectFileDownloadMenuStrip = new ContextMenuStrip(components);
            downloadToolStripMenuItem = new ToolStripMenuItem();
            PasswordedCol = new ColumnHeader();
            SelectFileDownloadMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ClientServerFileListLV
            // 
            ClientServerFileListLV.Columns.AddRange(new ColumnHeader[] { FileNameCol, SizeCol, PasswordedCol });
            ClientServerFileListLV.ContextMenuStrip = SelectFileDownloadMenuStrip;
            ClientServerFileListLV.Dock = DockStyle.Fill;
            ClientServerFileListLV.Location = new Point(0, 0);
            ClientServerFileListLV.Margin = new Padding(3, 4, 3, 4);
            ClientServerFileListLV.Name = "ClientServerFileListLV";
            ClientServerFileListLV.Size = new Size(914, 600);
            ClientServerFileListLV.TabIndex = 0;
            ClientServerFileListLV.UseCompatibleStateImageBehavior = false;
            ClientServerFileListLV.View = View.Details;
            // 
            // FileNameCol
            // 
            FileNameCol.Text = "Filename";
            FileNameCol.Width = 120;
            // 
            // SizeCol
            // 
            SizeCol.Text = "Size";
            SizeCol.TextAlign = HorizontalAlignment.Center;
            SizeCol.Width = 150;
            // 
            // SelectFileDownloadMenuStrip
            // 
            SelectFileDownloadMenuStrip.ImageScalingSize = new Size(20, 20);
            SelectFileDownloadMenuStrip.Items.AddRange(new ToolStripItem[] { downloadToolStripMenuItem });
            SelectFileDownloadMenuStrip.Name = "SelectFileDownloadMenuStrip";
            SelectFileDownloadMenuStrip.Size = new Size(148, 28);
            // 
            // downloadToolStripMenuItem
            // 
            downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            downloadToolStripMenuItem.Size = new Size(147, 24);
            downloadToolStripMenuItem.Text = "Download";
            downloadToolStripMenuItem.Click += downloadToolStripMenuItem_Click;
            // 
            // PasswordedCol
            // 
            PasswordedCol.Text = "Passworded";
            PasswordedCol.Width = 120;
            // 
            // ClientServerFileList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(ClientServerFileListLV);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ClientServerFileList";
            Text = "ClientServerFileList";
            FormClosing += HideForm;
            SelectFileDownloadMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ColumnHeader FileNameCol;
        private ColumnHeader SizeCol;
        private ContextMenuStrip SelectFileDownloadMenuStrip;
        private ToolStripMenuItem downloadToolStripMenuItem;
        public ListView ClientServerFileListLV;
        private ColumnHeader PasswordedCol;
    }
}