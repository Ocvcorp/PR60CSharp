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
            int unicode;
            char sym;
            bool keepRunning;
            do
            {
                //symbol
                Console.WriteLine("Enter a symbol or string to pass");
                keepRunning = Char.TryParse(Console.ReadLine(), out sym);
                if (keepRunning) 
                { 
                    Console.WriteLine("Unicode number of {0} is {1}", sym, (Int32)sym); 
                }
                //unicode
                Console.WriteLine("And now enter an integer number(to 65535) or string to exit");
                keepRunning = Int32.TryParse(Console.ReadLine(), out unicode);
                if (keepRunning)
                {
                    Console.WriteLine("A symbol with unicode number {0} is {1}", unicode, (Char)unicode);
                }
            } while (keepRunning);
        }

    }
}