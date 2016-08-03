using System;
using System.Linq;
using System.Windows.Forms;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace COP2001
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
            Application.Run(new Login());
        }
    }
}