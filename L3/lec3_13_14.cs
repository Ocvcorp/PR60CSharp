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
			Console.WriteLine("Enter a number"); 
			string strN=Console.ReadLine();			
			int number=Int32.Parse(strN);
			int NDigit=strN.Length+1;
			string strEO="";
			int oddNums=0;
			int eveNums=0;
			int digit;
			
			for (int i=1; i<NDigit; i++)
			{				
				digit=number%10;
				strEO+=digit.ToString();//task 13
				if (digit%2==0)//task14
				{
					oddNums++;
				}
				else
				{
					eveNums++;
				}
				number/=10;
			}				
			Console.WriteLine("A number in reverse order is {0}\nodd digits meet {1} times, even digits - {2} times", 
			strEO, oddNums, eveNums); 
		}
    }
}