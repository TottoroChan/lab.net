using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s, n, p, wp;
            int d, m, y, we;

            Console.WriteLine("Введите фамилию:");
            s = Console.ReadLine();
            Console.WriteLine("Введите имя:");
            n = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            p = Console.ReadLine();
            Console.WriteLine("Введите дату рождения:");
            Console.Write("День:");
            d = Convert.ToInt32(Console.ReadLine());
            Console.Write("Месяц:");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Год:");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите должность:");
            wp = Console.ReadLine();
            Console.WriteLine("Введите стаж работы:");
            we = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            DateTime date = new DateTime(y, m, d);
            Employee user = new Employee(s, n, p, date, we, wp);
            user.Print();

            Console.Write("\nНажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
