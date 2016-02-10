using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
			string str;

			Console.WriteLine("Введите строку:");
			str = Console.ReadLine();
			string[] strarr = str.Split('\r', '\n', ' ', ',', '.', ':', ';', '\"', '!', '?');

			for (int i = 0; i < strarr.Length; i++)
			{

				if (strarr[i] != null)
				{
					int count = 0;
					for (int j = 0; j < strarr.Length; j++)
					{
						if ((strarr[j] != null)
							&& (strarr[i].ToLower().Equals(strarr[j].ToLower())))
							{
								if (i != j) strarr[j] = null;
								count++;
							}
					}
					Console.WriteLine("{0} {1}", strarr[i], count);
				}
			}


			Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
