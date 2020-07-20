using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruits
{
    class Program
    {
        static void Main(string[] args)
        {
            Fruit apple1 = new Apple("Golden", 100, "Asia", "Apple", 10.1, FruitShape.Round); 
            Apple apple2 = new Apple("Royal", 50, "Poland", "Apple", 6.1, FruitShape.Round);
            Fruit berry1 = new Berry(FruitColor.Blue, "10/08/2019", "Brazil", "Berry", 15.3, FruitShape.Oval);
            Potato pot1 = new Potato("Gala", 50, "Europe", "Potato", 2.1, VegShape.Oval);
            Tomato tom1 = new Tomato(VegColor.Red, "05/07/2019", "Mexico", "Tomato", 5.1, VegShape.Round);
            apple2.fType();
            Fruit[] fs = { apple1, berry1, apple2 };
            foreach (Fruit F in fs)
            {
                F.getInfo();
                F.fType();
            }
            /*pot1.getInfo();
            tom1.getInfo();*/

            //Interfaces
            IApple iapp1=new IApple();
            iapp1.SetName("Antonovka");
            iapp1.SetWhere("Gzhel");
            iapp1.SetPrice(1.1);
            iapp1.getInfo();
            Console.ReadKey();
        }
    }
}
