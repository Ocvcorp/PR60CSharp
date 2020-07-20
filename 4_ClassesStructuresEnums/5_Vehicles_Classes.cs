using System;

namespace GameClasses
{
    class Point
    {
        public double x;
        public double y;
        public Point (double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class HorseCarriage
    {
        private string name;
        private Point coords;
        public static int fatigueLevel = 100;
        public HorseCarriage(string name, Point coords)
        {
            this.name = name;
            this.coords = coords;
        }
        public void move(Point newCoords) 
        {
            coords = newCoords;
            fatigueLevel -= 20;
        }
        public void showInfo()
        {
            Console.WriteLine("{0,10}\t{1,5},{2,5}\t{3,10}", name, coords.x, coords.y, fatigueLevel);
        }
    }
    class Car
    {
        private string name;
        private Point coords;
        public static int gasoline= 100;
        public Car(string name, Point coords)
        {
            this.name = name;
            this.coords = coords;
        }
        public void move(Point newCoords)
        {
            coords = newCoords;
            gasoline-= 15;
        }
        public void showInfo()
        {
            Console.WriteLine("{0,10}\t{1,5},{2,5}\t{3,10}", name, coords.x, coords.y, gasoline);
        }
    }
    class Airplane
    {
        private string name;
        private Point coords;
        public static int engineRes= 100;
        public Airplane(string name, Point coords)
        {
            this.name = name;
            this.coords = coords;
        }
        public void move(Point newCoords)
        {
            coords = newCoords;
            engineRes-= 5;
        }
        public void showInfo()
        {
            Console.WriteLine("{0,10}\t{1,5},{2,5}\t{3,10}", name, coords.x, coords.y, engineRes);
        }
    }
    class Boat
    {
        private string name;
        private Point coords;
        public static int captainGin= 100;
        public Boat(string name, Point coords)
        {
            this.name = name;
            this.coords = coords;
        }
        public void move(Point newCoords)
        {
            coords = newCoords;
            captainGin-= 10;
        }
        public void showInfo()
        {
            Console.WriteLine("{0,10}\t{1,5},{2,5}\t{3,10}", name, coords.x, coords.y, captainGin);
        }
    }
}
