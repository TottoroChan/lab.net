using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Circle : Figure
    {
        public Point o { get; set; }
        public double r { get; set; }
        
        public Circle()
        {
            o = new Point(0, 0);
            r = 1;
        }

        public Circle(Point o, double r)
        {
            this.o = o;
            this.r = r;
        }

        public double Length()
        {
            return Math.PI * 2 * r;
        }

        public override void Draw()
        {
            Console.WriteLine("Окружность.");
            Console.WriteLine("Центр в точке O{0}, радиус {1}, длина окружности {2}.", o.ToString(), r, Length());
        }
    }
}
