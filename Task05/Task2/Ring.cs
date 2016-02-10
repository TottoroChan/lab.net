using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Ring : Circle
    {
        public double inner_r { get; set; } // внутренний радиус кольца

        public Ring()
        {
            o = new Point(0, 0);
            outer_r = 1;
            inner_r = 2;
        }    
        
        public Ring(Point o, double r1, double r2)
        {
            this.o = o;
            this.outer_r = r1;
            this.inner_r = r2;
        }

        public double Area()
        {
            if (outer_r > inner_r)
                return Math.PI * outer_r * outer_r - Math.PI * inner_r * inner_r;
            else
                return Math.PI * inner_r * inner_r - Math.PI * outer_r * outer_r;
        }
    }
}
