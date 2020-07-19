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
            double x, y, r, rP;
			
			Console.WriteLine("Enter a point coordinates (x, y) and radius"); 
			bool isCorr1=Double.TryParse(Console.ReadLine(), out x);
            bool isCorr2=Double.TryParse(Console.ReadLine(), out y);
			bool isCorr3=Double.TryParse(Console.ReadLine(), out r);

            if (isCorr1&&isCorr2&&isCorr3)
            {
            	rP=Math.Sqrt(x*x+y*y);
				
				if (rP-r<=0)
            	{
					Console.WriteLine("A point ({0},{1}) is inside the circle with radius {2}",
										x,y,r);					
            	}
				else
				{
					Console.WriteLine("A point ({0},{1}) is outside the circle with radius {2}",
										x,y,r);					            	
				}
            	
            }
		}
    }
}