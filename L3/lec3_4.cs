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
            Console.WriteLine("Enter 3 signed integer number");
            string num = Console.ReadLine();
            int intNum = Int32.Parse(num);
            int sum, pr, hun, dec, unt;
            //1st var:
            hun = intNum / 100;
            dec = (intNum % 100) / 10;
            unt = intNum % 10;
            sum = hun + dec + unt;
            pr = hun * dec * unt;
            Console.WriteLine("Variant1: The unit sum of {0} is {1}, the product is {2}", intNum, sum, pr);
            //2st var:
            //char c=num[0];
            sum = 0;
            pr = 1;
            foreach (char c in num)
            {
                sum += (int)Char.GetNumericValue(c); 
                pr *= (int)Char.GetNumericValue(c);

            }
            Console.WriteLine("Variant2: The unit sum of {0} is {1}, the product is {2}", intNum, sum, pr);

        }

    }
}