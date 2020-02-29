using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const decimal   minBalance = 5000, 
                            invesTime = 10;
            decimal firstSum,
                    profitRate = 0.08M;                            ;
            //Console.WriteLine("****A Bank Offer****\nMinimum balance: {0:C2}\nProfit Rate: {1:P0}\nInvestment Time: {2:F0} years\n"
            //                  ,minBalance.ToString("C2",CultureInfo.CreateSpecificCulture("us-US")),profitRate,invesTime);
            Console.WriteLine("****A Bank Offer****\nMinimum balance: ${0:F2}\nProfit Rate: {1:P0}\nInvestment Time: {2:F0} years\n"
                              ,minBalance,profitRate,invesTime);
            do{
            Console.WriteLine("Please, enter your first deposit\n");
            
            firstSum =  Decimal.Parse(Console.ReadLine());
            if(firstSum<5000)
            {
            	Console.WriteLine("Balance need to be more than $5000,00, you entered ${0:F2}",firstSum);
            }
            	
            }while(firstSum<5000);
            decimal delta,
                    sum=firstSum, 
                    finalRate,
                    finalCost;
            for(int i=0; i<10; i++)
            {
            	delta=sum*profitRate;
                sum+=delta;                              
            }
            firstSum=sum;
            Console.WriteLine("Your Sberbank deposit after 10 years is {0:F2}",sum);
            decimal avProfitRate=.0M;
            for(int i=0;i<12;i++)
            {
                profitRate=Convert.ToDecimal(0.1+0.002*i*i+0.5*Math.Sin(2*i)+Math.Cos(3*i));
                avProfitRate+=profitRate/100;
                delta=sum*profitRate/100;
                sum+=delta;
                Console.WriteLine("Mounth {0:D}. Balance: ${1:F2}, profit rate: {2:P2}\n",i+1,sum,profitRate);
            
            }
            avProfitRate/=12;
            finalRate=sum/firstSum-1;
            finalCost=sum-firstSum;
            Console.WriteLine("Total(12 mounts): capital increment sum ${0:F2}, increment rate {1:P3}, average profit rate {2:P3} ", finalCost ,finalRate, avProfitRate);
            Console.ReadKey();
        }
    }
}
