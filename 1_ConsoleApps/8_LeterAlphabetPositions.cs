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
            int letPlace1, letPlace2, unicode, letDiff, upLow1, upLow2;
            char letter1,letter2;
            bool isChar1, isChar2, isInt;
            do
            {
                //symbol
                Console.WriteLine("Enter 2 letters (1 item per line) or string to pass");
                isChar1 = Char.TryParse(Console.ReadLine(), out letter1);
                isChar2 = Char.TryParse(Console.ReadLine(), out letter2);
                if (isChar1&&isChar2) 
                { 
                    upLow1=Char.ToUpper(letter1);
                    upLow2=Char.ToUpper(letter2);
                    letPlace1=(Int32)upLow1-(Int32)'A'+1;
                    letPlace2=(Int32)upLow2-(Int32)'A'+1;
                    letDiff=Math.Abs(letPlace1-letPlace2)-1;
                    Console.WriteLine("The letter {0} is in {1} place\nand the letter {2} is in the {3} place\nThere are {4} letters between", 
                    letter1, letPlace1,letter2, letPlace2, letDiff); 
                }
                else
                {
                	break;
                }
                //unicode
                Console.WriteLine("And now enter a letter number in alphabet (less 32) or string to exit");
                isInt = Int32.TryParse(Console.ReadLine(), out letPlace1);
                if (isInt)
                {
                    unicode=(Int32)'A'+letPlace1-1;
                    Console.WriteLine("A letter in {0} place is {1}", 
                    letPlace1, (Char)unicode);
                }
                else
                {
                	break;
                }
            } while (true);
        }

    }
}