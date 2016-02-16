using System;

namespace Task1
{
	public static class DataHelper
	{
		/// <summary>
		/// Расширяющий метод, считающий сумму элементов массива
		/// </summary>
		/// <param name="array">Массив с элементами.</param>
		public static int Sum(this int[] array)
		{
			int sum = 0;
			for (int i = 0; i < array.Length; i++)
				sum += array[i];
			return sum;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			int correct = 0; //Индикатор корректности ввода данных.
			Console.WriteLine("Введите длину массива:");
			
			do
			{
				int n = Convert.ToInt32(Console.ReadLine());
				if (n > 0)
				{
					correct++;
					int[] array = new int[n];
					Console.WriteLine
						("Введите элементы массива через пробел:");
					do
					{
						string str = Console.ReadLine();
						string[] arrstring = str.Split(' ');
						if (arrstring.Length != n)
						{
							Console.WriteLine
							("Количество элементов не совпадает с длиной ");
							Console.WriteLine
							("Введите другие элменты.");

						}
						else
						{
							correct++;
							for (int i = 0; i < n; i++)
								array[i] = Convert.ToInt32(arrstring[i]);
							Console.WriteLine("Сумма элементов массива = {0}",
																array.Sum());
						}
					}
					while (correct == 1);
				}
				else
				{
					Console.WriteLine
						("Длина массива должна быть натуральным числом.");
					Console.WriteLine
						("Введите другое число.");
				}
			}
			while (correct == 0);

			Console.Write("Нажмите любую клавишу для закрытия программы.");
			Console.ReadKey();
		}
	}
}
