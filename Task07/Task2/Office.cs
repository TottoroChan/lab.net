using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
	class Office
	{
		public string personName { get; set; }

		/// <summary>
		///  конструктор, создающй содрудника с заданным именем 
		/// </summary>
		public Office(string name)
		{
			personName = name;
		}

		/// <summary>
		/// Сотрудник приходит на работу
		/// </summary>
		public static void CameToWork(Office name)
		{
			Console.WriteLine("[На работу пришёл {0}]", name);

			if (OnCameToWork != null)
				OnCameToWork(name);

			OnCameToWork += name.Greeting;
			OnGoHome += name.Farewell;

			Console.WriteLine();
		}

		/// <summary>
		/// Сотрудник уходит домой
		/// </summary>
		public static void GoHome(Office name)
		{
			Console.WriteLine("[{0} ушёл домой.]", name);

			OnCameToWork -= name.Greeting;
			OnGoHome -= name.Farewell;

			if (OnGoHome != null)
				OnGoHome(name);

			Console.WriteLine();
		}

		/// <summary>
		/// Приветствие в зависимости от текущего времени.
		/// </summary>
		public void Greeting(Office anotherPerson)
		{
			string greet;
			if (DateTime.Now.Hour < 12)
				greet = "Доброе утро";
			else if (DateTime.Now.Hour < 17)
				greet = "Добрый день";
			else greet = "Добрый вечер";

			Console.WriteLine("'{0}, {1}!', - сказал {2}.", greet, anotherPerson, this);
		}

		/// <summary>
		///  Прощание
		/// </summary>
		public void Farewell(Office anotherPerson)
		{
			Console.WriteLine("'До свидания, {0}!', - сказал {1}.", anotherPerson, this);
		}

		//События 
		public delegate void Message (Office name);
		public static event Message OnCameToWork;
		public static event Message OnGoHome;

		//переопределение ToString
		public override string ToString()
		{
			return personName;
		}
	}
}
