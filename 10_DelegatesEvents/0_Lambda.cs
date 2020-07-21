/*
1) Найти сумму и произведение цифр целого числа, которое вводит пользователь. Реализовать задачу с использованием лямбда выражения
2) Вводятся координаты (x;y) точки и радиус круга (r). Определить принадлежит ли данная точка кругу, если его центр находится в начале координат.
Реализовать задачу через лямбда-выражения.
4) Реализовать два лямбда-выражения, принимающие на вход два аргумента и возвращающие результат в первом случае bool для операций сравнения и 
double для арифметический операций над аргументами во втором выражении
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        //delegates
        delegate bool DelegateSPIntDigits(string num, out int sum, out int prod);//1)
        delegate bool DelegatePointInCircle(double x, double y, double r);//2)
        delegate bool DelegateTask4_1(double x, double y);//4)
        delegate double DelegateTask4_2(double x, double y);//4)
        static void Main()
        {
            //1)
            DelegateSPIntDigits SumProductIntDigits = (string num, out int sum, out int prod) =>
            {
                char[] digits = num.ToCharArray();
                sum = 0;
                prod = 1;
                foreach (char digit in digits)
                {
                    sum += Int32.Parse(Convert.ToString(digit));
                    prod *= Int32.Parse(Convert.ToString(digit));
                }
                return true;
            };
            //2)
            DelegatePointInCircle PointInCircle = (double x, double y, double r) => r * r <= (x * x + y * y);
            //4)
            DelegateTask4_1 Task4_1 = (double x, double y) => x > y;
            DelegateTask4_2 Task4_2 = (double x, double y) => x * x + y * y;
            
            //Executing methods
            //1)
            int s, p;
            Console.WriteLine("1)\nInput a number");
            string str = Console.ReadLine();
            bool b = SumProductIntDigits(str, out s, out p);
            Console.WriteLine($"Digit sum = {s}\nDigit product={p}\n");
            //2
            Console.WriteLine("2)\nInput point coordinates (x, y) and circle radius with center in original");
            double x = Double.Parse(Console.ReadLine());
            double y = Double.Parse(Console.ReadLine());
            double r = Double.Parse(Console.ReadLine());
            Console.WriteLine("This point is in circle: {0}\n", PointInCircle(x, y, r));
            //3
            Console.WriteLine("4)\nInput x and y");
            x = Double.Parse(Console.ReadLine());
            y = Double.Parse(Console.ReadLine());
            Console.WriteLine("x > y: {0}\nx2+y2={1:F2}", Task4_1(x, y), Task4_2(x, y));
        }
    }
}
