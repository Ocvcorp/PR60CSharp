using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruits
{
    public enum VegShape
    {
        Round,
        Oval,
        Elongated
    }
    class Vegetable
    {
        protected string geoPlace;
        public string name;
        private double price;
        public VegShape shape;
        public Vegetable(string geoPlace, string name, double price, VegShape shape)
        {
            this.geoPlace = geoPlace;
            this.name = name;
            this.price = price;
            this.shape = shape;
        }
        protected double Price => price;
    }
    class Potato : Vegetable
    {
        private string sort;
        private double midVolume;
        public static bool isRootCrop = true;
        public Potato(string sort, double midVolume,
                    string geoPlace, string name, double price, VegShape shape) : base(geoPlace, name, price, shape)
        {
            this.sort = sort;
            this.midVolume = midVolume;
        }
        public double getPrice()
        {
            return Price;
        }
        public void getInfo()
        {
            Console.WriteLine("A Vegetable {0} from {1}\nA sort {2} with medium volume {3:F2}ml of {4} shape\nCost {5} $",
                               name, geoPlace, sort, midVolume, shape, Price);
        }
    }
    enum VegColor
    {
        Red,
        Blue,
        Orange,
        Green,
        Yellow,
        Violet
    }
    class Tomato : Vegetable
    {
        private VegColor color;
        private string harvestDate;
        public static bool isRootCrop = false;
        public Tomato(VegColor color, string harvestDate,
                    string geoPlace, string name, double price, VegShape shape) : base(geoPlace, name, price, shape)
        {
            this.color = color;
            this.harvestDate = harvestDate;
        }
        public double getPrice()
        {
            return Price;
        }
        public void getInfo()
        {
            Console.WriteLine("A Vegetable {0} from {1}\nA color {2}, harvest date {3} of {4} shape\nCost {5} $",
                               name, geoPlace, color, harvestDate, shape, Price);
        }

    }
}
