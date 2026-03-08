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
            label1 = new Label();
            SuspendLayout();
            // 
            // PasswordInputFormTB
            // 
            PasswordInputFormTB.Location = new Point(81, 96);
            PasswordInputFormTB.Name = "PasswordInputFormTB";
            PasswordInputFormTB.Size = new Size(322, 23);
            PasswordInputFormTB.TabIndex = 0;
            PasswordInputFormTB.UseSystemPasswordChar = true;
            // 
            // PasswordInputFormSubmitBTN
            // 
            PasswordInputFormSubmitBTN.DialogResult = DialogResult.OK;
            PasswordInputFormSubmitBTN.Location = new Point(147, 233);
            PasswordInputFormSubmitBTN.Name = "PasswordInputFormSubmitBTN";
            PasswordInputFormSubmitBTN.Size = new Size(75, 23);
            PasswordInputFormSubmitBTN.TabIndex = 1;
            PasswordInputFormSubmitBTN.Text = "Submit";
            PasswordInputFormSubmitBTN.UseVisualStyleBackColor = true;
            // 
            // PasswordInputCancelSubmitBTN
            // 
            PasswordInputCancelSubmitBTN.DialogResult = DialogResult.Cancel;
            PasswordInputCancelSubmitBTN.Location = new Point(272, 233);
            PasswordInputCancelSubmitBTN.Name = "PasswordInputCancelSubmitBTN";
            PasswordInputCancelSubmitBTN.Size = new Size(75, 23);
            PasswordInputCancelSubmitBTN.TabIndex = 2;
            PasswordInputCancelSubmitBTN.Text = "Cancel";
            PasswordInputCancelSubmitBTN.UseVisualStyleBackColor = true;
            // 
            // PasswordConfirmInputFormTB
            // 
            PasswordConfirmInputFormTB.Location = new Point(81, 163);
            PasswordConfirmInputFormTB.Name = "PasswordConfirmInputFormTB";
            PasswordConfirmInputFormTB.Size = new Size(322, 23);
            PasswordConfirmInputFormTB.TabIndex = 3;
            PasswordConfirmInputFormTB.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(213, 78);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password";
            // 
            // ConfirmPasswordLabel
            // 
            ConfirmPasswordLabel.AutoSize = true;
            ConfirmPasswordLabel.Location = new Point(191, 145);
            ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            ConfirmPasswordLabel.Size = new Size(104, 15);
            ConfirmPasswordLabel.TabIndex = 5;
            ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(438, 15);
            label1.TabIndex = 6;
            label1.Text = "You will need this password to import the certificate each time you start the server";
            // 
            // PasswordInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 281);
            Controls.Add(label1);
            Controls.Add(ConfirmPasswordLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(PasswordConfirmInputFormTB);
            Controls.Add(PasswordInputCancelSubmitBTN);
            Controls.Add(PasswordInputFormSubmitBTN);
            Controls.Add(PasswordInputFormTB);
            MaximumSize = new Size(500, 320);
            MinimumSize = new Size(500, 320);
            Name = "PasswordInput";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public TextBox PasswordInputFormTB;
        private Button PasswordInputFormSubmitBTN;
        private Button PasswordInputCancelSubmitBTN;
        public TextBox PasswordConfirmInputFormTB;
        private Label label1;
        public Label PasswordLabel;
        public Label ConfirmPasswordLabel;
    }
}