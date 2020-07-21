using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace ConsoleApp
{
    class MyTimer
    {
        public System.Timers.Timer timer;
        private int totalTime = 0;
        private int startTime = DateTime.Now.Minute*60+DateTime.Now.Second;
        private int interval = 2000;
        public MyTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += onTimedEvent;
            timer.Elapsed += onTimedEventSum;
            timer.Interval = interval;
            timer.Start();
        }
        private void onTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Start time{DateTime.Now.ToString()}");
            if (source is System.Timers.Timer)
            {
                System.Timers.Timer a = source as System.Timers.Timer;
                a.Stop();
                a.Interval = interval*2;
            }
            System.Threading.Thread.Sleep(interval*2);
            Console.WriteLine($"Current time{DateTime.Now.ToString()}");
            timer.Start();
        }
        private void onTimedEventSum(object source, ElapsedEventArgs e)
        {
            totalTime = DateTime.Now.Minute * 60 + DateTime.Now.Second-startTime;
            
            Console.WriteLine($"Operating time: {totalTime} sec");
        }
    }
    class Programm
    {
        public static void Main()
        {
            MyTimer T = new MyTimer();
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

    }
}
