namespace FileSenderWinApp.Forms
{
    public partial class PasswordInput : Form
    {
        public PasswordInput(string message, bool needconfirm)
        {
            InitializeComponent();
            MsgLabel.Text = message;
            if (!needconfirm)
            {
                PasswordConfirmInputFormTB.Visible = false;
                ConfirmPasswordLabel.Visible = false;
            }
        }
    }
}
