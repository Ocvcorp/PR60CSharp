/*
1.	Реализовать параллельный ввод-вывод для четырех различных текстовых файлов 
с использованием средств параллельных запросов PLINQ.
•	имена файлов 1.txt, 2.txt, 3.txt, 4.txt
•	каждый файл содержит не менее 20 строк
•	каждая строка содержит не менее 20 случайных двузначных натуральных чисел 
2.	Необходимо выполнить параллельный ввод каждой очередной строки из каждого файла в отдельной задаче, 
генерируемые общим параллельным запросом
3.	Рассчитать для каждой строки абсолютное значение полусуммы минимального и максимального элементов 
4.	Сохранить последовательность данных источника с использованием метода AsOrdered
5.	Осуществить расчет полусуммы с минимальной задержкой потока 100 мс
6.	Вывести в консоль значения полусуммы каждой строки каждого из 4-х файлов, объединяя их в одну строку, 
и разделяя запятыми. Например:
23, 5, 41, 90 
34, 6, 76, 24
13, 7, 76, 77
..................... - общее количество строк - не менее 20 
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class lab15_2_Parallel_PLINQ
    {
        static void FilesGenerate()
        {
            StreamWriter sw;
            Random rnd=new Random();
            string fileline;
            for (int i=1; i<5; i++)
            {
                sw = new StreamWriter(i + ".txt");
                for (int j = 0; j < 20; j++)
                {
                    fileline = "";
                    for (int k = 0; k < 20; k++)
                    {
                        fileline += (rnd.Next(10, 99).ToString() + " ");
                    }
                    fileline += (rnd.Next(10, 99).ToString());
                    sw.WriteLine(fileline);
                }
                sw.Close();
            }
        }
        static double GetSemiSum(string strNumbers, bool isDelayed)
        {
            double sum = 0;
            if (strNumbers!=null)
            {
                foreach (var num in strNumbers)
                    sum += (double)num;
                if (isDelayed)
                    Thread.Sleep(100);               
                return sum / 2;
            }
            return 0;
        }
        static void Main(string[] tArgs)
        {
            //FilesGenerate();//files generating
            
            StreamReader[] files = 
                {
                    new StreamReader("1.txt"),
                    new StreamReader("2.txt"),
                    new StreamReader("3.txt"),
                    new StreamReader("4.txt")
                };
            ConcurrentBag<string> concurrentBag;
            for (int i=0;i<20;i++)
            {
                concurrentBag = new ConcurrentBag<string>();
                var query = from q in files.AsParallel()
                            select GetSemiSum(q.ReadLine(), true).ToString();
                query.ForAll(e => concurrentBag.Add(e));
                Console.WriteLine(string.Join(", ", concurrentBag.ToArray()));
            }
            foreach (var f in files)
                f.Close();

            Console.WriteLine("In order");
            StreamReader[] files3 =
                {
                    new StreamReader("1.txt"),
                    new StreamReader("2.txt"),
                    new StreamReader("3.txt"),
                    new StreamReader("4.txt")
                };

            for (int i = 0; i < 20; i++)
            {
                concurrentBag = new ConcurrentBag<string>();
                var query = from q in files3.AsParallel().AsOrdered<StreamReader>()
                            select GetSemiSum(q.ReadLine(), true).ToString();
                string[] data = query.ToArray();
                Console.WriteLine(string.Join(", ", data));
            }
            foreach (var f in files3)
                f.Close();

            Console.WriteLine("Checking without parallel computing");
            StreamReader[] files2 =
                {
                    new StreamReader("1.txt"),
                    new StreamReader("2.txt"),
                    new StreamReader("3.txt"),
                    new StreamReader("4.txt")
                };
            int k=0;
            string[,] vs = new string[20, 4];
            foreach (StreamReader f in files2)
            {                
                for (int i=0;i<20;i++)
                {             
                    vs[i, k] = GetSemiSum(f.ReadLine(), false).ToString();
                }
                f.Close();
                k++;
            }
            for (int i=0;i<20;i++)
            {
                Console.WriteLine("{0:F1}, {1:F1}, {2:F1}, {3:F1}", vs[i, 0], vs[i, 1], vs[i, 2], vs[i, 3]);
            }
            Console.ReadKey();
        }
    }
}
