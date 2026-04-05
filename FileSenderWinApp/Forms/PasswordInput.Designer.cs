namespace FileSenderWinApp.Forms
{
    partial class PasswordInput
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
            PasswordInputFormTB = new TextBox();
            PasswordInputFormSubmitBTN = new Button();
            PasswordInputCancelSubmitBTN = new Button();
            PasswordConfirmInputFormTB = new TextBox();
            PasswordLabel = new Label();
            ConfirmPasswordLabel = new Label();
            MsgLabel = new Label();
            SuspendLayout();
            // 
            // PasswordInputFormTB
            // 
            PasswordInputFormTB.Location = new Point(125, 112);
            PasswordInputFormTB.Margin = new Padding(3, 4, 3, 4);
            PasswordInputFormTB.Name = "PasswordInputFormTB";
            PasswordInputFormTB.Size = new Size(367, 27);
            PasswordInputFormTB.TabIndex = 0;
            PasswordInputFormTB.UseSystemPasswordChar = true;
            // 
            // PasswordInputFormSubmitBTN
            // 
            PasswordInputFormSubmitBTN.DialogResult = DialogResult.OK;
            PasswordInputFormSubmitBTN.Location = new Point(200, 295);
            PasswordInputFormSubmitBTN.Margin = new Padding(3, 4, 3, 4);
            PasswordInputFormSubmitBTN.Name = "PasswordInputFormSubmitBTN";
            PasswordInputFormSubmitBTN.Size = new Size(86, 31);
            PasswordInputFormSubmitBTN.TabIndex = 1;
            PasswordInputFormSubmitBTN.Text = "Submit";
            PasswordInputFormSubmitBTN.UseVisualStyleBackColor = true;
            // 
            // PasswordInputCancelSubmitBTN
            // 
            PasswordInputCancelSubmitBTN.DialogResult = DialogResult.Cancel;
            PasswordInputCancelSubmitBTN.Location = new Point(343, 295);
            PasswordInputCancelSubmitBTN.Margin = new Padding(3, 4, 3, 4);
            PasswordInputCancelSubmitBTN.Name = "PasswordInputCancelSubmitBTN";
            PasswordInputCancelSubmitBTN.Size = new Size(86, 31);
            PasswordInputCancelSubmitBTN.TabIndex = 2;
            PasswordInputCancelSubmitBTN.Text = "Cancel";
            PasswordInputCancelSubmitBTN.UseVisualStyleBackColor = true;
            // 
            // PasswordConfirmInputFormTB
            // 
            PasswordConfirmInputFormTB.Location = new Point(125, 201);
            PasswordConfirmInputFormTB.Margin = new Padding(3, 4, 3, 4);
            PasswordConfirmInputFormTB.Name = "PasswordConfirmInputFormTB";
            PasswordConfirmInputFormTB.Size = new Size(367, 27);
            PasswordConfirmInputFormTB.TabIndex = 3;
            PasswordConfirmInputFormTB.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(275, 88);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(70, 20);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password";
            // 
            // ConfirmPasswordLabel
            // 
            ConfirmPasswordLabel.AutoSize = true;
            ConfirmPasswordLabel.Location = new Point(250, 177);
            ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            ConfirmPasswordLabel.Size = new Size(127, 20);
            ConfirmPasswordLabel.TabIndex = 5;
            ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // MsgLabel
            // 
            MsgLabel.AutoSize = true;
            MsgLabel.Location = new Point(12, 27);
            MsgLabel.Name = "MsgLabel";
            MsgLabel.Size = new Size(0, 20);
            MsgLabel.TabIndex = 6;
            MsgLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // PasswordInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 433);
            Controls.Add(MsgLabel);
            Controls.Add(ConfirmPasswordLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(PasswordConfirmInputFormTB);
            Controls.Add(PasswordInputCancelSubmitBTN);
            Controls.Add(PasswordInputFormSubmitBTN);
            Controls.Add(PasswordInputFormTB);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(640, 480);
            MinimumSize = new Size(640, 480);
            Name = "PasswordInput";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public TextBox PasswordInputFormTB;
        private Button PasswordInputFormSubmitBTN;
        private Button PasswordInputCancelSubmitBTN;
        public TextBox PasswordConfirmInputFormTB;
        private Label MsgLabel;
        public Label PasswordLabel;
        public Label ConfirmPasswordLabel;
    }
}