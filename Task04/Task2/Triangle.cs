using System;

namespace Task2
{
    class Triangle : Point
    {
        private Point a, b, c;

        public Triangle()
        {
            a = new Point(0, 0);
            b = new Point(0, 1);
            c = new Point(1, 1);
        }

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;            
        }

        public double Area()
        {
            double p = (Dist(b, a) + Dist(c, b) + Dist(c, a))/2;
            return Math.Sqrt(p * (p - Dist(a, b)) * (p - Dist(b, c)) *(p - Dist(c, a)));
        }

        public double Perimetr()
        {
            return Dist(b, a) + Dist(c, b) + Dist(c, a);
        }
    }
}
