/*
 Используя библиотеку статических методов «System.Math» создать 
 делегаты для работы с аргументами типа double и вычисления значения 
 по формуле:
 
Формулу необходимо вычислить, используя соответствующие делегаты:
•	DelAbs – делегат для функции «Модуль»
•	DelSqrt – делегат для функции «Квадратный корень»
•	DelLogN – делегат для функции «Логарифм по основанию N»
•	DelPow – делегат для функции «Степенная функция» (возведение в степень) 
Делегаты должны принимать в качестве параметров и возвращать после исполнения значение типа “Double”.
Проверить вычисления по формуле, используя методы из System.Math.

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate double DelAbs(double x);
    delegate double DelSqrt(double x);
    delegate double DelLogN(double x);
    delegate double DelLog10(double x);
    delegate double DelPow(double x, double y);
    class s9_1_1_SimpleDelegate
    {
        public static void Main()
        {
            DelAbs abs = Math.Abs;
            DelSqrt sqr = Math.Sqrt;
            DelLogN logN = Math.Log;
            DelLog10 log10 = Math.Log10;
            DelPow pow = Math.Pow;
            double X;
            Console.WriteLine("Input a number");
            Double.TryParse(Console.ReadLine(), out X);
            double Y1 = (1 - sqr(abs(logN(X)))+25e-5*log10(pow(X,2)))/
                        (logN(X)+.00025*log10(X));
            double Y2 = (1-Math.Sqrt(Math.Abs(Math.Log(X)))+25e-5*Math.Log10(X*X)) / 
                (Math.Log(X)+0.00025*Math.Log10(X));
            Console.WriteLine("A result with delegates - {0}, a result with Math class - {1}", Y1, Y2);
            Console.ReadKey();
        }
    }
}
