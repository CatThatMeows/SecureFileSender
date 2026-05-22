namespace FileSenderTesterApp
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connectBTN = new Button();
            IPTB = new TextBox();
            connectedLB = new Label();
            IPLB = new Label();
            responseTB = new TextBox();
            packetTypesCB = new ComboBox();
            sendReqBTN = new Button();
            requestBodyTB = new TextBox();
            inputLB = new Label();
            packetsToSendNSB = new NumericUpDown();
            label1 = new Label();
            disconnectBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)packetsToSendNSB).BeginInit();
            SuspendLayout();
            // 
            // connectBTN
            // 
            connectBTN.Location = new Point(504, 65);
            connectBTN.Name = "connectBTN";
            connectBTN.Size = new Size(94, 29);
            connectBTN.TabIndex = 0;
            connectBTN.Text = "Connect";
            connectBTN.UseVisualStyleBackColor = true;
            connectBTN.Click += connectBTN_Click;
            // 
            // IPTB
            // 
            IPTB.Location = new Point(223, 65);
            IPTB.Name = "IPTB";
            IPTB.Size = new Size(250, 27);
            IPTB.TabIndex = 1;
            // 
            // connectedLB
            // 
            connectedLB.AutoSize = true;
            connectedLB.Location = new Point(704, 68);
            connectedLB.Name = "connectedLB";
            connectedLB.Size = new Size(0, 20);
            connectedLB.TabIndex = 2;
            // 
            // IPLB
            // 
            IPLB.AutoSize = true;
            IPLB.Location = new Point(140, 68);
            IPLB.Name = "IPLB";
            IPLB.Size = new Size(24, 20);
            IPLB.TabIndex = 3;
            IPLB.Text = "IP:";
            // 
            // responseTB
            // 
            responseTB.Location = new Point(12, 429);
            responseTB.Multiline = true;
            responseTB.Name = "responseTB";
            responseTB.Size = new Size(982, 280);
            responseTB.TabIndex = 4;
            // 
            // packetTypesCB
            // 
            packetTypesCB.FormattingEnabled = true;
            packetTypesCB.Location = new Point(223, 116);
            packetTypesCB.Name = "packetTypesCB";
            packetTypesCB.Size = new Size(250, 28);
            packetTypesCB.TabIndex = 5;
            packetTypesCB.SelectedIndexChanged += packetTypesCB_SelectedIndexChanged;
            // 
            // sendReqBTN
            // 
            sendReqBTN.Location = new Point(504, 116);
            sendReqBTN.Name = "sendReqBTN";
            sendReqBTN.Size = new Size(94, 29);
            sendReqBTN.TabIndex = 6;
            sendReqBTN.Text = "Send";
            sendReqBTN.UseVisualStyleBackColor = true;
            sendReqBTN.Click += sendReqBTN_Click;
            // 
            // requestBodyTB
            // 
            requestBodyTB.Location = new Point(223, 185);
            requestBodyTB.Multiline = true;
            requestBodyTB.Name = "requestBodyTB";
            requestBodyTB.ScrollBars = ScrollBars.Vertical;
            requestBodyTB.Size = new Size(615, 150);
            requestBodyTB.TabIndex = 7;
            // 
            // inputLB
            // 
            inputLB.AutoSize = true;
            inputLB.Location = new Point(61, 188);
            inputLB.Name = "inputLB";
            inputLB.Size = new Size(103, 20);
            inputLB.TabIndex = 8;
            inputLB.Text = "Request body:";
            // 
            // packetsToSendNSB
            // 
            packetsToSendNSB.Location = new Point(258, 381);
            packetsToSendNSB.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            packetsToSendNSB.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            packetsToSendNSB.Name = "packetsToSendNSB";
            packetsToSendNSB.Size = new Size(56, 27);
            packetsToSendNSB.TabIndex = 9;
            packetsToSendNSB.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 383);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 10;
            label1.Text = "Number of packets to send:";
            // 
            // disconnectBTN
            // 
            disconnectBTN.Location = new Point(604, 65);
            disconnectBTN.Name = "disconnectBTN";
            disconnectBTN.Size = new Size(94, 29);
            disconnectBTN.TabIndex = 11;
            disconnectBTN.Text = "Disconnect";
            disconnectBTN.UseVisualStyleBackColor = true;
            disconnectBTN.Click += disconnectBTN_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(disconnectBTN);
            Controls.Add(label1);
            Controls.Add(packetsToSendNSB);
            Controls.Add(inputLB);
            Controls.Add(requestBodyTB);
            Controls.Add(sendReqBTN);
            Controls.Add(packetTypesCB);
            Controls.Add(responseTB);
            Controls.Add(IPLB);
            Controls.Add(connectedLB);
            Controls.Add(IPTB);
            Controls.Add(connectBTN);
            MaximumSize = new Size(1024, 768);
            MinimumSize = new Size(1024, 768);
            Name = "Main";
            Text = "FileSender Tester App";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)packetsToSendNSB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button connectBTN;
        private TextBox IPTB;
        public Label connectedLB;
        private Label IPLB;
        private TextBox responseTB;
        private ComboBox packetTypesCB;
        private Button sendReqBTN;
        private TextBox requestBodyTB;
        private Label inputLB;
        private NumericUpDown packetsToSendNSB;
        private Label label1;
        private Button disconnectBTN;
    }
}
