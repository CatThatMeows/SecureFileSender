namespace FileSenderWinApp.Forms.Server
{
    partial class ServerFileList
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
            ServerFileListCMS = new ContextMenuStrip(components);
            addToolStripMenuItem = new ToolStripMenuItem();
            setPasswordForFilesToolStripMenuItem = new ToolStripMenuItem();
            ServerFileListLV = new ListView();
            FileNameCol = new ColumnHeader();
            FileSizeCol = new ColumnHeader();
            FileLocationCol = new ColumnHeader();
            removeToolStripMenuItem = new ToolStripMenuItem();
            ServerFileListCMS.SuspendLayout();
            SuspendLayout();
            // 
            // ServerFileListCMS
            // 
            ServerFileListCMS.ImageScalingSize = new Size(20, 20);
            ServerFileListCMS.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, removeToolStripMenuItem, setPasswordForFilesToolStripMenuItem });
            ServerFileListCMS.Name = "contextMenuStrip1";
            ServerFileListCMS.Size = new Size(231, 104);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(230, 24);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // setPasswordForFilesToolStripMenuItem
            // 
            setPasswordForFilesToolStripMenuItem.Name = "setPasswordForFilesToolStripMenuItem";
            setPasswordForFilesToolStripMenuItem.Size = new Size(230, 24);
            setPasswordForFilesToolStripMenuItem.Text = "Set password for file(s)";
            setPasswordForFilesToolStripMenuItem.Click += setPasswordForFilesToolStripMenuItem_Click;
            // 
            // ServerFileListLV
            // 
            ServerFileListLV.Columns.AddRange(new ColumnHeader[] { FileNameCol, FileSizeCol, FileLocationCol });
            ServerFileListLV.ContextMenuStrip = ServerFileListCMS;
            ServerFileListLV.Dock = DockStyle.Fill;
            ServerFileListLV.Location = new Point(0, 0);
            ServerFileListLV.Margin = new Padding(3, 4, 3, 4);
            ServerFileListLV.Name = "ServerFileListLV";
            ServerFileListLV.Size = new Size(914, 600);
            ServerFileListLV.TabIndex = 1;
            ServerFileListLV.UseCompatibleStateImageBehavior = false;
            ServerFileListLV.View = View.Details;
            // 
            // FileNameCol
            // 
            FileNameCol.Text = "Filename";
            FileNameCol.Width = 125;
            // 
            // FileSizeCol
            // 
            FileSizeCol.Text = "Size";
            FileSizeCol.TextAlign = HorizontalAlignment.Center;
            FileSizeCol.Width = 100;
            // 
            // FileLocationCol
            // 
            FileLocationCol.Text = "Location";
            FileLocationCol.TextAlign = HorizontalAlignment.Center;
            FileLocationCol.Width = 600;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(230, 24);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // ServerFileList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(ServerFileListLV);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ServerFileList";
            Text = "ServerFileList";
            ServerFileListCMS.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip ServerFileListCMS;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem aToolStripMenuItem;
        public ListView ServerFileListLV;
        private ColumnHeader FileNameCol;
        private ColumnHeader FileSizeCol;
        private ColumnHeader FileLocationCol;
        private ToolStripMenuItem setPasswordForFilesToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
    }
}