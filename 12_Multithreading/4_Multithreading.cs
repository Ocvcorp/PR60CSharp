/*
Реализовать создание и запуск 6-ти дочерних потоков из основного потока Main программы, используя класс Thread, определенный в пространстве имен System.Threading.
•	Дочерние потоки формируют текстовый лог-файл с именем «threading_log.txt»
•	Печать в файл осуществляется при помощи объекта StreamWriter, который существует в течение всего времени работы программы до окончания процесса записи
•	Дочерние потоки синхронизируются при помощи механизма блокировки объекта StreamWriter
•	Дочерние потоки выводят в файл информацию о себе: имя потока, приоритет, хэш-код исполняемого контекста (свойство - ExecutionContext, метод - GetHashCode()) , время существования потока в миллисекундах
•	Выводить информацию в лог-файл о дочернем потоке с четным номером через каждые 700 миллисекунд, и о дочернем потоке с нечетным номером через каждые 900 миллисекунд
•	Основная программа ожидает завершения дочерних потоков, после чего закрывается. Время существования дочерних потоков – 10 секунд.
•	Выводить в консоль и лог-файл информацию о создании и завершении всех дочерних потоков, а также основного потока программы

 */
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp
{
    class MyThread
    {
        public int count = 0;
        public Thread Thrd;
        // New thread constructs
        public MyThread(string name)
        {
            Thrd = new Thread(this.Run);
            Thrd.Name = name;
            Thrd.Start();
        }
        // Start thread execution
        void Run()
        {
            do
            {
                Thread.Sleep(1);
                count++;
            } while (count < 10000);
        }
        public void Log(StreamWriter sw, TimerThread t)
        {
            sw.WriteLine("Name:" + Thrd.Name + " Priority: " + Thrd.Priority +
                                          " HashCode:" + Thrd.ExecutionContext.GetHashCode() + " TimeLive:" + t.mls);
        }
    }
    class TimerThread
    {
        int tick = 0;
        public int mls = 0;
        public Thread thrdTimer;
        public TimerThread(string name)
        {
            thrdTimer = new Thread(this.Run);
            thrdTimer.Name = name;
            thrdTimer.Priority = ThreadPriority.Highest;
        }
        void Run(object Sec)
        {
            do
            {
                Thread.Sleep(1);
                tick++;
                mls = tick;
            }
            while (tick / 1000 < (int)Sec);
            if (tick / 1000 == (int)Sec)
                Console.WriteLine("The timer " + this.thrdTimer.Name + " time -" + (int)Sec + " sec- elapsed and timer's thread finished");
        }

    }
    class Programm
    {
        
        public static void Main()
        {
            Console.WriteLine("Base thread (Main) starts");
            TimerThread timerThread = new TimerThread("MyTimer");
                Console.WriteLine("Timer thread starts");
            StreamWriter sw = new StreamWriter("threading_log.txt");
                sw.WriteLine("Base thread (Main) starts");
                sw.WriteLine("Timer thread starts");
            MyThread[] threads = new MyThread[6];
            for (int i=0; i<6; i++)
            {
                threads[i] = new MyThread("'Child thread #"+(i+1)+"'");
                sw.WriteLine(threads[i].Thrd.Name+" starts");
                Console.WriteLine(threads[i].Thrd.Name + " starts");
            }
            timerThread.thrdTimer.Start(10);//10 sec timer starts                        
            int e = 1, o = 2;
            do
            {
                Thread.Sleep(1);
                if (timerThread.mls % 700 == 0)
                {
                    lock(sw)
                    {
                        threads[e - 1].Log(sw, timerThread);
                        e += 2;
                        if (e > 5) e = 1;
                    }
                }
                if (timerThread.mls % 900 == 0)
                {
                    lock (sw)
                    {
                        threads[o - 1].Log(sw, timerThread);
                        o += 2;
                        if (o > 6) o = 2;
                    }
                }

            } while (timerThread.thrdTimer.IsAlive);
            //waiting all child threads
            foreach (MyThread thr in threads)
            {
                thr.Thrd.Join();               
            }
            sw.WriteLine("---------------------------------------------------");
            //threads finishing message
            for (int i=0; i<6;i++)
            {
                Console.WriteLine("'Child thread #" + (i + 1) + "' finished");
                sw.WriteLine("'Child thread #" + (i + 1) + "' finished");
            }
            sw.WriteLine("Base thread (Main) finished");
            Console.WriteLine("Base thread (Main) finished");
            sw.Close();  
        }
    }
}
