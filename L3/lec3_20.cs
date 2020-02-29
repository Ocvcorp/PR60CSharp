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
            string str;
            int wordsNum = 0;
            Console.WriteLine("Enter a string");
            str = Console.ReadLine();
            int symNum = str.Length-1;
            for (int i=0; i<symNum;i++)
            {
                if (str[i]==' '&&str[i+1]!=' ')
                {
                    wordsNum++;
                }
            }
            wordsNum++;
            Console.WriteLine($"There are {wordsNum} words in the string");
            
        }

    }
}