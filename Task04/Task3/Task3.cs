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
            string s, n, p;
            int d, m, y;

            Console.WriteLine("Введите фамилию");
            s = Console.ReadLine();
            Console.WriteLine("Введите имя");
            n = Console.ReadLine();
            Console.WriteLine("Введите отчество");
            p = Console.ReadLine();
            Console.WriteLine("Введите дату рождения:");
            Console.Write("День:");
            d = Convert.ToInt32(Console.ReadLine());
            Console.Write("Месяц:");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Год:");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            User U = new User(s, n, p, d, m, y);
            U.Print();

            Console.Write("\nНажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
