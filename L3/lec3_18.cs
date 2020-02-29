using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public static class Program
    {

        public static void Main()
        {
            int numCaps=0, numSL=0;
            string str;
            Console.WriteLine("Enter a string");
            str = Console.ReadLine();
            foreach (char c in str)
            {
                if ((int)c>64&& (int)c <91)
                {
                    numCaps++;
                }
                if ((int)c > 96 && (int)c < 123)
                {
                    numSL++;
                }
            }
            Console.WriteLine($"There are {numCaps} uppercase and {numSL} lowercase letters in the string");
            
        }

    }
}