using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace miniClockT2
{
    public partial class WSetting : Form
    {
        private WClock wClock;
        private Anchor anchor;
        private int screenWidth, screenHeight;
        private BreakQueue<Color> colorQueue;
        private Label[] lbColors;

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
            int x = (int)(screenWidth * ((double)trbHorizontal.Value / 100));
            anchor.CenterPoint = new Point(x, anchor.CenterPoint.Y);
            wClock.Location = anchor.AnchorPoint;
        }

        private void ChangeLocationY()
        {
            int y = (int)(screenHeight * ((double)trbVertical.Value / 100));
            anchor.CenterPoint = new Point(anchor.CenterPoint.X, y);
            wClock.Location = anchor.AnchorPoint;
        }

        private void ChangeSIze()
        {
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
            ChangeSIze();
            wClock.EnableEditMode();
        }

        private void trbFontSize_Scroll(object sender, EventArgs e)
        {
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
                wClock.ChangeClockFont(fontDialog.Font);
            }
        }

        private void trbOpacity_Scroll(object sender, EventArgs e)
        {
            wClock.ChangeOpacity(trbOpacity.Value);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog=new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lbNowColor.BackColor = colorDialog.Color;
                colorQueue.Enqueue(colorDialog.Color);
                ReloadColorQueue();
                wClock.ChangeClockFontColor(colorDialog.Color);
            }
        }
    }
}
