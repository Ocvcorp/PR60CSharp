/*
Реализовать хэш-таблицу (Hashtable). 
Реализовать блоки обработки исключений, где это возможно. 
Посчитать среднее арифметическое и обнулить элементы, 
которые меньше среднего арифметического
Обработать, как минимум, три различных исключения. 
При этом  использовать доступные классы исключений, 
объявленные в System
*/
using System;
using System.Collections;
using System.Collections.Generic;

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
	class S6_0_3
	{
		public static bool MidVal(Hashtable hList, out double result)
		{
			bool isResult=false;
			double sum=0.0;
			int doubleCount=0;
			double element=0.0;
			ICollection vals = hList.Values;
			foreach (object al in vals)
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
		public static void NullLessMiddleVal(ref Hashtable hList)
		{
			double midVal=0.0;
			if (MidVal(hList, out midVal))
			{
				Console.WriteLine($"Medium value: {midVal}");
				ICollection keys = hList.Keys;
				List<string> changeKeys = new List<string>();
				foreach (string k in keys)
				{
					try
					{
						if ((double)hList[k] < midVal)
						{
							changeKeys.Add(k);
						}							
					}
					catch (Exception)
					{
						continue;
					}
				}
				foreach (string k in changeKeys)
				{
					hList.Remove(k);
					hList.Add(k, 0.0);
				}
			} 
		}
		public static void PrintCollection(Hashtable aTable)
		{
			ICollection keys=aTable.Keys;
			foreach (string s in keys)
			{
				Console.WriteLine("{0}:{1}",s, aTable[s]);
			}
		}			
		public static void Main()
		{
			Hashtable aHash=new Hashtable();
			aHash.Add("first",1.10);
			aHash.Add("second",-2.31);
			aHash.Add("third",1.57);
			aHash.Add("forth","df5.11");
			aHash.Add("fifth",2.14);
			aHash.Add("sixth",2.11);
			Console.WriteLine("Initial hashtable:");
			PrintCollection(aHash);
			NullLessMiddleVal(ref aHash);
			Console.WriteLine("Hashtable after transformation:");
			PrintCollection(aHash);			
		}
	}
}



























