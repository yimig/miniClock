using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace miniClock.Utils
{
    internal static class BootWithWindows
    {
        private static readonly string filepath = "\"" + Application.ExecutablePath + "\" -s";
        private static readonly string runName = "miniClockT2";

        public static void Boot(bool isBoot)
        {
            if (isBoot)
                SetReg();
            else
                DelReg();
        }

        private static void SetReg()
        {
            try
            {
                var hkml = Registry.CurrentUser;
                var runKey = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
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
                var hkml = Registry.CurrentUser;
                var runKeys = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                runKeys.DeleteValue(runName);
                runKeys.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string GetAppPath()
        {
            var hkml = Registry.CurrentUser;
            var runKeys = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
            var path = (string) runKeys.GetValue(runName);
            path = path.Replace("\"", "").Remove(path.Length - 5, 3);
            return new FileInfo(path).DirectoryName;
        }
    }
}