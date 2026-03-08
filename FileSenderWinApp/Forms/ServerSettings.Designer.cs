namespace FileSenderWinApp.Forms
{
    partial class ServerSettings
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
            PortLabel = new Label();
            CertificateLabel = new Label();
            PortTB = new TextBox();
            CertificateStatusLabel = new Label();
            CertificateImportBTN = new Button();
            CreateCertificateBTN = new Button();
            SuspendLayout();
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Location = new Point(244, 109);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(32, 15);
            PortLabel.TabIndex = 0;
            PortLabel.Text = "Port:";
            // 
            // CertificateLabel
            // 
            CertificateLabel.AutoSize = true;
            CertificateLabel.Location = new Point(215, 148);
            CertificateLabel.Name = "CertificateLabel";
            CertificateLabel.Size = new Size(61, 15);
            CertificateLabel.TabIndex = 1;
            CertificateLabel.Text = "Certificate";
            // 
            // PortTB
            // 
            PortTB.Location = new Point(299, 106);
            PortTB.MaxLength = 5;
            PortTB.Name = "PortTB";
            PortTB.Size = new Size(100, 23);
            PortTB.TabIndex = 2;
            PortTB.TextAlign = HorizontalAlignment.Right;
            PortTB.TextChanged += PortTB_TextChanged;
            // 
            // CertificateStatusLabel
            // 
            CertificateStatusLabel.AutoSize = true;
            CertificateStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CertificateStatusLabel.ForeColor = Color.Red;
            CertificateStatusLabel.Location = new Point(299, 148);
            CertificateStatusLabel.Name = "CertificateStatusLabel";
            CertificateStatusLabel.Size = new Size(132, 15);
            CertificateStatusLabel.TabIndex = 3;
            CertificateStatusLabel.Text = "CERTIFICATE INACTIVE";
            // 
            // CertificateImportBTN
            // 
            CertificateImportBTN.Location = new Point(521, 144);
            CertificateImportBTN.Name = "CertificateImportBTN";
            CertificateImportBTN.Size = new Size(75, 23);
            CertificateImportBTN.TabIndex = 4;
            CertificateImportBTN.Text = "Import";
            CertificateImportBTN.UseVisualStyleBackColor = true;
            CertificateImportBTN.Click += CertificateImportLabel_Click;
            // 
            // CreateCertificateBTN
            // 
            CreateCertificateBTN.Location = new Point(440, 144);
            CreateCertificateBTN.Name = "CreateCertificateBTN";
            CreateCertificateBTN.Size = new Size(75, 23);
            CreateCertificateBTN.TabIndex = 5;
            CreateCertificateBTN.Text = "Create";
            CreateCertificateBTN.UseVisualStyleBackColor = true;
            CreateCertificateBTN.Click += CreateCertificateBTN_Click;
            // 
            // ServerSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 435);
            Controls.Add(CreateCertificateBTN);
            Controls.Add(CertificateImportBTN);
            Controls.Add(CertificateStatusLabel);
            Controls.Add(PortTB);
            Controls.Add(CertificateLabel);
            Controls.Add(PortLabel);
            Name = "ServerSettings";
            Text = "ServerSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PortLabel;
        private Label CertificateLabel;
        private TextBox PortTB;
        private Label CertificateStatusLabel;
        private Button CertificateImportBTN;
        private Button CreateCertificateBTN;
    }
}