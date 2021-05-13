using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Delegation
{
    class Events
    {
        public static void MainEventsRun()
        {
            Alarm alarm = new Alarm();
            alarm.Setup(DateTime.Now.AddSeconds(10));

            alarm.AlarmEvent += AlarmEvent_Handler;
            alarm.AlarmEventOccured += Alarm_AlarmEventOccured;

            Console.WriteLine("Waiting for an event");
            Console.ReadLine();

            //when finished working with timer, unsubscribe!
            alarm.AlarmEvent -= AlarmEvent_Handler;
            alarm.AlarmEventOccured -= Alarm_AlarmEventOccured;
        }

        private static void Alarm_AlarmEventOccured(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.DeferInterval);
        }

        private static void AlarmEvent_Handler(object sender, EventArgs e)
        {
            Console.WriteLine("It's time to get up!");
        }
    }


    //todo
    //explain the difference between different timers in .net
    public class Alarm
    {
        public event EventHandler AlarmEvent;

        public event EventHandler<TimerEventArgs> AlarmEventOccured;

        private Timer timer;

        //ctor with conditions for sure
        //omit time-zone related problems

        public void Setup(DateTime dt)
        {
            timer = new Timer();
            timer.Elapsed += timer_Elapsed;

            var interval = dt - DateTime.Now;
            timer.Interval = interval.TotalMilliseconds;
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnAlarm();
            timer.Stop();

        }

        protected virtual void OnAlarm()
        {
            if (AlarmEvent != null)
                AlarmEvent(this, EventArgs.Empty);

            if (AlarmEventOccured != null)
                AlarmEventOccured(this, new TimerEventArgs(DateTime.Now, TimeSpan.FromMinutes(10)));
        }
    }

    public class TimerEventArgs
    {
        public TimerEventArgs(DateTime timeOfEvent) : this(timeOfEvent, TimeSpan.FromMinutes(5))
        {
        }

        public TimerEventArgs(DateTime timeOfEvent, TimeSpan deferInterval)
        {
            TimeOfEvent = timeOfEvent;
            DeferInterval = deferInterval;
        }

        public DateTime TimeOfEvent { get; }
        public TimeSpan DeferInterval { get; }
    }
}
