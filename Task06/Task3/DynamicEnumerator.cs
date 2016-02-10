using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
	/// <summary>
	///  Реализация IEnumerator
	/// </summary>
	public class DynamicEnumerator<T>
	{
		public int id;
		T[] data;

		public bool MoveNext()
		{
			if (id == data.Length - 1)
			{
				Reset();
				return false;
			}

			id++;
			return true;
		}

		public void Reset()
		{
			id = -1;
		}

		public object Current
		{
			get
			{
				return data[id];
			}
		}
	}

}