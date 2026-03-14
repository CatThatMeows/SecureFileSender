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
            ClientServerFileListLV = new ListView();
            FileNameCol = new ColumnHeader();
            SizeCol = new ColumnHeader();
            SuspendLayout();
            // 
            // ClientServerFileListLV
            // 
            ClientServerFileListLV.Columns.AddRange(new ColumnHeader[] { FileNameCol, SizeCol });
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
            // ClientServerFileList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ClientServerFileListLV);
            Name = "ClientServerFileList";
            Text = "ClientServerFileList";
            ResumeLayout(false);
        }

        #endregion

        private ListView ClientServerFileListLV;
        private ColumnHeader FileNameCol;
        private ColumnHeader SizeCol;
    }
}