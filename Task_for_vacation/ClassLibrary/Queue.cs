using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public abstract class Queue<T> : IEnumerable<T>, ICloneable, IDisposable
	{
		public int Count { get; protected set; }
		public bool IsReadOnly { get; }
		protected bool disposed = false;

		//добавление элемента в очередь
		public abstract void Add(T info);

		//удаление всех элементов
		public abstract void Clear();

		//копирование очереди
		public abstract object Clone();

		//проверка содержит ли элемент очередь
		public abstract bool Contains(T info);

		//копирование очереди в массив
		public abstract void CopyTo(T[] array, int id);

		//возвращает первый элемент очереди и удаляет его
		public abstract T Take();
		
		//получение перечеслителя
		public IEnumerator<T> GetEnumerator()
		{
			return new QueueEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected abstract void Dispose(bool disposing);

		~Queue()
		{
			Dispose(false);
		}

		//перегрузка индексатора
		protected abstract T this[int index] { get; set; }
	}
}
