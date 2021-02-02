using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace miniClockT2.Utils
{
    public class TimeDistributer
    {
        private TimeDistributeEventHander distributeSecondHander, distributeMinuteHander, distributeHourHander;
        public event TimeDistributeEventHander SecondChanged
        {
            add
            {
                distributeSecondHander += value;
            }
            remove
            {
                distributeSecondHander -= value;
            }
        }
        public event TimeDistributeEventHander MinuteChanged
        {
            add
            {
                distributeMinuteHander += value;
            }
            remove
            {
                distributeMinuteHander -= value;
            }
        }
        public event TimeDistributeEventHander HourChanged
        {
            add
            {
                distributeHourHander += value;
            }
            remove
            {
                distributeHourHander -= value;
            }
        }

        private Timer timer;

        private int tempHour, tempMinute, tempSecond;

        public TimeDistributer()
        {
            InitTimer();
            SetTempTime();
        }

        private void InitTimer()
        {
            timer = new Timer(100);
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
                if(distributeSecondHander!=null)this.distributeSecondHander.Invoke(this,new TimeDistributerArgs(tempSecond));
                if (tempMinute != DateTime.Now.Minute)
                {
                    tempMinute = DateTime.Now.Minute;
                    if(distributeMinuteHander!=null)this.distributeMinuteHander.Invoke(this,new TimeDistributerArgs(tempMinute));
                    if (tempHour != DateTime.Now.Hour)
                    {
                        tempHour = DateTime.Now.Hour;
                        if(distributeHourHander!=null)this.distributeHourHander.Invoke(this,new TimeDistributerArgs(tempHour));
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

        private string DigitalProcess(int digit)
        {
            if (digit < 10) return "0" + digit;
            return "" + digit;
        }

        public int IntValue { get; }
        public string StrValue { get; }
    }

    public delegate void TimeDistributeEventHander(TimeDistributer distributer, TimeDistributerArgs e);
}
