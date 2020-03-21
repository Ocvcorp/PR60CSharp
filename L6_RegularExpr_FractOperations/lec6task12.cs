/*
Задание на регулярные выражения
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
	class lec9_12
	{
		public static void Main()
		{
			Console.WriteLine("Enter an operation in format: A{operation}B=");
				string operation = Console.ReadLine();
				double result;
				if (Calc(operation, out result))
					Console.WriteLine(result);
					else
						Console.WriteLine("Incorrect input");
		}
		public static bool Calc(string expr, out double result)
		{
			bool isCd=false;
			result=0;
			double A;
			string operationSign;
			double B;
			Regex regex=new Regex(@"(\d*.\d*)(\+|-|\*|\/)(\d*.\d*)");
			MatchCollection matches=regex.Matches(expr);
			if (matches[0].Groups.Count==4)
			{				
				isCd=true;
				A=Convert.ToDouble(matches[0].Groups[1].Value);
				operationSign=matches[0].Groups[2].Value;				
				B=Convert.ToDouble(matches[0].Groups[3].Value);
				Console.WriteLine($"{A}  {operationSign}  {B}");
				if (operationSign=="+") result=A+B;
				if (operationSign=="-") result=A-B;
				if (operationSign=="*") result=A*B;
				if (operationSign=="/"&&B!=0) result=A/B;
				if (operationSign=="/"&&B==0) isCd=false;	
			}
			return isCd;
		}
	}
}