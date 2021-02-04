using System;
using System.ComponentModel;
using System.Timers;

namespace miniClock.Utils
{
    public class TimeDistributer
    {
        private TimeDistributeEventHandler distributeSecondHandler, distributeMinuteHandler, distributeHourHandler;
        private TimeUpEventHandler timeUpHandler;

        private int tempHour, tempMinute, tempSecond, tempTimerSecond;

        private Timer timer;

        private TimeDistributerMode mode;
        private int countDownSeconds;
        private int timerInterval;

        public int CountDownSeconds
        {
            get => countDownSeconds;
            set
            {
                if (countDownSeconds >= 360000)
                {
                    throw new CountDownTimeOverflowException();
                }
                countDownSeconds = value;
            }
        }

        public int TimerInterval
        {
            get
            {
                if (mode != TimeDistributerMode.Clock)
                {
                    return 1000;
                }

                return timerInterval;
            }
            set => timerInterval = value;
        }

        public TimeDistributerMode Mode
        {
            get => mode;
            set
            {

                mode = value;
                switch (value)
                {
                    case TimeDistributerMode.Clock:
                    {
                        InitClockTimer();
                        break;
                    }
                    case TimeDistributerMode.CountTimer:
                    {
                        InitCountTimer();
                        break;
                    }
                    case TimeDistributerMode.CountDownTimer:
                    {
                        InitCountDownTimer();
                        break;
                    }
                }
            }
        }

        #region DefineEvent


        public event TimeDistributeEventHandler SecondChanged
        {
            add => distributeSecondHandler += value;
            remove => distributeSecondHandler -= value;
        }

        public event TimeDistributeEventHandler MinuteChanged
        {
            add => distributeMinuteHandler += value;
            remove => distributeMinuteHandler -= value;
        }

        public event TimeDistributeEventHandler HourChanged
        {
            add => distributeHourHandler += value;
            remove => distributeHourHandler -= value;
        }

        public event TimeUpEventHandler TimeUp
        {
            add => timeUpHandler += value;
            remove => timeUpHandler -= value;
        }

        #endregion

        public TimeDistributer(int interval,TimeDistributerMode mode)
        {
            TimerInterval = interval;
            Mode = mode;
        }

        public TimeDistributer()
        {
            TimerInterval = 100;
            Mode = TimeDistributerMode.Clock;
        }

        private void InitClockTimer()
        {
            SetDefaultClockTime();
            if(timer!=null)timer.Dispose();
            timer = new Timer(TimerInterval);
            timer.Elapsed += ClockTimer_Elapsed;
            timer.Start();
        }

        private void InitCountTimer()
        {
            SetDefaultCountTime();
            if (timer != null) timer.Dispose();
            timer = new Timer(TimerInterval);
            timer.Elapsed += CountTimer_Elapsed;
            timer.Start();
        }

        private void InitCountDownTimer()
        {
            SetDefaultCountDownTime();
            if (timer != null) timer.Dispose();
            timer = new Timer(TimerInterval);
            timer.Elapsed += CountDownTimer_Elapsed;
            timer.Start();
        }

        private void SetDefaultClockTime()
        {
            tempHour = DateTime.Now.Hour;
            tempMinute = DateTime.Now.Minute;
            tempSecond = DateTime.Now.Second;
        }

        private void SetDefaultCountTime()
        {
            tempTimerSecond = 0;
            tempHour = 0;
            tempMinute = 0;
            tempSecond = 0;
        }

        private void SetDefaultCountDownTime()
        {
            tempTimerSecond = CountDownSeconds;
            tempHour = TimeTools.GetHour(CountDownSeconds);
            tempMinute = TimeTools.GetMinute(CountDownSeconds);
            tempSecond = TimeTools.GetSecond(CountDownSeconds);
        }

        private void ClockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (tempSecond != DateTime.Now.Second)
            {
                tempSecond = DateTime.Now.Second;
                if (distributeSecondHandler != null)
                    distributeSecondHandler.Invoke(this, new TimeDistributerArgs(tempSecond));
                if (tempMinute != DateTime.Now.Minute)
                {
                    tempMinute = DateTime.Now.Minute;
                    if (distributeMinuteHandler != null)
                        distributeMinuteHandler.Invoke(this, new TimeDistributerArgs(tempMinute));
                    if (tempHour != DateTime.Now.Hour)
                    {
                        tempHour = DateTime.Now.Hour;
                        if (distributeHourHandler != null)
                            distributeHourHandler.Invoke(this, new TimeDistributerArgs(tempHour));
                    }
                }
            }
        }

        private void CountTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var tempTimer = tempTimerSecond;
            tempTimerSecond++;
            if (tempTimerSecond == 360000)
            {
                timer.Stop();
                return;
            }
            tempSecond = TimeTools.GetSecond(tempTimerSecond);
            if (distributeSecondHandler != null)
                distributeSecondHandler.Invoke(this, new TimeDistributerArgs(tempSecond));
            if (TimeTools.GetSecond(tempTimer) == 59)
            {
                tempMinute = TimeTools.GetMinute(tempTimerSecond);
                if (distributeMinuteHandler != null)
                    distributeMinuteHandler.Invoke(this, new TimeDistributerArgs(tempMinute));
                if (TimeTools.GetMinute(tempTimer) == 59)
                {
                    tempHour = TimeTools.GetHour(tempTimerSecond);
                    if (distributeHourHandler != null)
                        distributeHourHandler.Invoke(this, new TimeDistributerArgs(tempHour));
                }
            }
        }

        private void CountDownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (tempTimerSecond == 0)
            {
                if (timeUpHandler != null)
                {
                    timeUpHandler.Invoke(this,new TimeUpArgs(countDownSeconds));
                }
                timer.Stop();
            }
            else
            {
                var tempTimer = tempTimerSecond;
                tempTimerSecond--;
                tempSecond = TimeTools.GetSecond(tempTimerSecond);
                if (distributeSecondHandler != null)
                    distributeSecondHandler.Invoke(this, new TimeDistributerArgs(tempSecond));
                if (TimeTools.GetSecond(tempTimer) == 0)
                {
                    tempMinute = TimeTools.GetMinute(tempTimerSecond) ;
                    if (distributeMinuteHandler != null)
                        distributeMinuteHandler.Invoke(this, new TimeDistributerArgs(tempMinute));
                    if (TimeTools.GetMinute(tempTimer) == 0)
                    {
                        tempHour = TimeTools.GetHour(tempTimerSecond);
                        if (distributeHourHandler != null)
                            distributeHourHandler.Invoke(this, new TimeDistributerArgs(tempHour));
                    }
                }
            }
        }
    }

    public class CountDownTimeOverflowException : OverflowException
    {
        public override string Message => "CountDownTime cannot bigger than 359999s";
    }

    public enum TimeDistributerMode
    {
        Clock,CountTimer,CountDownTimer
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

    public class TimeUpArgs
    {
        public int CountDownSeconds { get; }

        public TimeUpArgs(int countDownSeconds)
        {
            CountDownSeconds = countDownSeconds;
        }
    }

    public delegate void TimeDistributeEventHandler(TimeDistributer distributer, TimeDistributerArgs e);

    public delegate void TimeUpEventHandler(TimeDistributer distributer, TimeUpArgs args);
}