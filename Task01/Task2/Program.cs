using System;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, star = 1, k = 0; 
            ///n - количество строк. star - количество звёздочек в строке  k - если число болше 0, то программу можно завершить.
            Console.WriteLine("Введите число строк:");

            do
            {
                Console.Write("n = ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0;  j < star; j++) //вывод в консоли звёздочек.
                            Console.Write("*");
                        star++;
                        Console.WriteLine();
                    }
                    k++;
                }
                else Console.WriteLine("Такого числа не может быть.");
            } while (k == 0);

            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
