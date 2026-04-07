namespace FileSenderWinApp.Forms.Client
{
    partial class ClientDirectConnect
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
            ConnectBTN = new Button();
            CancelConnectBTN = new Button();
            IPPortTB = new TextBox();
            IPLabel = new Label();
            SuspendLayout();
            // 
            // ConnectBTN
            // 
            ConnectBTN.DialogResult = DialogResult.OK;
            ConnectBTN.Location = new Point(111, 179);
            ConnectBTN.Name = "ConnectBTN";
            ConnectBTN.Size = new Size(75, 23);
            ConnectBTN.TabIndex = 0;
            ConnectBTN.Text = "Connect";
            ConnectBTN.UseVisualStyleBackColor = true;
            // 
            // CancelConnectBTN
            // 
            CancelConnectBTN.DialogResult = DialogResult.Cancel;
            CancelConnectBTN.Location = new Point(239, 179);
            CancelConnectBTN.Name = "CancelConnectBTN";
            CancelConnectBTN.Size = new Size(75, 23);
            CancelConnectBTN.TabIndex = 1;
            CancelConnectBTN.Text = "Cancel";
            CancelConnectBTN.UseVisualStyleBackColor = true;
            // 
            // IPPortTB
            // 
            IPPortTB.Location = new Point(62, 103);
            IPPortTB.Name = "IPPortTB";
            IPPortTB.Size = new Size(313, 23);
            IPPortTB.TabIndex = 2;
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IPLabel.Location = new Point(127, 52);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(187, 21);
            IPLabel.TabIndex = 3;
            IPLabel.Text = "IP address or hostname";
            // 
            // ClientDirectConnect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 227);
            Controls.Add(IPLabel);
            Controls.Add(IPPortTB);
            Controls.Add(CancelConnectBTN);
            Controls.Add(ConnectBTN);
            Name = "ClientDirectConnect";
            Text = "ClientDirectConnect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnectBTN;
        private Button CancelConnectBTN;
        private TextBox textBox1;
        private Label IPLabel;
        public TextBox IPPortTB;
    }
}