using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

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

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}
