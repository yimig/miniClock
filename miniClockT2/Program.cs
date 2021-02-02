using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using miniClockT2.Windows;

namespace miniClockT2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0 && args[0] == "-s")
            {
                Application.Run(new WSetting(false));
                //Application.Run(new TestForm());
            }
            else
            {
                Application.Run(new WSetting(true));
            }
        }
    }
}
