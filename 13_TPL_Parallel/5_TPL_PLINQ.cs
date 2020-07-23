/*
 1.	Реализовать все описанные случаи, используя синтаксические элементы LINQ:
•	Запрос и вывод на экран товарных запасов — список товаров, запасы которых исчерпались на складе; 
2.	Источник данных – это массив элементов или коллекция. Размер – не менее 20 строк.
3.	В каждом случае использовать составной тип данных (класс или структуру) для хранения строк таблиц. 
Создать не менее 5-ти полей (членов-переменных примитивного типа) для каждого составного типа данных.
4.	Создать сложные запросы для выбора данных из источника по нескольким полям.
5.	Использовать методы AsParallel, AsOrdered библиотеки TPL для PLINQ, чтобы обеспечить параллелизм данных внутри запроса.
6.	Организовать отмену задачи в запросе для случая некорректно введенных условий выбора строк источника данных.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Goods
    {
        public int number;
        public string name;
        public string category;
        public double price;
        public int qnty;
        public static void PrintStore(IEnumerable<Goods> choosing, string preText="")
        {
            Console.WriteLine(preText+"\nNumber\tName\tCategory\tPrice\tQuantity");
            foreach (Goods g in choosing)
                Console.WriteLine("{0}\t{1}\t{2}\t{3:F2}\t{4}",
                    g.number,g.name,g.category, g.price, g.qnty);
        }
        
    }

    class lab15_1_TPL_PLINQ
    {        
        static void Main(string[] args)
        {
            List<Goods> store = new List<Goods>()
            {
                new Goods { number=01, name="Apples", category="Fruits", price=10.2, qnty=200},
                new Goods { number=02, name="Bananas", category="Fruits", price=15.2, qnty=0},
                new Goods { number=03, name="PineApples", category="Fruits", price=110.2, qnty=150},
                new Goods { number=04, name="Peach", category="Fruits", price=10.3, qnty=220},
                new Goods { number=05, name="Strawberry", category="Fruits", price=15.6, qnty=0},
                new Goods { number=06, name="Raspberry", category="Fruits", price=18.3, qnty=0},
                new Goods { number=07, name="Milk", category="MilkProducts", price=20.2, qnty=1200},
                new Goods { number=08, name="Youguart", category="MilkProducts", price=5.11, qnty=0},
                new Goods { number=09, name="Butter", category="MilkProducts", price=16.1, qnty=220},
                new Goods { number=10, name="Cheese", category="MilkProducts", price=21.3, qnty=230},
                new Goods { number=11, name="Buckweet", category="Porrigies", price=15.21, qnty=2000},
                new Goods { number=12, name="Rise", category="Porrigies", price=11.1, qnty=150},
                new Goods { number=13, name="Hercules", category="Porrigies", price=13.9, qnty=0},
                new Goods { number=14, name="Manka", category="Porrigies", price=9.21, qnty=200},
                new Goods { number=15, name="Saussage", category="Meat Products", price=22.2, qnty=0},
                new Goods { number=16, name="Bekon", category="Meat Products", price=25.0, qnty=2000},
                new Goods { number=17, name="Ham", category="Meat Products", price=33.3, qnty=2001},
                new Goods { number=18, name="Salo", category="Meat Products", price=51.2, qnty=0},
                new Goods { number=19, name="Carbonade", category="Meat Products", price=43.2, qnty=2200},
                new Goods { number=20, name="Sordelki", category="Meat Products", price=22.7, qnty=10}
            };

            //1.choose 0 remain in store
            var res1 = from g in store
                       where g.qnty == 0
                       select g;
            Goods.PrintStore(res1, "Choosing items with no remain");
            //2.choose item with price>15 from MilkProducts
            var res2 = from g in store
                       where g.category == "MilkProducts" 
                       where g.price > 15.0
                       select g;
            Goods.PrintStore(res2, "Choosing items from MilkProducts with price 15.0+");
            //3.choose 0 remain in store + asParallel+ asOrdered
            var resPar = from g in store.AsParallel().AsOrdered()
                         where g.qnty == 0
                         select g;
            Goods.PrintStore(res1, "Choosing items with no remain in Parallel mode (order saved)");
            //4.task cancel if incorrect choose condition
            double maxPrice = -20.2;
            CancellationTokenSource cancelTokSrc = new CancellationTokenSource();
            var res4 = from g in store.AsParallel().AsOrdered().WithCancellation(cancelTokSrc.Token)
                       where g.price < maxPrice
                       select g;
            Task cancelTsk = Task.Factory.StartNew(() =>
            {
                if (maxPrice<=0) 
                    cancelTokSrc.Cancel();
            });
            try
            {
                Goods.PrintStore(res4, "Choosing items with price less then "+maxPrice);
            }
            catch (OperationCanceledException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (AggregateException exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                cancelTsk.Wait();
                cancelTokSrc.Dispose();
                cancelTsk.Dispose();
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
