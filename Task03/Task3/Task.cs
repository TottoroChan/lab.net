using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch speed1 = new Stopwatch(); //время работы string
            Stopwatch speed2 = new Stopwatch(); // время работы StringBuilder
            string str = " ";
            StringBuilder sb = new StringBuilder();
            int N = 100;
            speed1.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            speed1.Stop();

            speed2.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            speed2.Stop();
            Console.WriteLine("Время работы string = {0}\nВремя работы StringBuilder = {1}", speed1.Elapsed, speed2.Elapsed);
            if (speed1.Elapsed < speed2.Elapsed)
                Console.WriteLine("string работает быстрее");
            else Console.WriteLine("StringBuilder работает быстрее");

            Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
