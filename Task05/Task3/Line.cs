using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Line : Figure
    {
        public Point a { get; set; }
        public Point b { get; set; }

        public Line()
        {
            a = new Point(0, 0);
            b = new Point(1, 0);
        }

        public Line(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        //public virtual double Dist() { }

         public override void Draw()
        {
            Console.WriteLine("Линия.");
            Console.WriteLine("Координаты точки A{0}, координаты точки B{1}, длина линии {2}.", a.ToString(), b.ToString(), Dist(a,b));

        }
    }
}
