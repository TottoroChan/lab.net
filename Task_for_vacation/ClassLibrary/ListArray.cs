using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	//класс ListArray реализует структуру данных список на основе массива
	public class ListArray<T> : List<T>
	{
		private T[] data;           //массив значений
		public int Capacity { get; private set; }       
		//ёмкость массива (стандартно 10, ёмкость увеличивается, если массив заполнен)

		//конструторы
		public ListArray() : this(10) { }

		public ListArray(List<T> list)
		{
			Count = list.Count;

			ListArray<T> l = list as ListArray<T>;
			if (l != null)
				Capacity = l.Capacity;
			else
				Capacity = ((Count / 10) + 1) * 10;

			data = new T[Capacity];
			for (int i = 0; i < Count; i++)
				data[i] = list[i];
		}

		public ListArray(int capacity)
		{
			if (capacity > 0)
			{
				Count = 0;
				Capacity = capacity;
				data = new T[Capacity];
			}
			else
				throw new ArgumentOutOfRangeException("Capacity", "Вместимость списка должна быть натуральным числом.");
		}

		//добавление нового элемнта
		public override void Append(T info)
		{
			if (Count == Capacity)
			{
				//увеличиваем ёмкость если достигли предела
				Capacity += 10;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Count; i++)
					newdata[i] = data[i];
				newdata[Count++] = info;
				data = newdata;
				return;
			}
			else
			{
				data[Count++] = info;
			}
		}

		//вставка элемента на определённую позицию
		public override void Insert(T info, int id)
		{
			if (id >= Count)
				//если индекс больше количества элементов, то добавляется новый
				Append(info);
			else if (Count != Capacity)
			{
				int i;
				for (i = Count; i > id; i--)
					data[i] = data[i - 1];
				data[i] = info;
				Count++;
			}
			else
			{
				//увеличение ёмкости при необходимости
				Capacity += 10;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Count; i++)
					newdata[i] = data[i];
				data = newdata;
				Insert(info, id);
			}
			return;
		}

		//проверка принадлежности элемента списку
		public override bool Contains(T info)
		{
			return data.Contains(info);
		}

		//копирование списка в массив
		public override void CopyTo(T[] array, int id)
		{
			for (int i = id; i < id + Count; i++)
				if (i < array.Length)
					array[i] = data[i - id];
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
		}
		
		//поиск элемента
		public override int Find(T info)
		{
			int i = 0;
			while (i < Count)
			{
				if (data[i].Equals(info))
					//возвращает его индекс в случае успеха
					return i;
				i++;
			}
			//возвращает -1 в случае неуспеха
			return -1;
		}

		//возвращает элемент по индексу
		public override T Get(int id)
		{
			if (id < Count)
				return data[id];
			else
				throw new IndexOutOfRangeException("Индекс вне диапазона.");
		}
		
		//метод удаления элемента
		public override bool Delete(T info)
		{
			int id = Find(info);
			if (id != -1)
			{
				for (int i = id; i < Count - 1; i++)
					data[i] = data[i + 1];
				Count--;
				return true;
			}
			else
				return false;
		}

		//удаление всех элементов списка
		public override void Clear()
		{
			Capacity = 10;
			Count = 0;
			data = new T[Capacity];
		}

		//копирование списка
		public override object Clone()
		{
			return new ListArray<T>(this);
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

		//перегрузка индексатора
		public override T this[int id]
		{
			get
			{
				if (id < Count)
					return data[id];
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
			set
			{
				if (id < Count)
					data[id] = value;
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
		}
	}
}
