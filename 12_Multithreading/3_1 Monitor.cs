/*
 В Main создать несколько объектов, содержащих таймер. Каждый объект использует общий ресурс доступа к файлу 
 (один объект, содержащий логику работы с файлом). 
 Обработчик таймеров пытаются записать данные в файл.
Обеспечить раздельный доступ к объекту для записи в файл из разных обработчиков.
1) Реализовать вариант доступа через Monitor.Enter и Monitor.Exit (или конструкцию lock).

 */
using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp
{
    class TimerClass
    {
        public System.Timers.Timer timer;
        private string name;
        private int interval = 2000;
        StreamWriter sw;
        public TimerClass(string name,int interval,StreamWriter sw)
        {
            this.name = name;
            this.sw = sw;
            this.interval = interval;
            timer = new System.Timers.Timer();
            timer.Elapsed += onTimedEvent;
            timer.Interval = interval;
            timer.Start();
        }
        private void onTimedEvent(object source, ElapsedEventArgs e)
        {
            if (source is System.Timers.Timer)
            {
                System.Timers.Timer a = source as System.Timers.Timer;
                a.Stop();
                a.Interval = interval * 2;
            }

			Monitor.Enter(sw);
			Thread.Sleep(interval * 2);
			Console.WriteLine($"{name}, time{DateTime.Now.ToString()}");
			sw.WriteLine($"{name}, time{DateTime.Now.ToString()}");
			Monitor.Exit(sw);

            timer.Start();
            
        }
    }
    class Programm
    {
        
        static void Main()
        {
            StreamWriter sw = new StreamWriter("lec14_2_1_log.txt");
            //Monitor.Enter(sw);
            TimerClass T1 = new TimerClass("Timer 1",1000, sw);
            //Monitor.Exit(sw);
            TimerClass T2 = new TimerClass("Timer 2",500, sw);
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
            sw.Close();
        }
    }
}
