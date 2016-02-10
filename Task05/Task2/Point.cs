using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Point
    {
        public double x { get; private set; }
        public double y { get; private set; }

        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(double x1, double y1)
        {
            x = x1;
            y = y1;
        }

        public double Dist(Point a, Point b)
        {
            return Math.Sqrt(((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y)));
        }        
    }
}
