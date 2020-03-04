using System;
using System.Globalization;

namespace ConsoleApp
{
    class Lab2_1
    {
        static void Main(string[] args)
        {
            //point
            Point p1 = new Point(1.0, 2.0);
            p1.showInfo();
            Point p2 = new Point(3.0, 4.0);
            Console.WriteLine("The distance to p2({0:F2},{1:F2} is {2:F3})",p2.X,p2.Y,p1.Distance(p2.X,p2.Y));
            //line
            Line line1 =new Line(p1, p2);
            line1.showInfo();
            Point p3 = new Point(2, 3);
            Point p4 = new Point(6, 3);
            line1.isPointOnLine(p3);
            line1.isPointOnLine(p4);
            //square
            Square square1 = new Square(4.0, p1);
            square1.showInfo();
            square1.isPointInside(p3);
            square1.isPointInside(p4);
            //Circle
            Circle circle1 = new Circle(2.0, p1);
            circle1.showInfo();
            circle1.isPointInside(p3);
            circle1.isPointInside(p4);
            //Rectangle
            Rectangle rect1 = new Rectangle(4.1, 2.0, p1);
            rect1.showInfo();
            rect1.isPointInside(p2);
            rect1.isPointInside(p4);
            //Rhomb
            Rhomb rhomb1 = new Rhomb(4, 8, p2);
            rhomb1.showInfo();
            rhomb1.isPointInside(p3);
            rhomb1.isPointInside(p1);
        }
    }
}
