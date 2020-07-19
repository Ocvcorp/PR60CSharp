using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const decimal   minBalance = 5000, 
                            profitRate = 0.08M, 
                            invesTime = 10;
            decimal firstSum;
            //Console.WriteLine("****A Bank Offer****\nMinimum balance: {0:C2}\nProfit Rate: {1:P0}\nInvestment Time: {2:F0} years\n"
            //                  ,minBalance.ToString("C2",CultureInfo.CreateSpecificCulture("us-US")),profitRate,invesTime);
            Console.WriteLine("****A Bank Offer****\nMinimum balance: ${0:F2}\nProfit Rate: {1:P0}\nInvestment Time: {2:F0} years\n"
                              ,minBalance,profitRate,invesTime);
            do{
            Console.WriteLine("Please, enter your deposit\n");
            
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
                Console.WriteLine("Year {0:D}. Balance: ${1:F2}, capital increment: ${2:F2}\n",i+1,sum,delta);               
            }
            finalRate=sum/firstSum-1;
            finalCost=sum-firstSum;
            Console.WriteLine("Investment cost ${0:F3}, effective rate {1:P3} ", finalCost ,finalRate);
            Console.ReadKey();
        }
    }
}
