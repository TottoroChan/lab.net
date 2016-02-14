using System;

namespace Task1
{
    class Program
    {
		/// <summary>
		///  делегат сравнения элементов массива
		/// </summary>
		public delegate int StringCompare(string s1, string s2);

		static public int CompareByLength (string a, string b)
		{
			if (a.Length == b.Length) return 0;
			else if (a.Length > b.Length) return 1;
			else return -1;
		}

		static public int CompareByAlphabet(string a, string b)
		{
			return a.CompareTo(b);
		}

		/// <summary>
		///  сортировка элементов массива
		/// </summary>
		static public void Sort (string[] str, StringCompare compare1, StringCompare compare2)
		{
			string temp;
			for (int i = 0; i < str.Length - 1; i++)
			{
				for (int j = i + 1; j < str.Length; j++)
				{
					if (compare1(str[i], str[j]) == 1)
					{
						temp = str[i];
						str[i] = str[j];
						str[j] = temp;
					}
					if ((compare1(str[i], str[j]) == 0)
						&&(compare2(str[i], str[j]) == 1))
					{
						temp = str[i];
						str[i] = str[j];
						str[j] = temp;
					}
				}
			}
		}

		static void Main(string[] args)
        {
            string[] str;
			string s;
			StringCompare compare1 = new StringCompare(CompareByLength);
			StringCompare compare2 = new StringCompare(CompareByAlphabet);

			Console.WriteLine("Введите строку:");
			s = Console.ReadLine();
			str = s.Split(' ');
			
			Sort(str, compare1, compare2);
			for (int i = 0; i < str.Length; i++)
				Console.Write("{0} ", str[i]);
			Console.WriteLine();

			Console.Write("Нажмите любую клавишу для закрытия программы.");
            Console.ReadKey();
        }
    }
}
