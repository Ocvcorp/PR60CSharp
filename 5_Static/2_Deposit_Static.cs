using System;
using System.Text;

namespace ConsoleApp
{
	class Deposit
	{
		private static string bankName;
		private string date;
		private string person;
		private double sum;
		private static double percent;
		private static int days;
		static Deposit()
		{
			bankName="VTB";
			percent=10;
			days=365;	
		}
		public Deposit(string d="10.02.2020", string p="Anton", double s=5000.0)
		{
			date=d;
			person=p;
			sum=s;
		}
		public void showInfo()
		{
			Console.WriteLine("Deposit info:\n1.Bank - {0}\n2.Conditions: {1}%-{2}days\n3.Person info:{3}-{4}-{5}USD",
			bankName, percent, days, person, date, sum);
		}
		public void finalSum()
		{
			double fSum=sum*(100+percent)/100;
			Console.WriteLine($"Final sum is {fSum} USD");
		}		
	}
	/*class Program
	{
		static void Main()
		{
			Deposit dep=new Deposit();
			dep.finalSum();
			dep.showInfo();
			Deposit dep2=new Deposit("07.08.2021", "Sara", 3000.00);
			dep2.finalSum();
			dep2.showInfo();
		}
	}*/
}