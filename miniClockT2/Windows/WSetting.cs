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
        private const string SETTING_FILE_NAME = "settings.json";

        public WSetting()
        {
            InitializeComponent();
            SystemEvents.DisplaySettingsChanged += new
                EventHandler(SystemEvents_DisplaySettingsChanged);
            GetScreenResolution();
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
            lbNowColor.BackColor = settings.Style.NowColor.GetColor();
            wClock.ChangeClockFontColor(settings.Style.NowColor.GetColor());
            colorQueue = settings.Style.GetCacheColors();
            ReloadColorQueue();
            ReloadTrackBar();
        }

        private void ReloadTrackBar()
        {
            object obj=new object();
            EventArgs e=new EventArgs();
            trbHorizontal_Scroll(obj,e);
            trbVertical_Scroll(obj,e);
            trbSize_Scroll(obj,e);
            trbFontSize_Scroll(obj, e);
            trbOpacity_Scroll(obj,e);
        }

        private string ReadSettings()
        {
            StreamReader sr=new StreamReader(SETTING_FILE_NAME);
            string jsonStr = sr.ReadToEnd();
            sr.Close();
            return jsonStr;
        }

        private void SetDefaultSettings()
        {
            if(!File.Exists(SETTING_FILE_NAME))WriteSettings(GetDefaultSettings());
        }

        private string GetDefaultSettings()
        {
            LocationSettings loSettings = new LocationSettings(50, 50, 10);
            StyleSettings sySettings = new StyleSettings(50, new Font("微软雅黑", 24), Color.FromArgb(255,255,255,255), colorQueue);
            Settings settings = new Settings(loSettings, sySettings);
            return JsonConvert.SerializeObject(settings);
        }

        private void WriteSettings(string jsonStr)
        {
            StreamWriter writer =new StreamWriter(SETTING_FILE_NAME);
            writer.Write(jsonStr);
            writer.Close();
        }

        private void lbColors_Click(object sender, EventArgs e)
        {
            wClock.ChangeClockFontColor(((Label)sender).BackColor);
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
            wClock.ChangeOpacity(trbOpacity.Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteSettings(JsonConvert.SerializeObject(settings));
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog=new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                settings.Style.NowColor = new JsonColor(colorDialog.Color);
                lbNowColor.BackColor = colorDialog.Color;
                colorQueue.Enqueue(colorDialog.Color);
                ReloadColorQueue();
                settings.Style.SetCacheColors(colorQueue);
                wClock.ChangeClockFontColor(colorDialog.Color);
            }
        }
    }
}
