using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	/// <summary>
	///  Класс Person хранит номер человека и ссылку на следующего
	/// </summary>
	class Person
	{
		public int number;
		public Person next;
		public Person previous;

		public Person(int n)
		{
			number = n;
			next = null;
		}
	}
}
