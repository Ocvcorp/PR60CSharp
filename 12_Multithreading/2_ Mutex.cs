/*
В Main создать и запустить несколько потоков. Каждый из запущенных потоков выполняет запись текста в файл.
С помощью мьютекса необходимо обеспечить, чтобы в один момент времени файл был доступен только для одного 
из запущенных потоков 
 */
using System;
using System.IO;
using System.Threading;


namespace ConsoleApp
{
    
    class MyThread
    {
        StreamWriter sw;
        string name;
        public Thread thrd;
        public static Mutex mtx=new Mutex();
        public MyThread(string name, StreamWriter sw)
        {
            this.name = name;
            this.sw = sw;
            thrd = new Thread(() =>
                    {
                        mtx.WaitOne();
                        for (int i=0;i<5;i++)
                        {
                            sw.WriteLine($"{name} in da file");
                            Console.WriteLine($"{name} in da Console :)");
                        }
                        mtx.ReleaseMutex();
                    }
                );
            thrd.Start();
        }
    }
    class Programm
    {
        
        static void Main()
        {
            StreamWriter sw = new StreamWriter("lec14_1_log.txt");
            MyThread thread1 = new MyThread("Thread #1", sw);
            Thread.Sleep(1);
            MyThread thread2 = new MyThread("Thread #2", sw);
            MyThread thread3 = new MyThread("Thread #3", sw);
            thread1.thrd.Join();
            thread2.thrd.Join();
            thread3.thrd.Join();
            sw.Close();
        }
    }
}
