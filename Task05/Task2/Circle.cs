using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Circle
    {
        protected Point o { get; set; }
        protected double outer_r { get; set; } // внешний радиус

        public Circle()
        {
            o = new Point(0, 0);
            outer_r = 1;
        }

        public Circle(Point o, double r)
        {
            this.o = o;
            this.outer_r = r;
        }

        public double Length(double r)
        {
            return Math.PI * 2 * r;
        }
    }
}
