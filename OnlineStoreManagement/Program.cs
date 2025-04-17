using System;
using System.Windows.Forms;
using FontAwesome.Sharp;


namespace OnlineStoreManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());  // Corrected form name
        }
    }
}
