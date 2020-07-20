using System;
/*
Операции с дробями с использованием класса Fraction
*/

namespace ConsoleApp
{
    class lec6FractionMain
    {
        static void Main(string[] args)
        {
            //input
            string sF1 = "-(2+2/3)";
            string sF2 = "-2/7";
            int intVal = 5;
            //conversion
            Fraction f1 = Fraction.Parse(sF1);
            Fraction f2 = Fraction.Parse(sF2);
            string[] resStr = { f1 + f2,  
                                f1+intVal,
                                intVal+f2,
                                - f2,
                                f1 - f2,
                                f1 - intVal,
                                intVal - f2,
                                f1 * f2,
                                f1 * intVal,
                                intVal* f2,
                                f1 / f2,
                                f1 /intVal,
                                intVal / f2
                              };

            Console.WriteLine("{0}+{1}={2}", sF1, sF2, resStr[0]); 
            Console.WriteLine("{0}+{1}={2}", sF1, intVal, resStr[1]);
            Console.WriteLine("{0}+{1}={2}", intVal, sF2, resStr[2]);
            Console.WriteLine("   -{0}={1}", sF2, resStr[3]);
            Console.WriteLine("{0}-{1}={2}", sF1, sF2, resStr[4]);
            Console.WriteLine("{0}-{1}={2}", sF1, intVal, resStr[5]);
            Console.WriteLine("{0}-{1}={2}", intVal, sF2, resStr[6]);
            Console.WriteLine("{0}*{1}={2}", sF1, sF2, resStr[7]);
            Console.WriteLine("{0}*{1}={2}", sF1, intVal, resStr[8]);
            Console.WriteLine("{0}*{1}={2}", intVal, sF2, resStr[9]);
            Console.WriteLine("{0}/{1}={2}", sF1, sF2, resStr[10]);
            Console.WriteLine("{0}/{1}={2}", sF1, intVal, resStr[11]);
            Console.WriteLine("{0}/{1}={2}", intVal, sF2, resStr[12]);
            Console.WriteLine("    {0}={1:F2}", sF1, (double)f1);
            Console.WriteLine("{0}>{1}: {2}", sF1, sF2, f1>f2);
            Console.WriteLine("{0}<={1}: {2}", sF1, sF2, f1 <= f2);
            Console.WriteLine("{0}={1}: {2}", sF1, sF2, f1 == f2);
            Console.WriteLine("{0}!={1}: {2}", sF1, sF2, f1 != f2);



        }
    }
}
