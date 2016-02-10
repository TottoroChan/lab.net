using System;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1, s2, s3 = " ";
            // s1, s2 - строки для ввода; s3 - результирующая строка;
            Console.Write("Введите первую строку: ");
            s1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            s2 = Console.ReadLine();
            foreach (char c in s1)
            {
                if (s2.Contains(c))
                {
                    s3 += c;
                    s3 += c;
                }
                else s3 += c;
            }
            Console.WriteLine("Результирующая трока: {0}", s3);

            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
