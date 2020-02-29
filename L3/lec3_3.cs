using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public static class Program 
    {
        
        public static void Main() 
        {           
            Console.WriteLine("Please, enter p1(x1,y1), p2(x2,y2)");
            double x1, y1, x2, y2, k, b;

            x1 = Double.Parse(Console.ReadLine());
            y1 = Double.Parse(Console.ReadLine());
            x2 = Double.Parse(Console.ReadLine());
            y2 = Double.Parse(Console.ReadLine());

            k = (y2 - y1) / (x2 - x1);
            b = y2 - k * x1;
                                   
            Console.WriteLine("Line equation is: Y = {0:F1}*X + {1:F2} ", k, b);
        }
    }
}