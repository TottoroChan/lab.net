using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	class ListEnumerator<T> : IEnumerator<T>
	{
		private List<T> Collection;
		private int curIndex;
		private T curElem;

		public ListEnumerator(List<T> l)
		{
			Collection = l;
			curIndex = -1;
			curElem = default(T);
		}

		public T Current
		{
			get { return curElem; }
		}

		object IEnumerator.Current
		{
			get { return Current; }
		}

		void IDisposable.Dispose() { }

		public bool MoveNext()
		{
			if (++curIndex >= Collection.Count)
				return false;
			else
				curElem = Collection[curIndex];
			return true;
		}

		public void Reset()
		{
			curIndex = -1;
		}
	}
}
