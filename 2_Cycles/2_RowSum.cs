using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            

            double X,
                 eps,
                 S,i,m,p;            
            Console.WriteLine("Enter a number <= 1 and a precision");
            X=Double.Parse(Console.ReadLine());
            eps=Double.Parse(Console.ReadLine());
            if(X<=1)
            {
                S=X;
                i=1;
                m=1;
                p=-1;
                while(Math.Abs(m)>eps)
                {
                    p*=(-X);
                    m=p/i;
                    S+=m;
                    i+=1;
                }
                Console.WriteLine("Variable signed row sum is {0:F4}",S);
            }
            else
            {
                Console.WriteLine("The row have no convergence\n");
            }            
            Console.ReadKey();
        }
    }
}
