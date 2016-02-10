using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты центра круга:");
            Console.Write("x=");
            double x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y=");
            double y = Convert.ToInt32(Console.ReadLine());
            Point o = new Point(x, y);
            Console.WriteLine("Введите радиус круга:");
            Console.Write("r=");
            double r = Convert.ToInt32(Console.ReadLine());
            Round R = new Round(o, r);
            Console.WriteLine("Площадь круга = {0}", R.Area());
            Console.WriteLine("Длина окружности круга = {0}", R.LengthR());

            Console.Write("\nНажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
