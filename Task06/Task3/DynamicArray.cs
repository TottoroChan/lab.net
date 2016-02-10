using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
	public class DynamicArray<T>
	{
		private T[] data;							//массив значений
		public int Length { get; private set; }		//
		public int Capacity { get; private set; }   //ёмкость массива

		/// <summary>
		///  Конструкторы класса 
		/// </summary>
		public DynamicArray()
		{
			Length = 0;
			Capacity = 8;
			data = new T[Capacity];
		}
		
		public DynamicArray(int capacity)
		{
			if (capacity > 0)
			{
				Length = 0;
				Capacity = capacity;
				data = new T[Capacity];
			}
			else
				throw new ArgumentOutOfRangeException("Capacity", 
					"Вместимость списка должна быть натуральным числом.");
		}

		/// <summary>
		///  Добавление нового элемента и увелечение ёмкости массива
		///  в случае необходимости. 
		/// </summary>
		public void Add(T info)
		{
			if (Length == Capacity)
			{
				Capacity *= 2;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Length; i++)
					newdata[i] = data[i];
				newdata[Length++] = info;
				data = newdata;
				return;
			}
			else
			{
				data[Length++] = info;
			}
		}

		/// <summary>
		///  Добавление содержимого коллекции
		/// </summary>
		public void AddRange(IEnumerable<T> e)
		{
			while (Capacity <= Length + e.Count())
				Capacity *= 2;
			if (Capacity != data.Length)
			{
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Length; i++)
					newdata[i] = data[i];
				data = newdata;
			}
			foreach (T t in e)
				Add(t);
		}

		/// <summary>
		///  Удаление элемента
		/// </summary>
		public bool Remove(T info)
		{
			int id = -1;
			int i = 0;
			while (i < Length)
			{
				if (data[i].Equals(info))
					id = i;
				i++;
			}

			if (id != -1)
			{
				for (int j = id; j < Length - 1; j++)
					data[j] = data[j + 1];
				Length--;
				return true;
			}
			else
				return false;
		}

		/// <summary>
		///  Добавление элемента по индексу
		/// </summary>
		public bool Insert(T info, int id)
		{
			if (id >= Length)
			{
				throw new ArgumentOutOfRangeException("Capacity",
								"Индекс превышает длину массива");
			}
			else if (Length != Capacity)
			{
				int i;
				for (i = Length; i > id; i--)
					data[i] = data[i - 1];
				data[i] = info;
				Length++;
				return true;
			}
			else
			{
				Capacity *= 2;
				T[] newdata = new T[Capacity];
				for (int i = 0; i < Length; i++)
					newdata[i] = data[i];
				data = newdata;
				Insert(info, id);
				return true;
			}
			return false;
		}

		/// <summary>
		///  Реализация IEnumerable
		/// </summary>
		public DynamicEnumerator<T> GetEnumerator()
		{
			return new DynamicEnumerator<T>();
		}

		/// <summary>
		/// Перегрузка индексатора
		/// </summary>
		public T this[int id]
		{
			get
			{
				if (id < Length)
					return data[id];
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
			set
			{
				if (id < Length)
					data[id] = value;
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
		}
	}
}
