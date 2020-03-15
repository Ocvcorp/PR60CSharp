using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruits
{
    interface IFruitVeget
    {
        void SetName(string name);
        void SetWhere(string geo);
        void SetPrice(double price);
    }
    class IApple : IFruitVeget
    {
        private string geoPlace;
        private string name;
        private double price;
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetWhere(string geo)
        {
            geoPlace = geo;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public void getInfo()
        {
            Console.WriteLine($"{name}/{geoPlace}/{price}$");
        }
    }
}
