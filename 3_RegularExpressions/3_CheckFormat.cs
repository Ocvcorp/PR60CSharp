/*
Задание на регулярные выражения
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
	class lec6task13_14
	{
		
		static void Main()
		{
			//13 Реализовать метод проверки строки на корректный формат электронного ящика
			Console.WriteLine("Enter e-mail");
			string email=Console.ReadLine();
			if (!isEmailCorrect(email))
				Console.WriteLine("E-mail isn't correct");
			/*14 Реализовать метод, который проверяет, является ли строка номером телефона в форматах
				+7(495)123-1233
				+7 495 123-1233
				+7 495 1231233*/
			Console.WriteLine("Enter a telefone number like this +7xxx xxx-xxxx");
			string telString=Console.ReadLine();
			bool isValid;
			TelefoneNumber telNum=TelefoneNumber.validFormat(telString, out isValid);
			if (isValid)
				telNum.outPut();
				else
					Console.WriteLine("invalid format");
		}
		
		
		static bool isEmailCorrect(string email)
		{
			Regex regex=new Regex(@"\w*\@\w*\.\w*");
			if (regex.Matches(email).Count>0)
				return true;
				else
					return false;
		}
	}
	class TelefoneNumber
	{
		private string countryCode;
		private string cityCode;
		private string abonentNumber;
		public TelefoneNumber(string countryCode="",string cityCode="",string abonentNumber="")
		{
			this.countryCode=countryCode;
			this.cityCode=cityCode;
			this.abonentNumber=abonentNumber;
		}
		public void setParams(string countryCode,string cityCode,string abonentNumber)
		
		{
			this.countryCode=countryCode;
			this.cityCode=cityCode;
			this.abonentNumber=abonentNumber;
		}
		public static TelefoneNumber validFormat(string telStr, out bool isValid)
		{
			isValid=false;
			TelefoneNumber telNum=new TelefoneNumber();
			string coC;
			string ciC;
			string abN;
			Regex regex=new Regex(@"^(\+\d*)\s*\(?(\d*)\)?\s*(\d{3})-?(\d{4})");
			MatchCollection match=regex.Matches(telStr);
			if (match[0].Groups.Count==5)
			{
				isValid=true;
				coC=match[0].Groups[1].Value;
				ciC=match[0].Groups[2].Value;
				abN=match[0].Groups[3].Value+match[0].Groups[4].Value;
				telNum.setParams(coC,ciC,abN);
			}
			return telNum;
		}
		public void outPut()
		{
			Console.WriteLine("Country code: {0}\nCity code: {1}\nAbonent number: {2}",
								countryCode,cityCode,abonentNumber);
		}
	}
		
}