using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, k = 0; 
            ///a, b - стороны прямоугольника. k - если число болше 0, то программу можно завершить.
            Console.WriteLine("Введите стороны прямоугольника:");
            do
            {
                Console.Write("a = ");
                a = Convert.ToInt32(Console.ReadLine());
                if (a <= 0)
                {
                    Console.WriteLine("Такой стороны не может быть.");
                }
                else
                {
                    Console.Write("b = ");
                    b = Convert.ToInt32(Console.ReadLine());
                    if (b <= 0)
                    {
                        Console.WriteLine("Такой стороны не может быть.");
                    }
                    else
                    {
                        Console.WriteLine("Площадь прямоугольника = {0}", a * b);
                        k++;
                    }
                }

            } while (k == 0);



            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
