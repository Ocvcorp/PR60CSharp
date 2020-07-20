using System;
using System.Collections.Generic;
using System.Text;
using GameClasses;

namespace ConsoleApp
{
    class Main_lab3_3
    {
        static void Main()
        {
            //start condition
            Point startPnt=new Point(0,0);
            HorseCarriage hc1 = new HorseCarriage("horse", startPnt);
            Car car1 = new Car("car", startPnt);
            Airplane air1 = new Airplane("airplane", startPnt);
            Boat b1 = new Boat("Boat", startPnt);
            Console.WriteLine("***************Initial condition********************");
            Console.WriteLine("{0,10}\t{1,11}\t{2,10}", "Vehicle", "Point", "Resource");
            hc1.showInfo();
            car1.showInfo();
            air1.showInfo();
            b1.showInfo();
            //after moving
            Point newPnt1 = new Point(10, 10);
            Point newPnt2 = new Point(-100, 100);
            Point newPnt3 = new Point(1500, 330);
            Point newPnt4 = new Point(50, 10);
            hc1.move(newPnt1);
            car1.move(newPnt2);
            air1.move(newPnt3);
            b1.move(newPnt4);

            Console.WriteLine("********************After moving**********************");
            Console.WriteLine("{0,10}\t{1,11}\t{2,10}", "Vehicle", "Point", "Resource");
            hc1.showInfo();
            car1.showInfo();
            air1.showInfo();
            b1.showInfo();
        }
    }
}
