using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
			int n;
			Console.WriteLine("Введите количество человек в кругу:");
			n = Convert.ToInt32(Console.ReadLine());
			if (n<0)
			{
				Console.WriteLine("Число должно быть положительным");
				n = Convert.ToInt32(Console.ReadLine());
			}

			People P = new People(n);
			P.Count();
			Console.WriteLine("Останется человек под номером {0}", P.Print());

            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
