using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class s9_2_2_MathLambdaDelegate
    {
        delegate bool BoolMathOps(int x);
        delegate int IntMathOps(int x);
        delegate double DblMathOps(double x);
        public static void Main()
        {
            BoolMathOps PowOfTwo = x => (x & (x - 1)) == 0 ? true : false;
            IntMathOps Fact = x =>
              {
                  int m = 1;
                  for (int i = 1; i <= x; i++)
                      m *= i;
                  return m;
              };
            DblMathOps Reciprocal = x => 1 / x;
            DblMathOps FracPart = x => x - Math.Truncate(x);
            BoolMathOps IsEven = x => (x % 2) == 0 ? true : false;
            BoolMathOps IsOdd = x => (x % 2) == 1 ? true : false;
            DblMathOps Crt = x => Math.Cbrt(x);
            DblMathOps DegToRad = x => x / 180 * Math.PI;
            DblMathOps RadToDeg = x => x * 180 / Math.PI;

            int X;
            Console.WriteLine("Input a number");
            Int32.TryParse(Console.ReadLine(), out X);
            Console.WriteLine("Is {0} a power of 2: {1}", X, PowOfTwo(X));
            Console.WriteLine("Factorial of {0} is: {1}", X, Fact(X));
            Console.WriteLine("Inversed {0} is equal to: {1:F3}", X, Reciprocal(X));
            Console.WriteLine("Fractional part of {0} is: {1:F3}", X+0.235, FracPart(X+0.235));
            Console.WriteLine("Is {0} even number: {1}", X, IsEven(X));
            Console.WriteLine("Is {0} odd number: {1}", X, IsOdd(X));
            Console.WriteLine("Cubic root of {0} is: {1:F3}", X, Crt(X));
            Console.WriteLine("{0} degrees is: {1:F3} radians", X, DegToRad(X));
            Console.WriteLine("{0} radians is: {1:F3} degrees", X, RadToDeg(X));
        }
    }
}
