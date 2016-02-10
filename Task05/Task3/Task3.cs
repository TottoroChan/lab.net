using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            
            do
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 | Создать линию.");
                Console.WriteLine("2 | Создать прямоугольник.");
                Console.WriteLine("3 | Создать окружность.");
                Console.WriteLine("4 | Создать круг.");
                Console.WriteLine("5 | Создать кольцо.");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("0 | Выход.");
                Console.WriteLine("---------------------------------------------------");
                int switchOne;
                switchOne = Convert.ToInt32(Console.ReadLine());
                switch (switchOne)
                {
                    case 0:
                        i++;
                        break;
                    case 1:
                        double x, y;
                        Console.WriteLine("Введите координаты точки A:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        Point a = new Point(x, y);
                        Console.WriteLine("Введите координаты точки B:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        Point b = new Point(x, y);
                        Line L = new Line(a, b);
                        L.Draw();
                        break;
                    case 2:
                        Console.WriteLine("Введите координаты верхней левой точки A:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        a = new Point(x, y);
                        Console.WriteLine("Введите координаты нижней правой точки C:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        b = new Point(x, y);
                        Rectangle R = new Rectangle(a, b);
                        R.Draw();
                        break;
                    case 3:
                        Console.WriteLine("Введите координаты центра:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        Point o = new Point(x, y);
                        Console.WriteLine("Введите радиус:");
                        Console.Write("r=");
                        double r = Convert.ToDouble(Console.ReadLine());
                        Circle C = new Circle(o, r);
                        C.Draw();
                        break;
                    case 4:
                        Console.WriteLine("Введите координаты центра:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        o = new Point(x, y);
                        Console.WriteLine("Введите радиус:");
                        Console.Write("r=");
                        r = Convert.ToDouble(Console.ReadLine());
                        Round R1 = new Round(o, r);
                        R1.Draw();
                        break;
                    case 5:
                        Console.WriteLine("Введите координаты центра:");
                        Console.Write("x=");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("y=");
                        y = Convert.ToInt32(Console.ReadLine());
                        o = new Point(x, y);
                        Console.WriteLine("Введите внешний радиус кольца:");
                        Console.Write("r=");
                        double r1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите внутренний радиус кольца:");
                        Console.Write("r=");
                        double r2 = Convert.ToDouble(Console.ReadLine());
                        Ring R2 = new Ring(o, r1, r2);
                        R2.Draw();
                        break;
                    default:
                        Console.WriteLine("Ошибка: неверное действие.");
                        break;
                }
            } while (i == 0);
        }
    }
}
