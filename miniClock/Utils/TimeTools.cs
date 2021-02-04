using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniClock.Utils
{
    public static class TimeTools
    {
        public static int GetHour(int timeSecond)
        {
            return timeSecond / 3600;
        }

        public static int GetMinute(int timeSecond)
        {
            return (timeSecond % 3600) / 60;
        }

        public static int GetSecond(int timeSecond)
        {
            return (timeSecond % 3600) % 60;
        }

        public static int GetTimeSecond(int hour, int minute, int second)
        {
            return hour * 3600 + minute * 60 + second;
        }
    }
}
