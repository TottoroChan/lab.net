using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Rectangle : Figure
    {
        public Point a { get; set; }
        public Point b { get; set; }
        public Point c { get; set; }
        public Point d { get; set; }

        public Rectangle()
        {
            a = new Point(0, 0);
            b = new Point(0, 3);
            c = new Point(4, 3);
            d = new Point(4, 0);
        }
        public Rectangle(Point a, Point c)
        {
            this.a = a;
            b = new Point(c.x, a.y);
            this.c = c;
            d = new Point(a.x, c.y);
        }

        public double Area()
        {
            return Dist(a, b) * Dist(a, d);
        }

        public double Perimetr()
        {
            return Dist(b, a) + Dist(b, c) + Dist(c, d) + Dist(a, d);
        }

        public override void Draw()
        {
            if ((a.y - c.y) == (c.x - a.x)) Console.WriteLine("Квадрат.");
            else Console.WriteLine("Прямоугольник.");
            Console.WriteLine("Координаты вершин: A{0}, B{1}, C{2}, D{3}.", a.ToString(), b.ToString(), c.ToString(), d.ToString());
            Console.WriteLine("Высота {0}, ширина {1}, площадь {2}, периметр {3}.", Dist(b,a), Dist(d,a), Area(), Perimetr());
        }
    }
}
