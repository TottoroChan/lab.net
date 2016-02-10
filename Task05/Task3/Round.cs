using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Round : Circle
    {
        public Round()
        {
            o = new Point(0, 0);
            r = 1;
        }

        public Round(Point o, double r)
        {
            this.o = o;
            this.r = r;
        }
        public double Area()
        {
            return Math.PI * r * r;
        }

        public override void Draw()
        {
            Console.WriteLine("Круг.");
            Console.WriteLine("Координаты центра O{0}, радиус {1}, площадь {2}, длина окружности {3}", o.ToString(), r, Area(), Length());
        }
    }
}
