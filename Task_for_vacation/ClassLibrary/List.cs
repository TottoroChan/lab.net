using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public abstract class List<T> : IEnumerable<T>, IDisposable, ICloneable
	{
		public int Count { get; protected set; }        //длина списка
		public bool IsReadOnly { get; }
		protected bool disposed = false;                // Для определения избыточных вызовов

		//добавление нового элемента в список
		public abstract void Append(T info);

		//вставка элемента на определённую позицию
		public abstract void Insert(T info, int id);

		//проверка принадлежности элемента списку
		public abstract bool Contains(T info);

		//копирует список в массив
		public abstract void CopyTo(T[] array, int id);

		//возвращает индекс элемента
		public abstract int Find(T info);

		//возвращает элемент с указанным индексом
		public abstract T Get(int id);
		
		//удаление элемента из списка
		public abstract bool Delete(T info);

		//удаление всех элементов списка
		public abstract void Clear();

		//копирование списка
		public abstract object Clone();

		//получение перечислятеля
		public IEnumerator<T> GetEnumerator()
		{
			return new ListEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		//метод Dispose
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		//перегрузка индексатора
		public abstract T this[int id] { get; set; }

		protected abstract void Dispose(bool disposing);

		~List()
		{
			Dispose(false);
		}
	}
}
