using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, star, k = 0, space;
            ///n - количество строк. star - количество звёздочек в строке  k - если число болше 0, то программу можно завершить. 
            ///space - количество пробелов.
            Console.WriteLine("Введите число строк:");

            do
            {
                Console.Write("n = ");
                n = Convert.ToInt32(Console.ReadLine());
                
                if (n > 0)
                {
                    for (int tree = 0; tree < n; tree++)
                    {
                        space = n - 1;
                        star = 1;
                        for (int i = 0; i <= tree; i++) //вывод елочки.
                        {
                            for (int j = 0; j < space; j++) //вывод в консоли пробелов и звёздочек.
                                Console.Write(" ");
                            for (int l = 0; l < star; l++)
                                Console.Write("*");
                            Console.WriteLine();
                            space--;
                            star += 2;
                        }
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
