using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты центра:");
            Console.Write("x=");
            double x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            double y = Convert.ToInt32(Console.ReadLine());
            Point o = new Point(x, y);
            Console.WriteLine("Введите внешний радиус кольца:");
            Console.Write("r=");
            double r1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите внутренний радиус кольца:");
            Console.Write("r=");
            double r2 = Convert.ToDouble(Console.ReadLine());
            Ring R = new Ring(o, r1, r2);
            Console.WriteLine("Площадь кольца = {0}", R.Area());
            Console.WriteLine("Длина внешней и внутренней границы кольца = {0}", R.Length(r1)+R.Length(r2));

            Console.Write("\nНажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
