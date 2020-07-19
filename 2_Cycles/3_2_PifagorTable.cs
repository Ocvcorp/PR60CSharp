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
			string strLine="\t\t";
			for (int i=1; i<10; i++)
			{
				strLine+=(i.ToString()+" \t\t");
			}
			Console.WriteLine("Pifagor table\n"+strLine);			
			for (int i=1; i<10; i++)
			{
				strLine=i.ToString()+" \t";
				for (int j=1; j<10; j++)
				{
					strLine+=((i*j).ToString()+" \t");
				}
				Console.WriteLine(strLine);
			}			 
		}
    }
}