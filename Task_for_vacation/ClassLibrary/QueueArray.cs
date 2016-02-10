using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class QueueArray<T> : Queue<T>
	{
		private T[] data;       //массив данных
		public int Capacity { get; private set; }  //ёмкость массива
		private int head;       //начало очереди
		private int tail;       //конец очереди
		private bool full;      //флаг отображающий заполненность очереди


		//конструкторы
		public QueueArray() : this(10) { }

		public QueueArray(int n)
		{
			Count++;
			Capacity = n;
			head = 0;
			tail = 0;
			full = false;
			data = new T[n];
		}

		public QueueArray(QueueArray<T> queue)
		{
			Count = queue.Count;
			Capacity = queue.Capacity;
			data = new T[Capacity];
			queue.CopyTo(data, 0);
		}

		public QueueArray(QueueLink<T> queue)
		{
			Count = queue.Count;
			Capacity = ((Count / 10) + 1) * 10;
			data = new T[Capacity];
			queue.CopyTo(data, 0);
		}

		//определение абстрактных методов

		//добавление элемента в очередь
		public override void Add(T info)
		{
			if (full)
			{
				//уведичение ёмкости при необходимости
				Capacity += 10;
				T[] newdata = new T[Capacity];
				newdata[0] = data[head];
				head = (head + 1) % (Capacity - 10);
				int i = 1;
				while (head != tail)
				{
					newdata[i] = data[head];
					head = (head + 1) % (Capacity - 10);
					i++;
				}
				head = 0;
				newdata[Count++] = info;
				tail = Count;

			}
			else
			{
				data[tail] = info;
				tail = (tail + 1) % Capacity;
				if (head == tail) full = true;
			}
		}

		//удаление всех элементов очереди
		public override void Clear()
		{
			Capacity = 10;
			Count = 0;
			head = 0; tail = 0;
			full = false;
			data = new T[Capacity];
		}

		public override object Clone()
		{
			return new QueueArray<T>(this);
		}

		//проверка принадлежит ли элемент очереди
		public override bool Contains(T info)
		{
			return data.Contains(info);
		}

		//копирование очереди в массив
		public override void CopyTo(T[] array, int id)
		{
			int p = head;
			for (int i = id; i < id + Count; i++)
				if (i < array.Length)
				{
					array[i] = data[p];
					p = (p + 1) % Capacity;
				}
				else
					throw new ArgumentOutOfRangeException();
		}

		//возвращает первый элемент и удаляет его
		public override T Take()
		{
			if (head == tail && !full)
				throw new InvalidOperationException();
			else
			{
				T result = data[head];
				head = (head + 1) % Capacity;
				return result;
			}
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
