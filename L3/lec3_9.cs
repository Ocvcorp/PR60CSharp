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
            double a, b, c;
			Console.WriteLine("Enter 3 triangle sides"); 
			bool isCorr1=Double.TryParse(Console.ReadLine(), out a);
            bool isCorr2=Double.TryParse(Console.ReadLine(), out b);
			bool isCorr3=Double.TryParse(Console.ReadLine(), out c);

            if (isCorr1&&isCorr2&&isCorr3)
            {
            	if (a+b>c)
            	{
            		Console.WriteLine("The triangle exsists and ...");
					if ((a==b)&&(b==c))
					{
						Console.WriteLine("it has all sides equal");						
					}
					else if (a==b||a==c||b==c)
					{
						Console.WriteLine("it has two sides equal");					
					}
					else
					{
						Console.WriteLine("it has all sides being different from each other");					
					}
            	}
            	else
            	{
					Console.WriteLine("The triangle doesn't exsist");
				}
            	
            }
		}
    }
}