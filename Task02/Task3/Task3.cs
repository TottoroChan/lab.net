using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int sum = 0;
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                array[i] = rand.Next(-4, 4);
                Console.Write("{0}  ", array[i]);
                if (array[i] > 0) sum += array[i];
            }
            Console.WriteLine();
            Console.WriteLine("Сумма неотрицательных элементов = {0}", sum);

            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
