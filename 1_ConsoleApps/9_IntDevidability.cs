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
            int a, b, res, mod;
			Console.WriteLine("Enter 2 integer values"); 
			bool isInt1=Int32.TryParse(Console.ReadLine(), out a);
            bool isInt2=Int32.TryParse(Console.ReadLine(), out b);

            if (isInt1&&isInt2)
            {
            	res=a/b;
            	mod=a%b;
            	if (mod>0)
            	{
            		Console.WriteLine("The value {0} can't be divided by {1} with null mode\nthe result is {2},the mode is {3}",
            		a, b, res, mod);
            	}
            	else
            	{
            		Console.WriteLine("The value {0} can be divided by {1} with null mode\nthe result is {2}",
            		a, b, res);
            	}
            	
            }
		}
    }
}