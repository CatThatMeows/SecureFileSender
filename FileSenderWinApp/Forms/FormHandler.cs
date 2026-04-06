using FileSenderWinApp.Forms.Client;
using FileSenderWinApp.Forms.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSenderWinApp.Forms
{
    internal class FormHandler
    {
        private static Main Main { get; set; }
        public static Form ServerFileList { get; private set; } = new ServerFileList();
        public static Form ServerSettings { get; private set; } = new ServerSettings();
        public static Form ClientServerList { get; private set; } = new ClientServerList();
        public static Form ClientServerFileList { get; private set; } = new ClientServerFileList();
        public static void Init(Main _main)
        {
            Main = _main;
        }
        public static void LoadForm(Form form)
        {
            Main.mainPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            
            Main.mainPanel.Controls.Add(form);

            form.Show();
        }
    }
}
