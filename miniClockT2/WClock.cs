using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace miniClockT2
{
    public partial class WClock : Form
    {
        public WClock()
        {
            InitializeComponent();
            SetPenetrate();
            timer.Start();
        }

        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
            IntPtr hwnd,
            int nIndex,
            uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
            IntPtr hwnd,
            int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
            IntPtr hwnd,
            int crKey,
            int bAlpha,
            int dwFlags
        );

        /// <summary> 
        /// 设置窗体具有鼠标穿透效果 
        /// </summary> 
        private void SetPenetrate()
        {
            GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
            SetLayeredWindowAttributes(this.Handle, 0, 100, LWA_ALPHA);
        }

        public void ChangeClockFontSize(int size)
        {
            lbClock.Font=new Font(lbClock.Font.FontFamily,size);
        }

        public void ChangeClockFontColor(Color color)
        {
            BackColor = GetSimilarColor(color);
            lbClock.BackColor = BackColor;
            TransparencyKey = BackColor;
            lbClock.ForeColor = color;
        }

        public Color GetSimilarColor(Color color)
        {
            if (color.R == 0) return Color.FromArgb(color.A, color.R + 1, color.G, color.B);
            else
            {
                return Color.FromArgb(color.A, color.R - 1, color.G, color.B);
            }
        }

        public void EnableEditMode()
        {
            lbClock.BackColor = SystemColors.Control;
            Opacity = 0.5;
        }

        public void DisableEditMode()
        {
            ChangeClockFontColor(lbClock.ForeColor);
            Opacity = 1;
        }

        public void ChangeClockFont(Font font)
        {
            lbClock.Font=new Font(font.FontFamily,lbClock.Font.Size);
        }

        public void ChangeOpacity(int num)
        {
            Opacity = ((double) num) / 100;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbClock.Text = GetDisplayContent();
        }

        private string GetDisplayContent()
        {
            return DigitalProcess(DateTime.Now.Hour) + ":" + DigitalProcess(DateTime.Now.Minute) + ":" +
                   DigitalProcess(DateTime.Now.Second);
        }

        private string DigitalProcess(int digit)
        {
            if (digit < 10) return "0" + digit;
            else
            {
                return "" + digit;
            }
        }
    }
}
