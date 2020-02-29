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
            double x0, xN, dx, y;
			
			Console.WriteLine("Enter interval limits (min x, max x) and increment"); 
			bool isCorr1=Double.TryParse(Console.ReadLine(), out x0);
            bool isCorr2=Double.TryParse(Console.ReadLine(), out xN);
			bool isCorr3=Double.TryParse(Console.ReadLine(), out dx);

            if (isCorr1&&isCorr2&&isCorr3)
            {
				Console.WriteLine("Function y=-0.23x2+x\nx:\ty:"); 
            	for (double x=x0; x<=xN; x+=dx)
				{					
					y=-.23*x*x+x;
					Console.WriteLine("{0:F2}\t\t{1:F4}",x,y); 
				}
				
            }
		}
    }
}