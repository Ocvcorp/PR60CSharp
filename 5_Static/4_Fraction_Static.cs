/*
Реализовать класс рациональное число (дробь)
Из определения следует, что любое рациональное число в смешанном 
виде определяется четырьмя составляющими: 
	 знаком числа (число положительное или отрицательное); 
	целой частью; 
	числителем; 
	знаменателем. 
Все составляющие дроби являются целыми числами. 
Знак дроби тоже будем представлять в виде целого числа 
(1 – положительная дробь, -1 – отрицательная дробь)
	При описании операций с дробями предполагаем, 
что объекты класса Fraction находятся в смешанном виде. 
Результатом операции над дробями может быть неправильная дробь, 
которую, согласно предположению, необходимо перевести в смешанный вид. 
Для этого необходимы методы «преобразования в смешанный вид», 
«сокращения дроби» и «выделения целой части». 
Данные методы будут применяться при выполнении арифметических операций 
над дробями или при создании дроби, гарантируя, что дробь после завершения 
операции будет иметь смешанный вид. 
Таким образом, пользователю класса нет необходимости выполнять операции 
приведения дроби к смешанному виду, поскольку эта операция 
выполняется автоматически. 
Поэтому методы преобразования в смешанный вид, сокращения дроби 
и выделения целой части можно описать как закрытые элементы класса.
Проверка класса Fraction в lec6FractionMain.cs 
*/

using System;
using System.Text.RegularExpressions;




class Fraction
{
	public int signF;
	public int intPart;
	public int numerator;
	public int denominator;
	public Fraction(int num, int denum, int intP = 0)
	{

		intPart = intP;
		numerator = num;
		denominator = denum;//!=0
		if (numerator / denominator >= 0)
			signF = 1;
		else
		{
			signF = -1;
			numerator = -numerator;
		}
		intPartSelect();
		Reduction();		
	}
	public void impropreation()
	{
		numerator += (intPart * denominator);
		numerator *= signF;
		signF = 1;
		intPart = 0;
	}
	private void intPartSelect()
	{
		intPart = numerator / denominator;
		numerator -= (intPart * denominator);
	}
	private void Reduction()
	{
		int maxCommonDevider = 1;
		for (int i = 2; i <= numerator; i++)
		{
			if ((numerator % i == 0) && (denominator % i == 0))
			{
				maxCommonDevider = i;
			}
		}
		numerator /= maxCommonDevider;
		denominator /= maxCommonDevider;
	}
	static public Fraction operator +(Fraction ob1, Fraction ob2)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		ob2.impropreation();
		rDenom = ob1.denominator * ob2.denominator;
		rNum = ob1.numerator * ob2.denominator + ob2.numerator * ob1.denominator;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator +(Fraction ob1, int a)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator;
		rNum = ob1.numerator + a * rDenom;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator +(int a, Fraction ob1)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator;
		rNum = ob1.numerator + a * rDenom;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator -(Fraction ob)
	{
		Fraction res = new Fraction(-ob.numerator, ob.denominator, ob.intPart);
		return res;
	}
	static public Fraction operator -(Fraction ob1, Fraction ob2)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		ob2.impropreation();
		rDenom = ob1.denominator * ob2.denominator;
		rNum = ob1.numerator * ob2.denominator - ob2.numerator * ob1.denominator;

