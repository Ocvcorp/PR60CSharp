using System;

namespace ConsoleAppClive
{
    class Program
    {
        static void Main(string[] args)
        {
            

            double La,
                   Lb,
                   Lc,
                   C,
                   A,
                   B,
                   S,
                   angSum;
                                
            Console.WriteLine("Enter 2 triangle sides and a sharp angle (deg) between\n");
            La=Double.Parse(Console.ReadLine());
            Lb=Double.Parse(Console.ReadLine());
            C=Double.Parse(Console.ReadLine());           
            if (C<90)
            {
                C*=(Math.PI/180);
                S=La*Lb*Math.Sin(C)/2;
                Lc=Math.Sqrt(La*La+Lb*Lb-2*La*Lb*Math.Cos(C));
                A=Math.Asin(La*Math.Sin(C)/Lc);
                B=Math.Asin(Lb*Math.Sin(C)/Lc);
                angSum=A+B+C;
                //angSum*=(180/Math.PI);
                A*=(180/Math.PI);
                B*=(180/Math.PI);
                if (Math.Abs(angSum-Math.PI)<.001)
                {
                	Console.WriteLine("Triangle square: {0:F1} m2\n3d side: {1:F1}\nOther angles: {2:F0}deg, {3:F0}deg\nAngle sum: {4:F0}\n",
                                    S,Lc,A,B,angSum*180/Math.PI);
                }
                else
                {
                	Console.WriteLine("Triangle has obtuse angle. Square: {0:F1} m2\n3d side: {1:F1}",
                					S,Lc);
                }
            }
            else
            {
                Console.WriteLine("Incorrect input. Angle must be less than 90 deg");
            }            
            //Console.ReadKey();
        }
    }
}
