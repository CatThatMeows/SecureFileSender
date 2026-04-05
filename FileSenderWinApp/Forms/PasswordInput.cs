using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
