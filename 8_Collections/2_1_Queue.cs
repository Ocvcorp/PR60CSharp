/*
Реализовать очередь (Queue). 
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
	class S6_0_2
	{
		public static bool MidVal(Queue qList, out double result)
		{
			bool isResult=false;
			double sum=0.0;
			int doubleCount=0;
			double element=0.0;
			foreach (object al in qList)
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
		public static void NullLessMiddleVal(ref Queue qList)
		{
			double midVal=0.0;
			if (MidVal(qList, out midVal))
			{
				Console.WriteLine($"Medium value: {midVal}");
				int qCount=qList.Count;
				for (int i=0; i<qCount; i++)
				{
					try
					{
						if ((double)qList.Peek()<midVal)
							qList.Dequeue();
							qList.Enqueue(0.0);
					}
					catch (InvalidCastException)
					{
						continue;
					}
				}
			} 
		}
		public static void PrintCollection(Queue aQueue)
		{
			foreach (object aq in aQueue)
			{
				Console.WriteLine(aq);
			}
		}			
		public static void Main()
		{
			Queue aQue=new Queue();
			aQue.Enqueue(1.10);
			aQue.Enqueue(-2.31);
			aQue.Enqueue(1.57);
			aQue.Enqueue("df5.11");
			aQue.Enqueue(2.14);
			aQue.Enqueue(2.11);
			Console.WriteLine("Initial queue:");
			PrintCollection(aQue);
			NullLessMiddleVal(ref aQue);
			Console.WriteLine("Array after transformation:");
			PrintCollection(aQue);			
		}
	}
}



























