using System;
using System.Globalization;

namespace ConsoleApp
{
    class Lab2_2
    {
        static void Main(string[] args)
        {
            //

            //

            int i;
            Console.WriteLine("Conveyer program. Use Up/Down/Right/Left keys to move transporter. Press \"ESCAPE\" to exit.");
            Console.WriteLine();
            ConveyerControl cc;
            do
            {
                i = (int)Console.ReadKey().Key;
                ConveyerControl.action ac = (ConveyerControl.action)i;
                cc.conveyer(ac);
            } while (i != 27);
            Console.WriteLine("\n Program is terminated. Press any key to close concole application.");
            Console.ReadKey();

        }
    }
}
