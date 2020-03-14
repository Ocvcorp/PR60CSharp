using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class MainLab4
    {
        static void Main()
        {
            //1.
            //point
            Point p1;
            Point.CountInfo();
            p1 = new Point(1.0, 2.0);
            Point p2 = new Point(3.0, 4.0);
            Point.CountInfo();
            //line
            {
                Point p3 = new Point(1.0, 2.0);
                Line line1 = new Line(p3, p2);
                Point.CountInfo();
                
            }
            
            Point.CountInfo();
            //square
            Square square1 = new Square(4.0, p1);
            //Circle
            Circle circle1 = new Circle(2.0, p1);
            Point.CountInfo();

            //2.
            Deposit dep = new Deposit();            
            dep.showInfo();
            dep.finalSum();
            Deposit dep2 = new Deposit("07.08.2021", "Sara", 3000.00);
            dep2.showInfo();
            dep2.finalSum();
            //3.
            Console.WriteLine("Factorial 4 = {0}", SomeMathFuncs.Fact(4));
            Console.WriteLine("Reciprocal of 4 = {0}", SomeMathFuncs.Reciprocal(4));
            Console.WriteLine("Fractional of 1.25 = {0}", SomeMathFuncs.FracPart(1.25));
            Console.WriteLine("A number 4 is odd {0} or even {1}", SomeMathFuncs.IsOdd(4), SomeMathFuncs.IsEven(4));
            Console.WriteLine("A cubic roots of 8 = {0:F3}, 4 = {1:F3}", SomeMathFuncs.Crt(8),SomeMathFuncs.Crt(4));
            Console.WriteLine("30 degree is {0:F2} radian, and pi/2 radian is {1:F2} degree", SomeMathFuncs.DegToRad(8),SomeMathFuncs.RadToDeg(1.57));
            Console.WriteLine("128 is a power of 2: {0}, 99 is a power of 2: {1}", SomeMathFuncs.BinaryDigit(1024), SomeMathFuncs.BinaryDigit(1000));
            
        }
    
    }
}
