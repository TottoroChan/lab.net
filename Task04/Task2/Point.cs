using System;

namespace Task2
{
    class Point
    {
        private double x, y;

        public void set(double x1, double y1)
        {
            x = x1;
            y = y1;
            return;
        }
        public void get(out double x1, out double y1)
        {
            x1 = x;
            y1 = y;
            return;
        }
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
            double x1, x2, y1, y2, n, m;
            a.get(out x1, out y1);
            b.get(out x2, out y2);
            n = (x2 - x1) * (x2 - x1);
            m = (y2 - y1) * (y2 - y1);
            n += m;
            x1 = a.x;
            y1 = a.y;
            x2 = b.x;
            y2 = b.y;
            return Math.Sqrt(n);

        }
    }
}
