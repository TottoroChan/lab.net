using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Ring : Round
    {
        public double rr { get; set; } // внутрненний радиус кольца

        public Ring()
        {
            o = new Point(0, 0);
            rr = 1;
            r = 2;
        }

        public Ring(Point o, double r1, double r2)
        {
            this.o = o;
            this.r = r1;
            this.rr = r2;
        }

        public new double Area()
        {
            return Math.PI * r * r - Math.PI * rr * rr;
        }

        public override void Draw()
        {
            Console.WriteLine("Кольцо.");
            Console.WriteLine("Координаты центра O{0}, внешний радиус {1}, внутренний радиус {2}, площадь {3}.", o.ToString(), r, rr, Area());
        }

    }
}
