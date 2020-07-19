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
            int a, b, c, max;
			Console.WriteLine("Enter 3 integer values"); 
			bool isInt1=Int32.TryParse(Console.ReadLine(), out a);
            bool isInt2=Int32.TryParse(Console.ReadLine(), out b);
            bool isInt3=Int32.TryParse(Console.ReadLine(), out c);
           
            if (isInt1&&isInt2&&isInt3)
            {
            	max=(a>b)?a:b;
            	max=(max>c)?max:c;
            	Console.WriteLine("Maximum value is {0:d}", max);
            }
		}
    }
}