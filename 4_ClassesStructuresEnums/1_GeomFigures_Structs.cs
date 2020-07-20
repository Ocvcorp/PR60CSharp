using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    struct Point
    {
        public double x;
        public double y;
        public Point(double x0, double y0)
        {
            x = x0;
            y = y0;
        }
        public double Distance(double xN, double yN)
        {
            return Math.Sqrt((x - xN)* (x - xN) + (y - yN)*(y - yN));
        }
        public void showInfo()
        {
            Console.WriteLine("The point: ({0:F2},{1:F2})", x, y);
        }
    }
    struct Line
    {
        public Point p1;
        public Point p2;
        public Line(Point p01, Point p02)
        {
            p1 = p01;
            p2 = p02;
        }
        public void isPointOnLine(Point p)
        {
            double distP1_P = p1.Distance(p.x, p.y);
            double distP2_P = p2.Distance(p.x, p.y);
            double distP1_P2 = p2.Distance(p1.x, p1.y);
            double eps = .0001;
            if (Math.Abs(distP1_P2-distP1_P-distP2_P)<eps)
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) belongs the line",p.x,p.y);
            }
            else
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) doesn't belong the line", p.x, p.y);
            }
        }
        public void showLineLength()
        {
            Console.WriteLine("The line length is {0:F2}", p2.Distance(p1.x, p1.y));
        }
        public void showInfo()
        {
            Console.WriteLine("The line: p1({0:F2},{1:F2})-p2({2:F2},{3:F2})", p1.x, p1.y, p2.x, p2.y);
            showLineLength();
        }
    }
    struct Square//with sides parallel to XY axis
    {
        public double sideLength;
        public Point leftBottomCorner;
        public Square(double sSide, Point p0)
        {
            sideLength = sSide;
            leftBottomCorner = p0;
        }
        public void isPointInside(Point p)
        {
            double deltaX = Math.Abs(p.x - leftBottomCorner.x)-sideLength;
            double deltaY = Math.Abs(p.y - leftBottomCorner.y)-sideLength;
            double eps = 0.0001;
            if ((deltaX<eps)&&(deltaY < eps))
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is inside the square", p.x, p.y);
            }
            else
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is out the square", p.x, p.y);
            }            
        }
        public void showSquarePerimetr()
        {
            Console.WriteLine("Square perimetr is {0:F2} m, square is {1:F2} m2", 4 * sideLength, sideLength * sideLength);
        }
        public void showInfo()
        {
            Console.WriteLine("The square: origin({0:F2},{1:F2})-side {2:F2}", leftBottomCorner.x, leftBottomCorner.y, sideLength);
            showSquarePerimetr();
        }
    }
    struct Circle
    {
        public Point centerP;
        public double radius;
        public Circle(double r0, Point p0)
        {
            radius= r0;
            centerP = p0;
        }
        public void isPointInside (Point p)
        {
            double deltaR = Math.Sqrt((p.x - centerP.x)* (p.x - centerP.x) - (p.y - centerP.y) * (p.y - centerP.y))-radius;
            double eps = 0.0001;
            if (deltaR < eps)
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is inside the circle", p.x, p.y);
            }
            else
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is out the circle", p.x, p.y);
            }
        }
        public void showSquarePerimetr()
        {
            Console.WriteLine("Circlr perimetr is {0:F2} m, square is {1:F2} m2", 2*Math.PI * radius, Math.PI * radius*radius);
        }
        public void showInfo()
        {
            Console.WriteLine("The circle: origin({0:F2},{1:F2}) - radius{2:F2}", centerP.x, centerP.y, radius);
            showSquarePerimetr();
        }
    }
    struct Rectangle//with sides parallel to XY axis
    {
        public double length;//by oX axis
        public double width;//by oY axis
        public Point leftBottomCorner;
        public Rectangle(double l0, double w0, Point p0)
        {
            length= l0;
            width = w0;
            leftBottomCorner = p0;
        }
        public void isPointInside(Point p)
        {
            double deltaX = Math.Abs(p.x - leftBottomCorner.x) - length;
            double deltaY = Math.Abs(p.y - leftBottomCorner.y) - width;
            double eps = 0.0001;
            if ((deltaX < eps) && (deltaY < eps))
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is inside the rectangle", p.x, p.y);
            }
            else
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is out the rectangle", p.x, p.y);
            }
            
        }
        public void showSquarePerimetr()
        {
            Console.WriteLine("Rectangle perimetr is {0:F2} m, square is {1:F2} m2", 2 * (length+width), length* width);
        }
        public void showInfo()
        {
            Console.WriteLine("The rectangle: origin({0:F2},{1:F2}) / \'x\'side {2:F2}/\'y\'side {3:F2}", leftBottomCorner.x, leftBottomCorner.y, length, width);
            showSquarePerimetr();
        }
    }
    struct Rhomb//with axis parallel to XY axis
    {
        public double xAxisLength;//by oX axis
        public double yAxisLength;//by oY axis
        public Point axisCenter;
        public Rhomb(double xA0, double yA0, Point c0)
        {
            xAxisLength= xA0;
            yAxisLength = yA0;
            axisCenter = c0;
        }
        public void isPointInside(Point p)
        {
            double xSh = Math.Abs(p.x - axisCenter.x);
            double ySh = Math.Abs(p.y - axisCenter.y);
            double deltaX = xAxisLength/2-xSh;
            double eps = 0.0001;
            double dyMax;
            bool res = false;
            if ((deltaX > -eps) && (yAxisLength / 2 - ySh > -eps))
            {
                dyMax = deltaX * yAxisLength / xAxisLength;
                if (dyMax-ySh>-eps)
                {
                    res = true;
                }
            }
            if (res)
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is inside the rhomb", p.x, p.y);
            }
            else
            {
                Console.WriteLine("The point ({0:F2},{1:F2}) is out the rhomb", p.x, p.y);
            }
        }
        public void showSquarePerimetr()
        {
            Console.WriteLine("Rhomb perimetr is {0:F2} m, square is {1:F2} m2",  2*Math.Sqrt(xAxisLength*xAxisLength+ yAxisLength*yAxisLength), .5*(xAxisLength*yAxisLength));
        }
        public void showInfo()
        {
            Console.WriteLine("The rhomb: origin({0:F2},{1:F2})/\'x\'axis{2:F2}/\'y\'axis{3:F2}", axisCenter.x, axisCenter.y, xAxisLength,yAxisLength);
            showSquarePerimetr();
        }
    }
}





















