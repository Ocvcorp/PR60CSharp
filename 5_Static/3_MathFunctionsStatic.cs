using System;
/*3. Создать отдельную программу, в который реализован статический класс, содержащий только static-члены. 
Класс содержит коллекцию методов для выполнения математических функций. 
Продемонстрировать работу класса на примерах.
•	Вычисление факториала аргумента Fact()
•	Вычисление обратного числового значения аргумента Reciprocal()
•	Возврат дробной части числового аргумента FracPart()
•	Возврат флага нечетности аргумента IsOdd()
•	Возврат флага четности аргумента IsEven()
•	Вычисление кубического корня аргумента Crt()
•	Вычисление радиан по аргументу в градусах DegToRad()
•	Вычисление градусов по аргументу в радианах RadToDeg()
•	Проверка числа на принадлежность ряду чисел-степеней двойки BinaryDigit()*/
namespace ConsoleApp
{
	static class SomeMathFuncs
	{
		const double pi=3.14156;
		public static int Fact(int n)
		{
			int ans=1;
			for (int i=2;i<n;i++)
			{
				ans*=i;
			}
			return ans*n;
		}
		public static double Reciprocal(double N)
		{
			if (N==0)
			{
				return 0;
			}
			else
			{
				return 1/N;
			}
		}
		public static double FracPart(double N)
		{
			return N-Convert.ToInt32(N);
		}
		public static bool IsOdd(int N)
		{
			return (N%2==1)?true:false;
		}
		public static bool IsEven(int N)
		{
			return (N%2==0)?true:false;
		}
		public static double Crt(double N)
		{
			double eps=0.001;
			double xn=N/2;
			double xnp1=xn-(xn*xn*xn-N)/3/xn/xn;
			int alarmEx=1;		
			while ((xn-xnp1>eps||xn-xnp1<-eps)&&((++alarmEx)<1000))
			{
				xn=xnp1;
				xnp1 = xn - (xn * xn * xn - N) / 3 / xn / xn;
				if (++alarmEx == 1000)
				{
					Console.WriteLine("An error!");
					return 0; 
				}
			}
			return xn;
		}
		public static double DegToRad(double A)
		{
			return A * pi / 180;
		}
		public static double RadToDeg(double A)
		{
			return A * 180/pi;
		}
		public static bool BinaryDigit(int N)
		{
			bool ans = false;
			if (N > 1)
			{
				if ((N & (N - 1))==0 )
					ans = true;				
			}
			return ans;
		}
	}
}