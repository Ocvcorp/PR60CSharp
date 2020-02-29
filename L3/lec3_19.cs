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
            string str, subStr, newSubStr;
            Console.WriteLine("Enter a string, a substring and new string to substitute");
            str = Console.ReadLine();
            subStr = Console.ReadLine();
            newSubStr = Console.ReadLine();
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i=0;i<words.Length;i++)
            {
                if (words[i] == subStr)
                {
                    words[i] = newSubStr;
                }
            }
            str = "";
            foreach (string s in words)
            {
                str += (s + " ");
                
            }
            Console.WriteLine("New string is\n"+str);
            
        }

    }
}