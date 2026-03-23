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
            this.FormClosing += HideForm;
            SelectFileDownloadMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ClientServerFileListLV
            // 
            ClientServerFileListLV.Columns.AddRange(new ColumnHeader[] { FileNameCol, SizeCol });
            ClientServerFileListLV.ContextMenuStrip = SelectFileDownloadMenuStrip;
            ClientServerFileListLV.Dock = DockStyle.Fill;
            ClientServerFileListLV.Location = new Point(0, 0);
            ClientServerFileListLV.Name = "ClientServerFileListLV";
            ClientServerFileListLV.Size = new Size(800, 450);
            ClientServerFileListLV.TabIndex = 0;
            ClientServerFileListLV.UseCompatibleStateImageBehavior = false;
            ClientServerFileListLV.View = View.Details;
            // 
            // FileNameCol
            // 
            FileNameCol.Text = "Filename";
            FileNameCol.Width = 200;
            // 
            // SizeCol
            // 
            SizeCol.Text = "Size";
            SizeCol.TextAlign = HorizontalAlignment.Center;
            SizeCol.Width = 150;
            // 
            // SelectFileDownloadMenuStrip
            // 
            SelectFileDownloadMenuStrip.Items.AddRange(new ToolStripItem[] { downloadToolStripMenuItem });
            SelectFileDownloadMenuStrip.Name = "SelectFileDownloadMenuStrip";
            SelectFileDownloadMenuStrip.Size = new Size(129, 26);
            // 
            // downloadToolStripMenuItem
            // 
            downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            downloadToolStripMenuItem.Size = new Size(128, 22);
            downloadToolStripMenuItem.Text = "Download";
            downloadToolStripMenuItem.Click += downloadToolStripMenuItem_Click;
            // 
            // ClientServerFileList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ClientServerFileListLV);
            Name = "ClientServerFileList";
            Text = "ClientServerFileList";
            SelectFileDownloadMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ColumnHeader FileNameCol;
        private ColumnHeader SizeCol;
        private ContextMenuStrip SelectFileDownloadMenuStrip;
        private ToolStripMenuItem downloadToolStripMenuItem;
        public ListView ClientServerFileListLV;
    }
}