using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	public class ListLink<T> : List<T>
	{
		private Node<T> head;     //ссылка на первый элемент списка

		//конструкторы
		public ListLink()
		{
			head = null;
			Count = 0;
		}

		public ListLink(List<T> newdata)
		{
			Count = newdata.Count;
			head = null;
			if (Count != 0)
			{
				head = new Node<T>(newdata[0]);
				Node<T> data = head;
				for (int i = 1; i < Count; i++)
				{
					data.next = new Node<T>(newdata[i]);
					data.next.previous = data;
					data = data.next;
				}

			}

		}

		//добавление нового элемента
		public override void Append(T info)
		{
			if (head == null)
			{
				head = new Node<T>(info);
				Count = 1;
			}
			else
			{
				Node<T> data = head;
				while (data.next != null)
					data = data.next;
				data.next = new Node<T>(info);
				data.next.previous = data;
				Count++;
			}
		}

		//вставка элемента на определённую позицию
		public override void Insert(T info, int id)
		{
			id--;
			if (head == null)
			{
				head = new Node<T>(info);
				Count++;
			}
			else
			{
				int i = 0;
				Node<T> data = head;
				while (data.next != null && i != id)
				{
					data = data.next;
					i++;
				}
				if (i == id)
				{
					Node<T> p = new Node<T>(info);
					p.previous = data;
					p.next = data.next;
					data.next.previous = p;
					data.next = p;
				}
				else
				{
					data.next = new Node<T>(info);
					data.next.previous = data;
				}
				Count++;
			}
		}

		//проверка принадлежности элемента списку
		public override bool Contains(T info)
		{
			if (head == null)
				return false;
			else
			{
				Node<T> p = head;
				while (p != null && !info.Equals(p.info))
					p = p.next;
				if (p == null)
					return false;
				else
					return true;
			}
		}

		//копирование списка в массив
		public override void CopyTo(T[] array, int id)
		{
			Node<T> p = head;
			for (int i = id; i < id + Count; i++)
				if (i < array.Length)
				{
					array[i] = p.info;
					p = p.next;
				}
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
		}
		
		//поиск элемента
		public override int Find(T info)
		{
			if (head == null)
				return -1;
			else
			{
				int i = 0;
				Node<T> data = head;
				while (data != null && !data.info.Equals(info))
				{
					data = data.next;
					i++;
				}
				if (data == null)
					//возвращает -1 в случае неуспеха
					return -1;
				else
					//возвращает его индекс в случае успеха
					return i;
			}
		}

		//возвращает элемент по индексу
		public override T Get(int id)
		{
			if (id < Count)
				return this[id];
			else
				throw new IndexOutOfRangeException("Индекс вне диапазона.");
		}

		//удаляет элемент по индексу
		public override bool Delete(T info)
		{
			if (head == null)
				return false;
			else
			{
				Node<T> data = head;
				while (data.next != null && !data.next.info.Equals(info))
					data = data.next;
				if (data.next == null)
					return false;
				else
				{
					data.next.next.previous = data;
					data.next = data.next.next;
					Count--;
					return true;
				}
			}
		}

		//удаление всех элементов
		public override void Clear()
		{
			Count = 0;
			head = null;
		}

		//копирование списка
		public override object Clone()
		{
			return new ListLink<T>(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
					head = null;
				disposed = true;
			}
		}

		//перегрузка индексатора
		public override T this[int id]
		{
			get
			{
				if (id < Count)
				{
					Node<T> data = head;
					for (int i = 0; i < id; i++)
						data = data.next;
					return data.info;
				}
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}

			set
			{
				if (id < Count)
				{
					Node<T> data = head;
					for (int i = 0; i < id; i++)
						data = data.next;
					data.info = value;
				}
				else
					throw new IndexOutOfRangeException("Индекс вне диапазона.");
			}
		}
	}
}
