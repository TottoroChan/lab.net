using System;

namespace Task2
{
	public static class DataHelper
	{
		/// <summary>
		/// Расширяющий метод, проверяет строку на положительное число.
		/// </summary>
		/// <param name="str">Строка с числом.</param>
		public static bool StringToInt (this string str)
		{
			int correct = str.Length; //индекатор цифр в строке.
            for (int i = 0; i< str.Length; i++)
			{
				int c = 0; //индикатор является ли символ цифрой.
				int j = 0;

				if (str[i] == '0')
					c++;
				else if (str[i] == '1')
					c++;
				else if (str[i] == '2')
					c++;
				else if (str[i] == '3')
					c++;
				else if (str[i] == '4')
					c++;
				else if (str[i] == '5')
					c++;
				else if (str[i] == '6')
					c++;
				else if (str[i] == '7')
					c++;
				else if (str[i] == '8')
					c++;
				else if (str[i] == '9')
					c++;
				else if ((str[i] == ',') && (i != 0))
					c++; //если число с действительное число.
				//если символ не цифра, то индикатор уменьшается.
				if (c == 0) correct--; 					
			}
			//если в строке все символы цифры, то строка является числом.
			if (correct == str.Length)
				return true;
			else return false;	
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите строку:");
			string str = Console.ReadLine();
			bool integer = str.StringToInt();
			if (integer == true)
				Console.WriteLine("Строка является положительным числом.");
			else Console.WriteLine("Строка не является положительным числом.");

			Console.Write("Нажмите любую клавишу для закрытия программы.");
			Console.ReadKey();
		}
	}
}
