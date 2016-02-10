using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	class QueueEnumerator<T> : IEnumerator<T>
	{
		private T[] Collection;
		private int curIndex;
		private T curElem;

		public QueueEnumerator(Queue<T> q)
		{
			q.CopyTo(Collection, 0);
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
			if (++curIndex >= Collection.Length)
				return false;
			else
				curElem = Collection[curIndex];
			return true;
		}

		public void Reset()
		{
			curIndex = -1;
		}

		bool IEnumerator.MoveNext()
		{
			throw new NotImplementedException();
		}

		void IEnumerator.Reset()
		{
			throw new NotImplementedException();
		}
	}
}
