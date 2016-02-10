using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	public class StackArray<T> : Stack<T>
	{
		private T[] data;
		public int Capacity { get; private set; }

		public StackArray() : this(10) { }

		public StackArray(int n)
		{
			Capacity = n;
			Count = 0;
			data = new T[n];
		}

		public StackArray(StackArray<T> stack)
		{
			Count = stack.Count;
			Capacity = stack.Capacity;
			data = new T[Capacity];
			stack.CopyTo(data, 0);
		}

		public StackArray(StackLink<T> stack)
		{
			Count = stack.Count;
			Capacity = (Count / 10 + 1) * 10;
			data = new T[Capacity];
			stack.CopyTo(data, 0);
		}

		//Добавление элемента
		public override void Push(T info)
		{
			if (Count == Capacity)
			{
				Capacity += 10;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Count; i++)
					newdata[i] = data[i];
				data = newdata;
			}
			data[Count++] = info;
		}

		//удаление всех элементов
		public override void Clear()
		{
			Capacity = 10;
			Count = 0;
			data = new T[Capacity];
		}

		//извлекает последний элемент
		public override T Pop()
		{
			return data[--Count];
		}

		//копирование стэка
		public override object Clone()
		{
			return new StackArray<T>(this);
		}

		//проверка содержит ли стек элемент
		public override bool Contains(T info)
		{
			return data.Contains(info);
		}

		//копирование стека в массив
		public override void CopyTo(T[] array, int id)
		{
			for (int i = id; i < id + Count; i++)
				if (i < array.Length)
					array[i] = data[i - id];
				else
					throw new ArgumentOutOfRangeException();
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
					data = null;
				disposed = true;
			}
		}

		protected override T this[int id]
		{
			get
			{
				if (id < Count)
					return data[id];
				else
					throw new ArgumentOutOfRangeException();
			}
			set
			{
				if (id < Count)
					data[id] = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
