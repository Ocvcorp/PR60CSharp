using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFruits
{
    public enum FruitShape
    {
        Round,
        Oval,
        Elongated
    }
    class Fruit
    {
        protected string geoPlace;
        public string name;
        private double price;
        public FruitShape shape;
        public Fruit(string geoPlace, string name, double price, FruitShape shape)
        {
            this.geoPlace = geoPlace;
            this.name = name;
            this.price = price;
            this.shape = shape;
        }
        protected double Price => price;
        public virtual void getInfo() {}
        public void fType() 
        {
            Console.WriteLine("This is Fruit without type");
        }
        
    }
    class Apple:Fruit
    {
        private string sort;
        private double midVolume;
        public static bool isRootCrop=false;
        public Apple(string sort, double midVolume,
                    string geoPlace, string name, double price, FruitShape shape):base(geoPlace,name, price, shape)
        {
            this.sort = sort;
            this.midVolume = midVolume;
        }
        public double getPrice()
        {
            return Price;
        }
        public override void getInfo()
        {
            Console.WriteLine("A fruit {0} from {1}\nA sort {2} with medium volume {3:F2}ml of {4} shape\nCost {5} $",
                               name, geoPlace, sort, midVolume, shape, Price);
        }
        public new void fType()
        {
            Console.WriteLine("This is apple");
        }
    }
    enum FruitColor
    {
        Red,
        Blue,
        Orange,
        Green,
        Yellow,
        Violet
    }
    class Berry:Fruit
    {
        private FruitColor color;
        private string harvestDate;
        public static bool isRootCrop = false;
        public Berry(FruitColor color, string harvestDate,
                    string geoPlace, string name, double price, FruitShape shape) : base(geoPlace, name, price, shape)
        {
            this.color = color;
            this.harvestDate = harvestDate;
        }
        public double getPrice()
        {
            return Price;
        }
        public override void getInfo()
        {
            Console.WriteLine("A fruit {0} from {1}\nA color {2}, harvest date {3} of {4} shape\nCost {5} $",
                               name, geoPlace, color, harvestDate, shape, Price);
        }
        public new void fType()
        {
            Console.WriteLine("This is berry");
        }

    }
}
