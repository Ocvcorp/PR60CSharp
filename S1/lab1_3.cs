using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const decimal   minBalance = 5000;
            decimal firstSum,
                    profitRate=0.0M;
            int     mounthNumber;
            Console.WriteLine("****A Bank Offer****\nMinimum balance: ${0:F2}\nPeriod: from 13 to 48 mounths",minBalance);
            do{
            Console.WriteLine("Please, enter your deposit sum and mounths number\n");
            firstSum =  Decimal.Parse(Console.ReadLine());
            mounthNumber=Int32.Parse(Console.ReadLine());
            if(firstSum<5000||mounthNumber<13||mounthNumber>48)
            {
            	Console.WriteLine("Incorrect input\n");
            }   
            	
            }while(firstSum<5000||mounthNumber<13||mounthNumber>48);
            decimal delta,
                    sum=firstSum;
            for(int i=0;i<mounthNumber;i++)
            {
                profitRate=Convert.ToDecimal(0.1+0.002*i*i+0.5*Math.Sin(2*i)+Math.Cos(3*i));
                delta=sum*profitRate/100;
                sum+=delta;
            
            }
            Console.WriteLine("Balance: ${0:F2}, profit rate: {1:P2}, mounth: {2:D}\n",sum,profitRate,mounthNumber);
            
            Console.ReadKey();
        }
    }
}
