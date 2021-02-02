using System;
using System.Timers;

namespace miniClock.Utils
{
    public class TimeDistributer
    {
        private TimeDistributeEventHander distributeSecondHander, distributeMinuteHander, distributeHourHander;

        private int tempHour, tempMinute, tempSecond;

        private Timer timer;

        public TimeDistributer(int interval)
        {
            InitTimer(interval);
            SetTempTime();
        }

        public TimeDistributer()
        {
            InitTimer(100);
            SetTempTime();
        }

        public event TimeDistributeEventHander SecondChanged
        {
            add => distributeSecondHander += value;
            remove => distributeSecondHander -= value;
        }

        public event TimeDistributeEventHander MinuteChanged
        {
            add => distributeMinuteHander += value;
            remove => distributeMinuteHander -= value;
        }

        public event TimeDistributeEventHander HourChanged
        {
            add => distributeHourHander += value;
            remove => distributeHourHander -= value;
        }

        private void InitTimer(int interval)
        {
            timer = new Timer(interval);
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
        }

        private void SetTempTime()
        {
            tempHour = DateTime.Now.Hour;
            tempMinute = DateTime.Now.Minute;
            tempSecond = DateTime.Now.Second;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (tempSecond != DateTime.Now.Second)
            {
                tempSecond = DateTime.Now.Second;
                if (distributeSecondHander != null)
                    distributeSecondHander.Invoke(this, new TimeDistributerArgs(tempSecond));
                if (tempMinute != DateTime.Now.Minute)
                {
                    tempMinute = DateTime.Now.Minute;
                    if (distributeMinuteHander != null)
                        distributeMinuteHander.Invoke(this, new TimeDistributerArgs(tempMinute));
                    if (tempHour != DateTime.Now.Hour)
                    {
                        tempHour = DateTime.Now.Hour;
                        if (distributeHourHander != null)
                            distributeHourHander.Invoke(this, new TimeDistributerArgs(tempHour));
                    }
                }
            }
        }
    }

    public class TimeDistributerArgs : EventArgs
    {
        public TimeDistributerArgs(int timeValue)
        {
            IntValue = timeValue;
            StrValue = DigitalProcess(timeValue);
        }

        public int IntValue { get; }
        public string StrValue { get; }

        private string DigitalProcess(int digit)
        {
            if (digit < 10) return "0" + digit;
            return "" + digit;
        }
    }

    public delegate void TimeDistributeEventHander(TimeDistributer distributer, TimeDistributerArgs e);
}