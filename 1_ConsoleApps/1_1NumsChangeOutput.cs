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
           Console.WriteLine("input 2 variables");
           var n1=Console.ReadLine();
           var n2=Console.ReadLine();
           Console.WriteLine("n1={0}; n2={1}",n1,n2);
           var n3=n1;
           n1=n2;
           n2=n3;
           Console.WriteLine("n1={0}; n2={1}",n1,n2);
           
           
        }
    }
}