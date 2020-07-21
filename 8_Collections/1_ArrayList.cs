/*
Реализовать массив-список (ArrayList). 
Реализовать блоки обработки исключений, где это возможно. 
Посчитать среднее арифметическое и обнулить элементы, 
которые меньше среднего арифметического
Обработать, как минимум, три различных исключения. 
При этом  использовать доступные классы исключений, 
объявленные в System
*/
using System;
using System.Collections;
namespace ConsoleApp
{
	public class NegativeNumberException:Exception
	{
		public string msg;
		public NegativeNumberException(string msg)
		{
			this.msg=msg;
		}
	}
	class S6_0_1
	{
		public static bool MidVal(ArrayList arrList, out double result)
		{
			bool isResult=false;
			double sum=0.0;
			int doubleCount=0;
			double element=0.0;
			foreach (Object al in arrList)
			{
				try
				{
					element=(double)al;
					if(element<0)
						throw new NegativeNumberException("Negative number. Absolute value will be token");
					sum+=element;
					doubleCount++;
				}
				catch (InvalidCastException)
				{
					Console.WriteLine("Can't cast to double");
					continue;
				}
				catch(NegativeNumberException m)
				{
					Console.WriteLine(m.msg);
					sum-=element;
					doubleCount++;
					continue;
				}
			}
			try
			{
				if (doubleCount==0) 
					throw new DivideByZeroException();
				result= sum/doubleCount;
				isResult=true;
			}
			catch (DivideByZeroException)
			{
				Console.WriteLine("All the elements aren't double typed");
				result=0.0;
			}
			return isResult;
		}
		public static void NullLessMiddleVal(ArrayList arrList)
		{
			double midVal=0.0;
			if (MidVal(arrList, out midVal))
			{
				Console.WriteLine($"Medium value: {midVal}");
				int arrCount=arrList.Count;
				for (int i=0; i<arrCount; i++)
				{
					try
					{
						if ((double)arrList[i]<midVal)
							arrList[i]=0.0;
					}
					catch (InvalidCastException)
					{
						continue;
					}
				}
			} 
		}
		public static void PrintCollection(IEnumerable arrList)
		{
			foreach (object al in arrList)
			{
				Console.WriteLine(al);
			}
		}			
		public static void Main()
		{
			ArrayList aList=new ArrayList();
			aList.Add(1.10);
			aList.Add(-2.31);
			aList.Add(1.57);
			aList.Add("sich5.11");
			aList.Add(2.14);
			aList.Add(2.11);
			Console.WriteLine("Initial array:");
			PrintCollection(aList);
			NullLessMiddleVal(aList);
			Console.WriteLine("Array after transformation:");
			PrintCollection(aList);			
		}
	}
}



























