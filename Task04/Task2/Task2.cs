using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты вершины треугольника a:");
            Console.Write("x=");
            double x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            double y = Convert.ToInt32(Console.ReadLine());
            Point a = new Point(x, y);
            Console.WriteLine("Введите координаты точки вершины треугольника b:");
            Console.Write("x=");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            y = Convert.ToInt32(Console.ReadLine());
            Point b = new Point(x, y);
            Console.WriteLine("Введите координаты точки вершины треугольника c:");
            Console.Write("x=");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            y = Convert.ToInt32(Console.ReadLine());
            Point c = new Point(x, y);
            Triangle T = new Triangle(a, b, c);
            Console.WriteLine("Площадь треугольника = {0}", T.Area());
            Console.WriteLine("Периметр треугольника = {0}", T.Perimetr());

            Console.Write("\nНажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
