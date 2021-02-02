using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Microsoft.Win32;
using miniClock.Utils;
using Newtonsoft.Json;
using Color = System.Windows.Media.Color;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Point = System.Drawing.Point;

namespace miniClock
{
    /// <summary>
    ///     wSetting.xaml 的交互逻辑
    /// </summary>
    public partial class wSetting : Window
    {
        private Anchor anchor;
        private BreakQueue<Color> colorQueue;
        private readonly bool defaultHide;
        private bool isShowClock;
        private TextBlock[] lbColors;
        private int screenWidth, screenHeight;
        private string settingFileName = "settings.json";
        private Settings settings;
        private NotifyIcon notifyIcon;
        private wClock wClock;

        public wSetting(bool isShow)
        {
            LoadWindow();
            defaultHide = !isShow;
        }

        public wSetting()
        {
            LoadWindow();
            defaultHide = false;
        }

        private void LoadWindow()
        {
            InitializeComponent();
            GetScreenResolution();
            LoadColorQueue();
            isShowClock = true;
            GetSettingPath();
            LoadClock();
            InitNotifyIcon();
        }


        private void InitNotifyIcon()
        {
            if (notifyIcon != null) return;
            notifyIcon = new NotifyIcon();
            notifyIcon.Text = "Mini Clock";
            notifyIcon.Icon = miniClock.Properties.Resources.icon;
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            var menu = new ContextMenu(); 
            var closeItem = new MenuItem("隐藏/显示");
            closeItem.Click += tsmiHideOrShow_Click;
            var exitItem = new MenuItem("退出");
            exitItem.Click += tsmiExit_Click;
            menu.MenuItems.Add(closeItem);
            menu.MenuItems.Add(exitItem);
            notifyIcon.ContextMenu = menu;
        }

        public void GetSettingPath()
        {
            try
            {
                var path = BootWithWindows.GetAppPath();
                settingFileName = path + "\\" + settingFileName;
            }
            catch (Exception)
            {
                MessageBox.Show("在注册表中找不到启动路径，请手动写入注册表或重新安装", "启动错误");
            }
        }

        private void LoadColorQueue()
        {
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            InitColorQueue();
            TextBlock[] tempLabels = {lbColor1, lbColor2, lbColor3, lbColor4, lbColor5};
            lbColors = tempLabels;
            foreach (var label in lbColors) label.MouseDown += lbColors_Click;
        }

        private void LoadSettings()
        {
            settings = JsonConvert.DeserializeObject<Settings>(ReadSettings());
            trbHorizontal.Value = settings.Location.Horizontal;
            trbVertical.Value = settings.Location.Vertical;
            //trbSize.Value = settings.Location.Size;
            trbFontSize.Value = settings.Style.FontSize;
            trbOpacity.Value = settings.Style.Opacity;
            wClock.ChangeClockFont(settings.Style.GetFont());
            ChangeNowColor(settings.Style.NowColor.GetColor());
            colorQueue = settings.Style.GetCacheColors();
            ReloadColorQueue();
            ReloadTrackBar();
            chbBoot.IsChecked = settings.Common.BootWithWindows;
            //wClock.ResizeWindow();
        }

        private void ReloadTrackBar()
        {
            var obj = new object();
            var e = new EventArgs();
            trbHorizontal_Scroll(obj, e);
            trbVertical_Scroll(obj, e);
            //trbSize_Scroll(obj, e);
            trbFontSize_Scroll(obj, e);
            trbOpacity_Scroll(obj, e);
        }

        private string ReadSettings()
        {
            var sr = new StreamReader(settingFileName);
            var jsonStr = sr.ReadToEnd();
            sr.Close();
            return jsonStr;
        }

        private void SetDefaultSettings()
        {
            if (!File.Exists(settingFileName)) WriteSettings(GetDefaultSettings());
        }

        private string GetDefaultSettings()
        {
            var loSettings = new LocationSettings(50, 50, 10);
            var sySettings =
                new StyleSettings(50, new Font("微软雅黑", 24), Color.FromArgb(255, 255, 255, 255), colorQueue);
            var comSettings = new CommonSettings(false);
            var settings = new Settings(loSettings, sySettings, comSettings);
            return JsonConvert.SerializeObject(settings);
        }

        private void SaveSettings()
        {
            WriteSettings(JsonConvert.SerializeObject(settings));
        }

        private void WriteSettings(string jsonStr)
        {
            var writer = new StreamWriter(settingFileName);
            writer.Write(jsonStr);
            writer.Close();
        }

        private void lbColors_Click(object sender, EventArgs e)
        {
            ChangeNowColor(((SolidColorBrush) ((TextBlock) sender).Background).Color);
        }

        private void ChangeNowColor(Color nowColor)
        {
            settings.Style.NowColor = new JsonColor(nowColor);
            wClock.ChangeClockFontColor(new SolidColorBrush(nowColor));
            lbNowColor.Background = new SolidColorBrush(nowColor);
        }

        private void InitColorQueue()
        {
            colorQueue = new BreakQueue<Color>(5);
            for (var i = 0; i < 5; i++) colorQueue.Enqueue(Color.FromArgb(255, 255, 255, 255));
        }

