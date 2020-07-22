/*
1) Запустить метод в отдельном потоке. Проверять в основном потоке  статус запущенного потока.
2) Запустить метод в отдельном потоке. Дождаться окончания выполнения потока в основном потоке при помощи метода Join()
3) Повторить задачи 1 и 2 с использованием лямбда-выражений для передачи блока кода в поток.

 */
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    class Program
    {
        //1)
        static void Method()
        {
            int count = 0;
            Console.WriteLine("Method Runs ");
            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("Method Runs "+(count+1));
            } while (++count < 10);
            Console.WriteLine("Method Stops");
        }
        //2)
        static void JoinMethod()
        {
            int count = 0;
            Console.WriteLine("Join Method Runs ");
            do
            {
                Thread.Sleep(1500);
                Console.WriteLine("Join Method Runs " + (count + 1));
            } while (++count < 10);
            Console.WriteLine("Join Method Stops");
        }
        static void Main()
        {
            Console.WriteLine("Main thread runs");
            //1)
            Thread backThread = new Thread(Method);
            Thread backBackMethod = new Thread(JoinMethod);
            Console.WriteLine("Is thread alive? " + backThread.IsAlive);
            backThread.Start();
            backBackMethod.Start();
            Console.WriteLine("Is thread alive? " + backThread.IsAlive);
            Thread.Sleep(2000);
            Console.WriteLine("Is thread alive? " + backThread.IsAlive);
            //2)
            backThread.Join();
            backBackMethod.Join();
            //3)

            Thread lambdaThread = new Thread(() => {
                for (int i = 1; i < 6; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Lamda Thread {i}");
                }
                                                    }
                                            );
            lambdaThread.Start();           
            Console.WriteLine("Is lambda thread alive? " + lambdaThread.IsAlive);
            Thread.Sleep(2000);
            Console.WriteLine("Is lammbda thread alive? " + lambdaThread.IsAlive);
            lambdaThread.Join();
        }
    }
}
