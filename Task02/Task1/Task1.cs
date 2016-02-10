using System;

namespace _1
{
    class Program
    {
        static void QSort(int L, int R, int[] array)
        {
            int j = R;
            int i = L;
            int x = array[(L + R) / 2];
            do
            {
                while (array[i] < x) i++;
                while (x < array[j]) j--;
                if (i <= j)
                {
                    int t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (L < j) QSort(L, j, array);
            if (i < R) QSort(i, R, array);
        }

        static void Main(string[] args)
        {
            int[] array = new int[10];
            int max, min;
            Random rand = new Random();

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < 10; i++)
            {
                array[i] = rand.Next(20);
                Console.Write("{0}  ", array[i]);
            }
            Console.WriteLine();
            //Быстрая сортировка
            QSort(0, 9, array);

            min = array[0];
            max = array[9];
            Console.WriteLine("Минимальный эллемент массива ={0}  Максимальны эллемент ={1}", min, max);
            Console.WriteLine("Отсортированный массив:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}  ", array[i]);
            }
            Console.WriteLine();

            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
