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
            double a, b, c, D, x1, x2;
			Console.WriteLine("Enter a, b, c of quadrant equation"); 
			bool isCorr1=Double.TryParse(Console.ReadLine(), out a);
            bool isCorr2=Double.TryParse(Console.ReadLine(), out b);
			bool isCorr3=Double.TryParse(Console.ReadLine(), out c);

            if (isCorr1&&isCorr2&&isCorr3&&a!=0)
            {
            	D=b*b-4*a*c;
				if (D>0)
            	{
            		x1=(b+Math.Sqrt(D))/2/a;
					x2=(b-Math.Sqrt(D))/2/a;
					Console.WriteLine("Roots of equation {0}x^2+{1}x+{2}=0 are {3:F2} and {4:F2}",
										a,b,c,x1,x2);					
            	}
				else if(D==0)
				{
					x1=b/2/a;
					Console.WriteLine("The root of equation {0}x^2+{1}x+{2}=0 is {3:F2}",
										a,b,c,x1);					
            	
				}
            	else
            	{
					Console.WriteLine("The equation has no roots");
				}
            	
            }
		}
    }
}