using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1
{
    class Program
    {
        static void Timeout(object sender, string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            AlarmClock timer = new AlarmClock("时间到");
            timer.Timing += Timeout;
            timer.DoTiming(0, 0, 5);
            Console.ReadLine();
        }
    }

    public delegate void AlarmEventHandler(object sender, string message);
    public class AlarmClock
    {
        private TimeSpan duration;
        private String message;

        public event AlarmEventHandler Timing;
        
        public AlarmClock(String message = "")
        {
            this.message = message;
        }
        public void DoTiming(int hours, int minutes, int seconds)
        {
            duration = new TimeSpan(hours, minutes, seconds);
            DateTime starttime = DateTime.Now;
            while(GetDuration(starttime)<duration)
            {
                
            }
            if (Timing != null)
            {
                Timing(this, message);
            }
        }
        public TimeSpan GetDuration(DateTime starttime)
        {
            TimeSpan begintime = new TimeSpan(starttime.Ticks);
            TimeSpan nowtime = new TimeSpan(DateTime.Now.Ticks);
            return nowtime - begintime;
        }
    }
}
