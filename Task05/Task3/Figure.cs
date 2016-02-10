using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class Figure
    {
       public virtual void Draw() { }

       public double Dist(Point a, Point b) //расстояние между двумя точками
       {
           return Math.Sqrt(((b.x - a.x) * (b.x - a.x) + (b.y - a.y) * (b.y - a.y)));
       }
    }
}
