using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public static class Program 
    {
        public enum figure
        {
        	triangle,
        	rectangle,
        	circle
        }
        
        public static void Main() 
        {           
            Console.WriteLine("Please, select from fugure variant:\n0 - triangle;\n1 - rectangle;\n2 - circle");
            figure fg;
            double a=0, b=0, c=0, r=0, S=0, p=0;
            bool ab = false, bb = false,  cb=false;
            int v;
            ab = Int32.TryParse(Console.ReadLine(), out v);
            if (ab)
            {
                fg = (figure)v;
                switch (fg)
                {
                    case figure.triangle:
                        Console.WriteLine("Input 3 triangle sides:");
                        ab = Double.TryParse(Console.ReadLine(), out a);
                        bb = Double.TryParse(Console.ReadLine(), out b);
                        cb = Double.TryParse(Console.ReadLine(), out c);
                        if (ab && bb && cb)
                        {
                            p = (a + b + c) / 2;
                            S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                            Console.WriteLine("Triangle square is{0:F2} m2", S);
                        }
                        break;
                    case figure.rectangle:
                        Console.WriteLine("Input 2 rectangle sides:");
                        ab = Double.TryParse(Console.ReadLine(), out a);
                        bb = Double.TryParse(Console.ReadLine(), out b);
                        if (ab && bb)
                        {
                            S = a * b;
                            Console.WriteLine("Rectangle square is{0:F2} m2", S);
                        }
                        break;
                    case figure.circle:
                        Console.WriteLine("Input a circle radius:");
                        ab = Double.TryParse(Console.ReadLine(), out r);
                        if (ab)
                        {
                            S = Math.PI * r * r;
                            Console.WriteLine("Circle square is{0:F2} m2", S);
                        }
                        break;
                }
            }
           
           
        }
    }
}