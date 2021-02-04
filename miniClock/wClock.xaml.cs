﻿using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using miniClock.Utils;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using ContextMenu = System.Windows.Forms.ContextMenu;
using FlowDirection = System.Windows.FlowDirection;
using FontFamily = System.Windows.Media.FontFamily;
using MenuItem = System.Windows.Forms.MenuItem;
using Size = System.Windows.Size;

namespace miniClock
{
    /// <summary>
    ///     wClock.xaml 的交互逻辑
    /// </summary>
    public partial class wClock : Window
    {
        private readonly TextBlock[] lbTimes;
        private double opacityVar;
        private TimeDistributer timeDistributer;
        private Mode mode;
        private bool dotShow;

        public wClock()
        {
            InitializeComponent();
            lbTimes = new[] {lbSecond, lbMinute, lbHour, lbColon1, lbColon2};
            SetPenetrate();
            mode = Mode.FullClock;
            SetDefaultTime();
            InitDestributer();
        }

        private void InitDestributer()
        {
            timeDistributer = new TimeDistributer();
            timeDistributer.SecondChanged += TimeDistributer_ShowSecondChanged;
            timeDistributer.MinuteChanged += TimeDistributer_MinuteChanged;
            timeDistributer.HourChanged += TimeDistributer_HourChanged;
        }

        private void SetDefaultTime()
        {
            lbHour.Text = DigitalProcess(DateTime.Now.Hour);
            lbMinute.Text = DigitalProcess(DateTime.Now.Minute);
            lbSecond.Text = DigitalProcess(DateTime.Now.Second);
        }

        private void TimeDistributer_HourChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            Task.Run(() => { Dispatcher.Invoke(() => { lbHour.Text = e.StrValue; }); });
        }

        private void TimeDistributer_MinuteChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            Task.Run(() => { Dispatcher.Invoke(() => { lbMinute.Text = e.StrValue; }); });
        }

        private void TimeDistributer_ShowSecondChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            Task.Run(() => { Dispatcher.Invoke(() => { lbSecond.Text = e.StrValue; }); });
        }

        private void TimeDistributer_DotSecondChanged(TimeDistributer distributer, TimeDistributerArgs e)
        {
            Task.Run(() => { Dispatcher.Invoke(() =>
            {
                dotShow = !dotShow;
                lbColon1.Visibility = dotShow ? Visibility.Visible : Visibility.Hidden;
            }); });
        }


        public void ChangeClockFontColor(Brush brush)
        {
            //BackColor = GetSimilarColor(color);
            //TransparencyKey = BackColor;

            foreach (var lb in lbTimes)
                //lb.BackColor = BackColor;
                lb.Foreground = brush;
        }

        public void ChangeClockFontSize(int size)
        {
            if (size > 0)
            {
                foreach (var lb in lbTimes)
                    //lb.FontStyle = new Font(lb.Font.FontFamily, size);
                    lb.FontSize = size;
                ResizeWindow();
            }
        }

        public void ChangeClockFont(Font font)
        {
            foreach (var lb in lbTimes) lb.FontFamily = new FontFamily(font.Name);
            ResizeWindow();
        }

        private Size MeasureString(string candidate)
        {
            var formattedText = new FormattedText(
                candidate,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(lbHour.FontFamily, lbHour.FontStyle, lbHour.FontWeight, lbHour.FontStretch),
                lbHour.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                TextFormattingMode.Display);

            return new Size(formattedText.Width, formattedText.Height);
        }

        public void ChangeShowSecondSetting(Mode mode)
        {
            this.mode = mode;
            switch (mode)
            {
                case Mode.FullClock:
                {
                    timeDistributer.SecondChanged -= TimeDistributer_DotSecondChanged;
                    timeDistributer.SecondChanged += TimeDistributer_ShowSecondChanged;
                    break;
                }
                case Mode.WithoutSecondClock:
                {
                    timeDistributer.SecondChanged -= TimeDistributer_ShowSecondChanged;
                    timeDistributer.SecondChanged += TimeDistributer_DotSecondChanged;
                    break;
                }
            }
            ResizeWindow();
        }

        public void ResizeWindow()
        {
            Size size=new Size();
            switch (mode)
            {
                case Mode.FullClock:
                {
                    ShowSecondControler();
                    size = MeasureString("00:00:00");
                    break;
                }
                case Mode.WithoutSecondClock:
                {
                    CollapseSecondControler();
                    size = MeasureString("00:00");
                    break;
                }
            }
            Width = size.Width;
            Height = size.Height;
        }

        private void CollapseSecondControler()
        {
            if (lbSecond.Visibility == Visibility.Visible)
            {
                lbColon2.Visibility = Visibility.Collapsed;
                lbSecond.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowSecondControler()
        {
            if (lbSecond.Visibility == Visibility.Collapsed)
            {
                if (lbColon1.Visibility == Visibility.Hidden) lbColon1.Visibility = Visibility.Visible;
                lbColon2.Visibility = Visibility.Visible;
                lbSecond.Visibility = Visibility.Visible;
            }
        }

        public void ChangeOpacity(int num)
        {
            opacityVar = (double) num / 100;
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

        #region 鼠标穿透

        private const int WsExTransparent = 0x20;
        private const int GwlExstyle = -20;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        private void SetPenetrate()
        {
            SourceInitialized += delegate
            {
                var hwnd = new WindowInteropHelper(this).Handle;
                var extendedStyle = GetWindowLong(hwnd, GwlExstyle);
                SetWindowLong(hwnd, GwlExstyle, extendedStyle | WsExTransparent);
            };
        }

        #endregion

        public enum Mode
        {
            FullClock,WithoutSecondClock
        }
    }
}