using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int n,
                F1=1,
                F2=1,
                F=F1+F2;            
            Console.WriteLine("Let's check the number belongs to Fibonacci row!\nTry to enter integer value");
            bool b=Int32.TryParse(Console.ReadLine(),out n);
            if(b)
            {
                while(F<n)
                {
                    F1=F2;
                    F2=F;
                    F=F1+F2;
                }
                if (n==F||n==1)
                {
                    Console.WriteLine("The number {0:D} is a Fibonacci number!",n);
                }
                else
                {
                    Console.WriteLine("The number {0:D} isn't a Fibonacci number!",n);
                }
            }
            else
            {
                Console.WriteLine("Wrong output\n");
            }            
            Console.ReadKey();
        }
    }
}
