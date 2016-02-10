using System;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[3, 3, 3];
            Random rand = new Random();

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        array[i, j, k] = rand.Next(-3,3);
                        Console.Write("{0}  ", array[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.WriteLine("Изменённый массив:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (array[i, j, k] > 0)
                            array[i, j, k] = 0;
                        Console.Write("{0}  ", array[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            
            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