        private void ReloadColorQueue()
        {
            for (var i = 0; i < 5; i++) lbColors[i].Background = new SolidColorBrush(colorQueue[i]);
        }

        private void GetScreenResolution()
        {
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
        }

        private void ChangeWindowLocation(Anchor anchor)
        {
            wClock.Left = anchor.AnchorPoint.X;
            wClock.Top = anchor.AnchorPoint.Y;
        }

        private void ChangeLocationX()
        {
            settings.Location.Horizontal = (int) trbHorizontal.Value;
            var x = (int) (screenWidth * (trbHorizontal.Value / 100));
            anchor.CenterPoint = new Point(x, anchor.CenterPoint.Y);
            ChangeWindowLocation(anchor);
        }

        private void ChangeLocationY()
        {
            settings.Location.Vertical = (int) trbVertical.Value;
            var y = (int) (screenHeight * (trbVertical.Value / 100));
            anchor.CenterPoint = new Point(anchor.CenterPoint.X, y);
            ChangeWindowLocation(anchor);
        }

        // private void ChangeSize()
        // {
        //     settings.Location.Size = trbSize.Value;
        //     anchor.Height = 10 * trbSize.Value;
        //     anchor.Width = 30 * trbSize.Value;
        //     ChangeWindowLocation(anchor);
        //     wClock.Size = new Size(anchor.Width, anchor.Height);
        // }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            GetScreenResolution();
            ChangeLocationX();
            ChangeLocationY();
        }

        private void LoadClock()
        {
            if (wClock != null) return;
            wClock = new wClock();
            wClock.Show();
            anchor = new Anchor((int) wClock.Height, (int) wClock.Width, new Point((int) wClock.Left, (int) wClock.Top),
                true);
            SetDefaultSettings();
            LoadSettings();
            if (defaultHide) HideForm();
        }

        private void trbHorizontal_Scroll(object sender, EventArgs e)
        {
            if (settings != null) ChangeLocationX();
        }

        private void trbVertical_Scroll(object sender, EventArgs e)
        {
            if (settings != null) ChangeLocationY();
        }


        private void trbFontSize_Scroll(object sender, EventArgs e)
        {
            if (settings != null)
            {
                settings.Style.FontSize = (int) trbFontSize.Value;
                wClock.ChangeClockFontSize((int) trbFontSize.Value * 2);
            }
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                settings.Style.SetFont(fontDialog.Font);
                wClock.ChangeClockFont(fontDialog.Font);
            }
        }

        private void trbOpacity_Scroll(object sender, EventArgs e)
        {
            if (settings != null)
            {
                settings.Style.Opacity = (int) trbOpacity.Value;
                wClock.ChangeOpacity((int) trbOpacity.Value);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MessageBox.Show("已保存");
        }

        private void chbBoot_CheckedChanged(object sender, EventArgs e)
        {
            BootWithWindows.Boot((bool) chbBoot.IsChecked);
            settings.Common.BootWithWindows = (bool) chbBoot.IsChecked;
            SaveSettings();
        }

        private void lbBlog_Click(object sender, EventArgs e)
        {
            Process.Start("https://upane.cn/");
        }

        private void lbProject_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/yimig/miniClock");
        }

        private void HideForm()
        {
            ShowInTaskbar = false;
            Hide();
        }

        private void ShowForm()
        {
            ShowInTaskbar = true;
            Show();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left) ShowForm();
        }

        // private void WSetting_FormClosing(object sender, CancelEventArgs e)
        // {
        //     if (e.Cancel == CloseReason.WindowsShutDown)
        //     {
        //         Environment.Exit(0);
        //     }
        //     else
        //     {
        //         HideForm();
        //         e.Cancel = true;
        //     }
        // }

        private void tsmiHideOrShow_Click(object sender, EventArgs e)
        {
            if (!isShowClock)
                wClock.Show();
            else
                wClock.Hide();

            isShowClock = !isShowClock;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public static Color GetMediaColorFromDrawingColor(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var mediaColor = GetMediaColorFromDrawingColor(colorDialog.Color);
                colorQueue.Enqueue(mediaColor);
                ReloadColorQueue();
                settings.Style.SetCacheColors(colorQueue);
                ChangeNowColor(mediaColor);
            }
        }

        // private void WSetting_OnLoaded(object sender, RoutedEventArgs e)
        // {
        //     HwndSource source = (HwndSource)PresentationSource.FromDependencyObject(this);
        //     source.AddHook(WindowProc);
        // }
        //
        // private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        // {
        //     switch (msg)
        //     {
        //         case 0x11:
        //         case 0x16:
        //             Environment.Exit(0);
        //             break;
        //         case 0x112:
        //             if ((LOWORD((int) wParam) & 0xfff0) == 0xf060)
        //                 Console.WriteLine("Close reason: UserClosing");
        //             break;
        //     }
        //     return IntPtr.Zero;
        // }
        //
        // private static int LOWORD(int n)
        // {
        //     return (n & 0xffff);
        // }
    }
}