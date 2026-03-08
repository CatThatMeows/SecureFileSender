namespace FileSenderWinApp.Forms
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
            ServerFileListLV = new ListView();
            FileNameCol = new ColumnHeader();
            FileSizeCol = new ColumnHeader();
            FileLocationCol = new ColumnHeader();
            ServerFileListCMS.SuspendLayout();
            SuspendLayout();
            // 
            // ServerFileListCMS
            // 
            ServerFileListCMS.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem });
            ServerFileListCMS.Name = "contextMenuStrip1";
            ServerFileListCMS.Size = new Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(96, 22);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // ServerFileListLV
            // 
            ServerFileListLV.Columns.AddRange(new ColumnHeader[] { FileNameCol, FileSizeCol, FileLocationCol });
            ServerFileListLV.ContextMenuStrip = ServerFileListCMS;
            ServerFileListLV.Dock = DockStyle.Fill;
            ServerFileListLV.Location = new Point(0, 0);
            ServerFileListLV.Name = "ServerFileListLV";
            ServerFileListLV.Size = new Size(800, 450);
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
            // ServerFileList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ServerFileListLV);
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
    }
}