		/*
		rNum = rNum = ob1.signF * ob2.denominator * (ob1.numerator + ob1.intPart * ob1.denominator) -
			ob2.signF * ob1.denominator * (ob2.numerator + ob2.intPart * ob2.denominator);*/
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator -(Fraction ob1, int a)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator;
		rNum = ob1.numerator - a * rDenom;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator -(int a, Fraction ob1)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator;
		rNum = -ob1.numerator + a * rDenom;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator *(Fraction ob1, Fraction ob2)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		ob2.impropreation();
		rDenom = ob1.denominator * ob2.denominator;
		rNum = ob1.numerator * ob2.numerator;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator *(Fraction ob1, int a)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator;
		rNum = ob1.numerator * a;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator *(int a, Fraction ob1)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator;
		rNum = ob1.numerator * a;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator /(Fraction ob1, Fraction ob2)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		ob2.impropreation();
		rDenom = ob1.denominator * ob2.numerator;
		rNum = ob1.numerator * ob2.denominator;
		if (rDenom < 0)
		{
			rDenom = -rDenom;
			rNum = -rNum;
		}
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator /(Fraction ob1, int a)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.denominator * a;
		rNum = ob1.numerator;
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public Fraction operator /(int a, Fraction ob1)
	{
		int rNum;
		int rDenom;
		ob1.impropreation();
		rDenom = ob1.numerator;
		rNum = ob1.denominator * a;
		if (rDenom<0)
		{
			rDenom = -rDenom;
			rNum = -rNum;
		}
		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	static public explicit operator double(Fraction ob)
	{
		ob.impropreation();
		return Convert.ToDouble(ob.numerator) / Convert.ToDouble(ob.denominator);
	}
	public static bool operator >(Fraction ob1, Fraction ob2)
	{
		ob1.impropreation();
		ob2.impropreation();
		return (ob1.numerator * ob2.denominator > ob2.numerator * ob1.denominator) ? true : false;
	}
	public static bool operator <(Fraction ob1, Fraction ob2)
	{
		ob1.impropreation();
		ob2.impropreation();
		return (ob1.numerator * ob2.denominator < ob2.numerator * ob1.denominator) ? true : false;
	}
	public static bool operator >=(Fraction ob1, Fraction ob2)
	{
		ob1.impropreation();
		ob2.impropreation();
		return (ob1.numerator * ob2.denominator >= ob2.numerator * ob1.denominator) ? true : false;
	}
	public static bool operator <=(Fraction ob1, Fraction ob2)
	{
		ob1.impropreation();
		ob2.impropreation();
		return (ob1.numerator * ob2.denominator <= ob2.numerator * ob1.denominator) ? true : false;
	}
	public static bool operator !=(Fraction ob1, Fraction ob2)
	{
		ob1.impropreation();
		ob2.impropreation();
		return (ob1.numerator * ob2.denominator != ob2.numerator * ob1.denominator) ? true : false;
	}
	public static bool operator ==(Fraction ob1, Fraction ob2)
	{
		ob1.impropreation();
		ob2.impropreation();
		return (ob1.numerator * ob2.denominator == ob2.numerator * ob1.denominator) ? true : false;
	}
	public static Fraction Parse(string str)
	{
		int rNum=0;
		int rDenom=1;
		str = Regex.Replace(str, @"\s+", "");//removing spaces
		Regex regex = new Regex(@"^(-)?\(?(\d+)?\+?(\d+)?\/?(\d+)?");
		MatchCollection matches = regex.Matches(str);
		if (matches[0].Groups.Count == 5)
		{
			if (matches[0].Groups[1].Value == "-" && matches[0].Groups[3].Value!="")
				rNum = -Convert.ToInt32(matches[0].Groups[2].Value) * Convert.ToInt32(matches[0].Groups[4].Value) - Convert.ToInt32(matches[0].Groups[3].Value);
			if (matches[0].Groups[1].Value == "-" && matches[0].Groups[3].Value == "")
				rNum = -Convert.ToInt32(matches[0].Groups[2].Value);
			if (matches[0].Groups[1].Value != "-" && matches[0].Groups[3].Value != "")
				rNum = Convert.ToInt32(matches[0].Groups[2].Value) * Convert.ToInt32(matches[0].Groups[4].Value) + Convert.ToInt32(matches[0].Groups[3].Value);
			if (matches[0].Groups[1].Value != "-" && matches[0].Groups[3].Value == "")
				rNum = Convert.ToInt32(matches[0].Groups[2].Value);
			rDenom = Convert.ToInt32(matches[0].Groups[4].Value);
		}

		Fraction res = new Fraction(rNum, rDenom);
		return res;
	}
	public static implicit operator string(Fraction ob)
	{
		string str = "";
		if (ob.signF < 0) str = "-";
		if (ob.intPart == 0) 
			str += Convert.ToString(ob.numerator) + "/" + Convert.ToString(ob.denominator);
			else if (ob.denominator == 1)
				str += Convert.ToString(ob.intPart);
					else
					{
						if (ob.signF < 0)
							str = "-(" + Convert.ToString(ob.intPart) + "+" + Convert.ToString(ob.numerator) + "/" + Convert.ToString(ob.denominator) + ")";
						else
							str = Convert.ToString(ob.intPart) + "+" + Convert.ToString(ob.numerator) + "/" + Convert.ToString(ob.denominator);
					}
		return str;
	}
}



























