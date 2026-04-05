using FileSender.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FileSenderWinApp.Forms.Server
{
    public partial class ServerSettings : Form
    {
        public ServerSettings()
        {
            InitializeComponent();
        }

        private void PortTB_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(PortTB.Text, out int port)) { 
                if(port < 1 || port > 65535)
                {
                    PortTB.Text = CoreSettings.CS.Port.ToString();
                    port = CoreSettings.CS.Port;
                }

                if(port != CoreSettings.CS.Port)
                    FileSender.Core.CoreSettings.CS.SetPort(port);
            }
            else
            {
                PortTB.Text = CoreSettings.CS.Port.ToString();
            }
        }

        private void CertificateImportLabel_Click(object sender, EventArgs e)
        {
            PasswordInput PIF = new PasswordInput("Input the password to import the certificate", false);
            bool result = false;
            if (PIF.ShowDialog() == DialogResult.OK)
            {
                using (OpenFileDialog opf = new OpenFileDialog())
                {
                    opf.Multiselect = false;
                    opf.Filter = "PKCS#12 Certificate (*.p12;*.pfx)|*.p12;*.pfx";

                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        result = CoreSettings.CS.ImportCertificate(PIF.PasswordInputFormTB.Text, opf.FileName);
                        if (!result)
                        {
                            MessageBox.Show("Error during import");
                        }
                    }
                }
            }
            if (result)
            {
                CertificateStatusLabel.Text = "CERTIFICATE ACTIVE";
                CertificateStatusLabel.ForeColor = Color.Green;
            }
            else
            {
                CertificateStatusLabel.Text = "CERTIFICATE INACTIVE";
                CertificateStatusLabel.ForeColor = Color.Red;
            }
        }

        public void SetPort(string port)
        {
            PortTB.Text = port;
        }

        private void CreateCertificateBTN_Click(object sender, EventArgs e)
        {
            PasswordInput PIF = new PasswordInput("You will need this password to import the certificate each time you start the server", true);
            if(PIF.ShowDialog() == DialogResult.OK)
            {
                if (PIF.PasswordInputFormTB.Text == PIF.PasswordConfirmInputFormTB.Text)
                {
                    CoreSettings.CS.CreateNewCert("FSApp", PIF.PasswordInputFormTB.Text);
                }
                else
                {
                    MessageBox.Show("The passwords don't match");
                }
            }
        }
    }
}
