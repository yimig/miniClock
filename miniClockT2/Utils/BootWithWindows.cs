using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace miniClockT2.Utils
{
    static class BootWithWindows
    {
        static string filepath = "\"" + Application.ExecutablePath + "\"";
        static string runName = "miniClockT2";

        public static void Boot(bool isBoot)
        {
            if (isBoot)
            {
                SetReg();
            }
            else
            {
                DelReg();
            }
        }

        private static void SetReg()
        {
            try
            {
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey runKey = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                runKey.SetValue(runName, filepath);
                runKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void DelReg()
        {
            try
            {
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey runKeys = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                runKeys.DeleteValue(runName);
                runKeys.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
