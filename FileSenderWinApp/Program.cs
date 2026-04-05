using FileSender.Core.Network.Client;

namespace FileSenderWinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //DEBUG
            Discover dc = new Discover();
            dc.ConnectDummmy().GetAwaiter().GetResult();

            Forms.Main mainForm = new Forms.Main();
            Forms.FormHandler.Init(mainForm);

            Application.Run(mainForm);
        }
    }
}