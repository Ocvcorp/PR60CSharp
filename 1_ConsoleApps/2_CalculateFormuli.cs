using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const double A=25e-5;
            double[] Xm={.0001,.1,-1,1,4};
            double log2X=0.0,
                   log10X=0.0,
                   X,
                   Y=0.0;
            int calcVar;                    
            Console.WriteLine("Choose a calculation variant:\n0 - for argument should be entered,\n1 - for specified argument row\n");
            calcVar=Int32.Parse(Console.ReadLine());
            if (calcVar==0)
            {
                X=Double.Parse(Console.ReadLine());
                log2X=Math.Log2(X);
                log10X=Math.Log10(X);
                Y=(1-Math.Sqrt(Math.Abs(log2X))+A*log10X)/(log2X+A*log10X);
                Console.WriteLine("Y = {0:F3}",Y);
            }
            else if(calcVar==1)
            {
                for (int i = 0; i < 5; i++)
                {
                    X=Xm[i];                    
                    log2X=Math.Log2(X);
                    log10X=Math.Log10(X);
                    Y=(1-Math.Sqrt(Math.Abs(log2X))+A*log10X)/(log2X+A*log10X);
                    Console.WriteLine("X = {0:F}, Y = {1:F}\n",X,Y);
                }                    
            }
            else
            {
                Console.WriteLine("Incorrect choice");
            }            
            Console.ReadKey();
        }
    }
}
