using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public abstract class Stack<T> : IEnumerable<T>, ICloneable, IDisposable
	{
		public int Count { get; protected set; }
		public bool IsReadOnly { get; }
		protected bool disposed = false;

		//Добавление в стэк
		public abstract void Push(T info);

		//удаление всех элементов стека
		public abstract void Clear();

		//Копирование стэка
		public abstract object Clone();

		//проверка стэка на наличие элемента
		public abstract bool Contains(T info);

		//копирование стэка в массив
		public abstract void CopyTo(T[] array, int id);

		//извлекает последний элемент и удаляет его
		public abstract T Pop();

		//получение перечеслителя
		public IEnumerator<T> GetEnumerator()
		{
			return new StackEnumerator<T>(this);
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

		protected abstract void Dispose(bool disposing);

		~Stack()
		{
			Dispose(false);
		}

		//перегрузка индексатора
		protected abstract T this[int index] { get; set; }
	}
}
