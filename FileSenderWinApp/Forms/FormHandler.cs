using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSenderWinApp.Forms
{
    internal class FormHandler
    {
        public static FormHandler _FH { get; private set; } = new FormHandler();
        private static Main Main { get; set; }
        public static Form ServerFileList { get; private set; } = new ServerFileList();
        public static Form ServerSettings { get; private set; } = new ServerSettings();
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
