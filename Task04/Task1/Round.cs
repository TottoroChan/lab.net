using System;

namespace Task1
{
    public class Round
    {
        protected Point o;
        protected double r;
         
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

        public double LengthR()
        {
            return Math.PI * 2 * r;
        }
    }
}
