using System;
using System.Windows;

namespace miniClock
{
    /// <summary>
    ///     App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            wSetting win;
            if (args.Length != 1 && args[1] == "-s")
            {
                win = new wSetting(false);
            }
            else
            {
                win = new wSetting(true);
                win.Show();
            }
        }
    }
}