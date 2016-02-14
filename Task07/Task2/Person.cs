using System;

namespace Task2
{
	/// <summary>
	///  Событие времени
	/// </summary>
	
	public class TimeEvent : EventArgs
	{
		public DateTime TimeReached { get; set; }
	}

	public class Person
	{
		public string name;
		public event EventHandler<TimeEvent> Came;
		public string greet;

		public virtual void OnCame(TimeEvent e)
		{
				CameToWork();
			if (Came != null)
				Came(this, e);
		}

		/// <summary>
		///  конструктор класса
		/// </summary>
		public Person(string n)
		{
			TimeEvent args = new TimeEvent();
			name = n;
			args.TimeReached = DateTime.Now;
			if (args.TimeReached.Hour < 12)
				greet = "Доброе утро";
			else if (args.TimeReached.Hour < 17)
				greet = "Добрый день";
			else greet = "Добрый вечер";
			OnCame(args);
		}
		
		public void Greeting (string anotherPerson)
		{
			Console.WriteLine("'{0}, {1}!', - сказал {2}.", greet , anotherPerson, name);
		}

		public void Farewell(string anotherPerson)
		{
			Console.WriteLine("'До свидания, {0}!', - сказал {1}.", anotherPerson, name);
		}

		public void CameToWork()
		{
			Console.WriteLine("[На работу пришёл {0}]", this.name);
		}

		public void GoHome ()
		{
			Console.WriteLine("[{0} ушёл домой.]", this.name);
		}
	}
}
