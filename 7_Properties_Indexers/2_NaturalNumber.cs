using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class NaturalNumber
    {
        int power;
        public int Base { get; set; }
        public int Power
        {
            get 
            {
                int ans = 1;
                for (int i=1;i<=power;i++)
                {
                    ans *= Base;
                }
                return ans;
            }
            set { power = value; }
        }
        public NaturalNumber(int baseNN, int pow)
        {
            Base = baseNN;
            power=pow;
        }
    }
    public class Programm
    {
        public static void Main()
        {
            NaturalNumber nn = new NaturalNumber(2, 3);
            Console.WriteLine("2^3=" + nn.Power);
            nn.Base = 3;
            nn.Power = 3;
            Console.WriteLine("3^3=" + nn.Power);

        }
    }

}
