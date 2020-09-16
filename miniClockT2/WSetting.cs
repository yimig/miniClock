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

        public WSetting()
        {
            InitializeComponent();
            SystemEvents.DisplaySettingsChanged += new
                EventHandler(SystemEvents_DisplaySettingsChanged);
            GetScreenResolution();
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
        }
    }
}
