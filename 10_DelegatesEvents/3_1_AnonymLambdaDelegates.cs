/*
Изменить программу, которая была разработана в предыдущем задании, в двух возможных вариантах:
1.	С использованием анонимных методов в делегатах арифметических операций
2.	С использованием блочных лямбда выражений в делегатах арифметических операций
-----------------------Предыдущее задание---------------------------------------------------------
Используя делегаты и класс, организовать вычисление значения числа Y (без упрощения формулы): 
Y = ((A/X^A +A)*A- A)^A,          X=1;  A=3    
- Класс содержит методы, каждый из которых принимает на вход 2 параметра double, тип возврата - void. 
Второй параметр объявляется с ключевым словом ref и является результатом соответствующей операции над операндами.
- Каждый метод класса реализует одну математическую операцию (-   +  *  /  ^).
- Вызов методов для расчета значения Y реализовать при помощи делегатов в двух вариантах: 
для статических методов класса, для инкапсулированных методов объекта класса.
- Ввод значения Х и A сделать через консольный поток ввода в начале программы.
- Вычисление значения Y должно происходить автоматически - вызовом одного делегата, 
содержащим последовательный вызов необходимых методов (групповая адресация)
- Сделать проверку результата вычисления Y (простым вычислением по формуле в синтаксисе языка C#)
 
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public delegate void DelCalc(double x, ref double y);
    public class YCalc
    {
        
        public DelCalc Plus = (double x, ref double y)=>
          {
              y += x;
          };
        public DelCalc Minus = (double x, ref double y) =>
          {
              y -= x;
          };
        public DelCalc Multi = (double x, ref double y) =>
          {
              y *= x;
          };
        public DelCalc Devide = (double x, ref double y) =>
          {
              y = x / y;
          };
        public DelCalc Pow = (double x, ref double y) =>
          {
              y = Math.Pow(y, x);
          };
        //static methods
        public static DelCalc StatPlus = delegate (double x, ref double y)
          {
              y += x;
          };
        public static DelCalc StatMinus = delegate (double x, ref double y)
        {
            y -= x;
        };
        public static DelCalc StatMulti = delegate (double x, ref double y)
        {
            y *= x;
        };
        public static DelCalc StatDevide = delegate (double x, ref double y)
        {
            y = x / y;
        };
        public static DelCalc StatPow = delegate (double x, ref double y)
        {
            y = Math.Pow(y, x);
        };
    }
    public class Programm
    {
        public static void Main()
        {
            double X, A, Y1, Y2, Y3;
            Console.WriteLine("Input X, A");
            Double.TryParse(Console.ReadLine(), out X);
            Double.TryParse(Console.ReadLine(), out A);
            Y1 = X;//result throw delegates for static methods
            Y2 = X;//result throw delegates for examplars
            Y3 = Math.Pow(((A / Math.Pow(X, A) + A) * A - A), A);//for delegate using control 
           
            //static methods
            DelCalc yCalc1;
            DelCalc plus = YCalc.StatPlus;
            DelCalc minus = YCalc.StatMinus;
            DelCalc multi = YCalc.StatMulti;
            DelCalc devide = YCalc.StatDevide;
            DelCalc pow = YCalc.StatPow;

            yCalc1 = pow+devide+plus+multi+minus+pow;
            yCalc1(A, ref Y1);

            //examplar methods
            DelCalc yCalc2;
            YCalc yc = new YCalc();
            DelCalc plus1 = yc.Plus;
            DelCalc minus1 = yc.Minus;
            DelCalc multi1 = yc.Multi;
            DelCalc devide1 = yc.Devide;
            DelCalc pow1 = yc.Pow;

            yCalc2 = pow1 + devide1 + plus1 + multi1 + minus1 + pow1;
            yCalc2(A, ref Y2);

            Console.WriteLine("The result of Y = ((A/X^A +A)*A- A)^A calculation:\n{0:F3} - with delegates for static methods\n{1:F3} - with delegates for examplar methods\n{2:F3} - with System.Math methods\nX={3},A={4}",
                                Y1,Y2,Y3,X,A);

        }

    }
}
