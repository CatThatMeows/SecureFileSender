namespace FileSenderWinApp.Forms.Client
{
    partial class ClientServerList
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
            ClientServerListLV = new ListView();
            IPColumnHeader = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            directConnectToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ClientServerListLV
            // 
            ClientServerListLV.Columns.AddRange(new ColumnHeader[] { IPColumnHeader });
            ClientServerListLV.Dock = DockStyle.Fill;
            ClientServerListLV.Location = new Point(0, 24);
            ClientServerListLV.Name = "ClientServerListLV";
            ClientServerListLV.Size = new Size(800, 426);
            ClientServerListLV.TabIndex = 0;
            ClientServerListLV.UseCompatibleStateImageBehavior = false;
            ClientServerListLV.View = View.Details;
            // 
            // IPColumnHeader
            // 
            IPColumnHeader.Text = "IP";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { directConnectToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // directConnectToolStripMenuItem
            // 
            directConnectToolStripMenuItem.Name = "directConnectToolStripMenuItem";
            directConnectToolStripMenuItem.Size = new Size(96, 20);
            directConnectToolStripMenuItem.Text = "Direct connect";
            directConnectToolStripMenuItem.Click += directConnectToolStripMenuItem_Click;
            // 
            // ClientServerList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ClientServerListLV);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ClientServerList";
            Text = "ClientServerList";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem directConnectToolStripMenuItem;
        private ColumnHeader IPColumnHeader;
        public ListView ClientServerListLV;
    }
}