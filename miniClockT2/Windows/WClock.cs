using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using miniClockT2.Utils;

namespace miniClockT2
{
    public partial class WClock : Form
    {
        private TimeDistributer timeDistributer;
        private Label[] lbTimes;
        public WClock()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lbTimes = new Label[] { lbSecond, lbMinute, lbHour, lbColon1, lbColon2 };
            SetPenetrate();
            SetDefaultTime();
            InitDestributer();
        }

        private void InitDestributer()
        {
            timeDistributer = new TimeDistributer();
            timeDistributer.SecondChanged += TimeDistributer_SecondChanged;
            timeDistributer.MinuteChanged += TimeDistributer_MinuteChanged;
            timeDistributer.HourChanged += TimeDistributer_HourChanged;
        }

        private void SetDefaultTime()
        {
            lbHour.Text = DateTime.Now.Hour.ToString();
            lbMinute.Text = DateTime.Now.Minute.ToString();
            lbSecond.Text = DateTime.Now.Second.ToString();
        }

        private void TimeDistributer_HourChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            lbHour.Text = e.StrValue;
        }

        private void TimeDistributer_MinuteChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            lbMinute.Text = e.StrValue;
        }

        private void TimeDistributer_SecondChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            lbSecond.Text = e.StrValue;
        }

        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;
        private double opacityVar;

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
            foreach (var lb in lbTimes)
            {
                lb.Font = new Font(lb.Font.FontFamily, size);
            }
        }

        public void ChangeClockFontColor(Color color)
        {
            //BackColor = GetSimilarColor(color);
            //TransparencyKey = BackColor;

            foreach (var lb in lbTimes)
            {
                //lb.BackColor = BackColor;
                lb.ForeColor = color;
            }
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.Controls[i].BackColor = i % 2 == 0 ?  Color.RosyBrown : Color.Aquamarine;
            }
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
            foreach (var lb in lbTimes)
            {
                lb.BackColor = SystemColors.Control;
            }
            Opacity = 0.5;
            SetPenetrate();
        }

        public void DisableEditMode()
        {
            foreach (var lb in lbTimes)
            {
                ChangeClockFontColor(lb.ForeColor);
            }
            Opacity = opacityVar;
        }

        public void ChangeClockFont(Font font)
        {
            foreach (var lb in lbTimes)
            {
                lb.Font = new Font(font.FontFamily, lb.Font.Size);
            }
        }

        public void ResizeWindow()
        {
            ResizeWindow(lbHour.Font);
        }

        public void ResizeWindow(Font font)
        {
            var graphics = CreateGraphics();
            int numberWidth = (int)Math.Ceiling(graphics.MeasureString("88", font).Width);
            int colonWidth = (int)Math.Ceiling(graphics.MeasureString(":", font).Width);
            int height = (int)Math.Ceiling(graphics.MeasureString("88", font).Height);
            ResizeWindowSize(numberWidth,colonWidth,height);
            ResizeLabelSize(numberWidth,colonWidth,height);
        }

        private void ResizeWindowSize(int numberWidth,int colonWidth,int height)
        {
            Width = numberWidth * 3 + colonWidth * 2;
            tableLayoutPanel.Width = Width;
            Height = height;
            tableLayoutPanel.Height = Height;
        }

        private void ResizeLabelSize(int numberWidth, int colonWidth, int height)
        {
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                tableLayoutPanel.ColumnStyles[i].Width = i % 2 == 0 ? numberWidth : colonWidth;
            }
            foreach (var lb in new Label[]{lbHour,lbMinute,lbSecond})
            {
                lb.Height = height;
                lb.Width = numberWidth;
            }
            
            foreach (var lb in new Label[]{lbColon1,lbColon2})
            {
                lb.Height = height;
                lb.Width = colonWidth;
            }
        }

        public void ChangeOpacity(int num)
        {
            opacityVar = ((double)num) / 100;
            Opacity = opacityVar;
        }

        private string GetDisplayContent()
        {
            return DigitalProcess(DateTime.Now.Hour) + ":" + DigitalProcess(DateTime.Now.Minute) + ":" +
                   DigitalProcess(DateTime.Now.Second);
        }

        private string DigitalProcess(int digit)
        {
            if (digit < 10) return "0" + digit;
            return "" + digit;
        }
    }
}
