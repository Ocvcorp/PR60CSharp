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
            Console.WriteLine("Calculator");
            double a, b;
            int op;
            do
            {
                Console.WriteLine("Enter 2 numbers and the operation: +, -, *, /");
                a = Double.Parse(Console.ReadLine());
                b = Double.Parse(Console.ReadLine());
                op = (int)Console.ReadKey().Key;
                switch(op)
                {
                    case 107://'+'
                        Console.WriteLine("\n{0}+{1}={2}",a,b,a + b);
                        break;
                    case 109://'-'
                        Console.WriteLine("\n{0}-{1}={2}", a, b, a - b);
                        break;
                    case 111://'/'
                        if (b!=0)
                        {
                            Console.WriteLine("\n{0}/{1}={2}", a, b, a / b);
                        }
                        else
                        {
                            Console.WriteLine("Dividing by zero!");
                        }
                        break;
                    case 106://'*'
                        Console.WriteLine("\n{0}*{1}={2}", a, b, a * b);
                        break;
                }
                if ((op!=107)&& (op != 109)&& (op != 111)&& (op != 106) && (op != 96))
                {
                    Console.WriteLine("\nInvalid operation");
                }
                if (op==96)
                {
                    break;
                }
                
            } while (true);
        }

    }
}