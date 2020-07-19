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
            int sum=0, perfNum=0, halfN;
            string strSD = "\t";
            Console.WriteLine("Here a set of perfect numbers from 0 to 10000");
            for (int i=6; i<10000; i++)
            {
            	halfN=i/2+1;
            	for (int j=1; j<=halfN; j++)
            	{
            		if (i%j==0)
            		{
            			sum+=j;
                        strSD += (j.ToString() + " ");
            		}
            	}
            	if (sum==i)
            	{
            		perfNum++;
            		Console.WriteLine($"Number: {i} Deviders:"+strSD);
            	}
                sum = 0;
                strSD = "\t";
            }
            Console.WriteLine($"This set has {perfNum} items");
        }

    }
}