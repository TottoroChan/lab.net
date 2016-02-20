using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите путь к папке:");
			string path = Console.ReadLine();
			FileWatcher Watcher = new FileWatcher(path);

			int i = 0;
			do
			{
				Console.WriteLine("-----------------------------------------");
				Console.WriteLine(">>>Выберите режим:");
				Console.WriteLine("1 | Наблюдение.");
				Console.WriteLine("2 | Откат изменений.");
				Console.WriteLine("-----------------------------------------");
				Console.WriteLine("0 | Выход");
				Console.WriteLine("-----------------------------------------");
				int switchOne;
				switchOne = Convert.ToInt32(Console.ReadLine());
				switch (switchOne)
				{
					case 1:
						Console.WriteLine(">>>Включен режим наблюдения.");
						Watcher.Watching();
						break;
					case 2:
						Console.WriteLine(">>>Включен режим отката изменений.");
						Watcher.Recovery();
						break;
					case 0:
						i++;
						break;
					default:
						Console.WriteLine(">>>Ошибка: неверное действие");
						break;
				}
			} while (i == 0);
		}
	}
}
