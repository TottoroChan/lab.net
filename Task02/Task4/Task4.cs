using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5,5];
            Random rand = new Random();
            int sum = 0;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = rand.Next(20);
                    Console.Write("{0}  ", array[i, j]);
                    if (((i + j) % 2 == 0)) sum += array[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма элементов на четных позициях = {0}", sum);
            
            Console.Write("Нажмите любую клавишу для закрытия программы.");
                Console.ReadKey();
        }
    }
}
