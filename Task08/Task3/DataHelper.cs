using System;
using System.Diagnostics;
using System.Linq;

namespace Task3
{
	public static class DataHelper
	{
		/// <summary>
		/// Метод, сортирующий массив
		/// </summary>
		/// <param name="array">Массив с элементами Stopwatch.</param>
		public static void TimeSort (this Stopwatch[] array)
		{
			Stopwatch temp = new Stopwatch();
            for (int i = 0; i<array.Length; i++)
				for (int j = i+1; j<array.Length;j++)
				{
					if (array[i].Elapsed > array[j].Elapsed)
						temp = array[i];
						array[i] = array[j];
						array[j] = temp;
				}
		}

		/// <summary>
		/// Метод заполняет массив случайными элементами
		/// </summary>
		/// <param name="array">Массив с элементами.</param>
		public static void Randomizer (this int[] array)
		{
			Random rand = new Random();
			for (int i = 0; i < array.Length; i++)
				array[i] = rand.Next(201) - 100;
		}

		/// <summary>
		/// Обычный поиск положительных элементов
		/// </summary>
		/// <param name="array">Массив с элементами.</param>
		public static void SearchOfElements(this int[] array)
		{
			int pos = 0;
			array.Randomizer();
			for (int i = 0; i < array.Length; i++)
				if (array[i] > 0) pos++;
		}

		/// <summary>
		/// Метод, которому условие поиска передаётся через делегат;
		/// </summary>
		/// <param name="array">Массив с элементами.</param>
		public static void SearchByDelegat(this int[] array, Elements positive)
		{
			int pos = 0;
			array.Randomizer();
			for (int i = 0; i < array.Length; i++)
				if (positive(array[i]) == true)
					pos++;
		}

		/// <summary>
		/// Метод, которому условие поиска передаётся через делегат 
		/// в виде анонимного метода
		/// </summary>
		/// <param name="array">Массив с элементами.</param>
		public static void SearchByAnonimDelegat(this int[] array)
		{
			int pos = 0;
			Elements positive = delegate (int i)
			{
				if (i > 0) return true;
				else return false;
			};
			array.Randomizer();
			for (int i = 0; i < array.Length; i++)
				if (positive(array[i]) == true)
					pos++;
		}

		/// <summary>
		/// Лямбда-выражения
		/// </summary>
		/// <param name="array">Массив с элементами.</param>
		public static void SearchByLambda(this int[] array)
		{
			int pos = 0;
			Elements positive = (i) =>
			{
				if (i > 0) return true;
				else return false;
			};
			array.Randomizer();
			for (int i = 0; i < array.Length; i++)
				if (positive(array[i]) == true)
					pos++;
		}

		/// <summary>
		/// LINQ-выражения
		/// </summary>
		/// <param name="array">Массив с элементами.</param>		
		public static void SearchByLINQ(this int[] array)
		{
			array.Randomizer();
			var pos = from i in array
					  where i > 0
                      select i;
		}


		public delegate bool Elements(int i);

		static public bool positive(int i)
		{
			if (i > 0)
				return true;
			else return false;
		}

	}
}
