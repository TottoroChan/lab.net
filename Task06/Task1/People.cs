using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	public class People
	{
		private Person current;
		private int n;

		public People() : this(2) { }

		/// <summary>
		///  который создаёт список людей в кругу 
		/// и делает его циклическим.
		/// </summary>
		public People(int n)
		{
			this.n = n;
			current = new Person(1);
			Person p = current;
			for (int i = 1; i < n; i++)
			{
				p.next = new Person(i + 1);
				p.next.previous = p;
				p = p.next;
			}
			p.next = current;
			current.previous = p;
			current = current.previous;
		}

		/// <summary>
		///  Метод удаляющий каждого второго чловека в кругу.
		/// </summary>
		public void Count()
		{
			while (n > 0)
			{
				current = current.next.next;

				current = current.previous;
				current.next.next.previous = current;
				current.next = current.next.next;
				n--;
			}
		}

		/// <summary>
		///  Метод вывода последнего человека на экран.
		/// </summary>
		public int Print()
		{
			return current.number;
		}	
	}
}