using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using miniClockT2.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace miniClockT2
{
    public partial class WSetting : Form
    {
        private WClock wClock;
        private Anchor anchor;
        private int screenWidth, screenHeight;
        private BreakQueue<Color> colorQueue;
        private Label[] lbColors;
        private Settings settings;
        private string settingFileName = "settings.json";
        private bool isShowClock;
        private bool defaultHide;

        public WSetting(bool isShow)
        {
            InitializeComponent();
            GetScreenResolution();
            LoadColorQueue();
            isShowClock = true;
            GetSettingPath();
            defaultHide = !isShow;
        }

        public void GetSettingPath()
        {
            try
            {
                string path = BootWithWindows.GetAppPath();
                settingFileName = path + "\\" + settingFileName;
            }
            catch (Exception)
            {
                MessageBox.Show("在注册表中找不到启动路径，请手动写入注册表或重新安装", "启动错误");
            }
        }

        private void LoadColorQueue()
        {
            SystemEvents.DisplaySettingsChanged += new
                EventHandler(SystemEvents_DisplaySettingsChanged);
            InitColorQueue();
            Label[] tempLabels = { lbColor1, lbColor2, lbColor3, lbColor4, lbColor5 };
            lbColors = tempLabels;
            foreach (var label in lbColors)
            {
                label.Click += lbColors_Click;
            }
        }

        private void LoadSettings()
        {
            settings = JsonConvert.DeserializeObject<Settings>(ReadSettings());
            trbHorizontal.Value = settings.Location.Horizontal;
            trbVertical.Value = settings.Location.Vertical;
            trbSize.Value = settings.Location.Size;
            trbFontSize.Value = settings.Style.FontSize;
            trbOpacity.Value = settings.Style.Opacity;
            wClock.ChangeClockFont(settings.Style.GetFont());
            ChangeNowColor(settings.Style.NowColor.GetColor());
            colorQueue = settings.Style.GetCacheColors();
            ReloadColorQueue();
            ReloadTrackBar();
            chbBoot.Checked = settings.Common.BootWithWindows;
            wClock.ResizeWindow();
        }

        private void ReloadTrackBar()
        {
            object obj=new object();
            EventArgs e=new EventArgs();
            trbHorizontal_Scroll(obj,e);
            trbVertical_Scroll(obj,e);
            trbSize_Scroll(obj,e);
            trbFontSize_Scroll(obj, e);
            wClock.DisableEditMode();
            trbOpacity_Scroll(obj,e);
        }

        private string ReadSettings()
        {
            StreamReader sr=new StreamReader(settingFileName);
            string jsonStr = sr.ReadToEnd();
            sr.Close();
            return jsonStr;
        }

        private void SetDefaultSettings()
        {
            if(!File.Exists(settingFileName))WriteSettings(GetDefaultSettings());
        }

        private string GetDefaultSettings()
        {
            LocationSettings loSettings = new LocationSettings(50, 50, 10);
            StyleSettings sySettings = new StyleSettings(50, new Font("微软雅黑", 24), Color.FromArgb(255,255,255,255), colorQueue);
            CommonSettings comSettings = new CommonSettings(false);
            Settings settings = new Settings(loSettings, sySettings, comSettings);
            return JsonConvert.SerializeObject(settings);
        }

        private void SaveSettings()
        {
            WriteSettings(JsonConvert.SerializeObject(settings));
        }

        private void WriteSettings(string jsonStr)
        {
            StreamWriter writer =new StreamWriter(settingFileName);
            writer.Write(jsonStr);
            writer.Close();
        }

        private void lbColors_Click(object sender, EventArgs e)
        {
            ChangeNowColor(((Label)sender).BackColor);
        }

        private void ChangeNowColor(Color nowColor)
        {
            settings.Style.NowColor=new JsonColor(nowColor);
            wClock.ChangeClockFontColor(nowColor);
            lbNowColor.BackColor = nowColor;
        }

        private void InitColorQueue()
        {
            colorQueue=new BreakQueue<Color>(5);
            for(int i=0;i<5;i++)colorQueue.Enqueue(Color.FromArgb(255,255,255,255));
        }

        private void ReloadColorQueue()
        {
            for (int i = 0; i < 5; i++)
            {
                lbColors[i].BackColor = colorQueue[i];
            }
        }

        private void GetScreenResolution()
        {
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenWidth = Screen.PrimaryScreen.Bounds.Width;
        }

        private void ChangeLocationX()
        {
            settings.Location.Horizontal = trbHorizontal.Value;
            int x = (int)(screenWidth * ((double)trbHorizontal.Value / 100));
            anchor.CenterPoint = new Point(x, anchor.CenterPoint.Y);
            wClock.Location = anchor.AnchorPoint;
        }

        private void ChangeLocationY()
        {
            settings.Location.Vertical = trbVertical.Value;
            int y = (int)(screenHeight * ((double)trbVertical.Value / 100));
            anchor.CenterPoint = new Point(anchor.CenterPoint.X, y);
            wClock.Location = anchor.AnchorPoint;
        }

        private void ChangeSize()
        {
            settings.Location.Size = trbSize.Value;
            anchor.Height = 10 * trbSize.Value;
            anchor.Width = 30 * trbSize.Value;
            wClock.Location = anchor.AnchorPoint;
            wClock.Size = new Size(anchor.Width, anchor.Height);
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            GetScreenResolution();
            ChangeLocationX();
            ChangeLocationY();
        }

        private void WSetting_Load(object sender, EventArgs e)
        {
            if (wClock != null) return;
            wClock=new WClock();
            wClock.Show();
            anchor =new Anchor(wClock.Height,wClock.Width,wClock.Location,true);
            SetDefaultSettings();
            LoadSettings();
            if(defaultHide)HideForm();
        }

        private void trbHorizontal_Scroll(object sender, EventArgs e)
        {
            ChangeLocationX();
        }

        private void trbVertical_Scroll(object sender, EventArgs e)
        {
            ChangeLocationY();
        }

        private void trbSize_Scroll(object sender, EventArgs e)
        {
            ChangeSize();
            wClock.EnableEditMode();
        }

        private void trbFontSize_Scroll(object sender, EventArgs e)
        {
            settings.Style.FontSize = trbFontSize.Value;
            wClock.ChangeClockFontSize(trbFontSize.Value*2);
            wClock.EnableEditMode();
        }

        private void trbSize_MouseUp(object sender, MouseEventArgs e)
        {
            wClock.DisableEditMode();
        }

        private void trbFontSize_MouseUp(object sender, MouseEventArgs e)
        {
            wClock.DisableEditMode();
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog=new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                settings.Style.SetFont(fontDialog.Font);
                wClock.ChangeClockFont(fontDialog.Font);
            }
        }

        private void trbOpacity_Scroll(object sender, EventArgs e)
        {
            settings.Style.Opacity = trbOpacity.Value;
            wClock.ChangeOpacity(trbOpacity.Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MessageBox.Show("已保存");
        }

        private void chbBoot_CheckedChanged(object sender, EventArgs e)
        {
            BootWithWindows.Boot(chbBoot.Checked);
            settings.Common.BootWithWindows = chbBoot.Checked;
            SaveSettings();
        }

        private void lbBlog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://upane.cn/");
        }

        private void lbProject_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/yimig/miniClock");
        }

        private void HideForm()
        {
            ShowInTaskbar = false;
            this.Hide();
        }

        private void ShowForm()
        {
            ShowInTaskbar = true;
            this.Show();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)ShowForm();
        }

        private void WSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.WindowsShutDown)Environment.Exit(0);
            else
            {
                HideForm();
                e.Cancel = true;
            }
        }

        private void tsmiHideOrShow_Click(object sender, EventArgs e)
        {
            if (!isShowClock)
            {
                wClock.Show();
            }
            else
            {
                wClock.Hide();
            }

            isShowClock = !isShowClock;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void trbSize_MouseLeave(object sender, EventArgs e)
        {
            wClock.DisableEditMode();
        }

        private void trbFontSize_MouseLeave(object sender, EventArgs e)
        {
            wClock.DisableEditMode();
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog=new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorQueue.Enqueue(colorDialog.Color);
                ReloadColorQueue();
                settings.Style.SetCacheColors(colorQueue);
                ChangeNowColor(colorDialog.Color);
            }
        }
    }
}
