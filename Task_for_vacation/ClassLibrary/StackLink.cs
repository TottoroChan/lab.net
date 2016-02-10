using ClassLibrary;
using System;
using System.Collections;
using System.Text;

namespace ClassLibrary
{
	public class StackLink<T> : Stack<T>
	{
		private Node<T> Head;
		private Node<T> Tail;

		public StackLink()
		{
			Head = null;
			Tail = null;
		}

		public StackLink(StackLink<T> stack)
		{
			Head = null;
			Tail = null;
			Node<T> data = stack.Head;
			Count = stack.Count;
			while (data != null)
			{
				Push(data.info);
				data = data.next;
			}
		}

		//добавление элемента
		public override void Push(T info)
		{
			if (Head == null)
			{
				Head = new Node<T>(info);
				Tail = Head;
				Count++;
			}
			else
			{
				Tail.next = new Node<T>(info);
				Tail.next.previous = Tail;
				Tail = Tail.next;
				Count++;
			}
		}

		//вывод последнего элемента
		public override T Pop()
		{
			T result = Tail.info;
			Tail = Tail.previous;
			Tail.next = null;
			Count--;
			return result;
		}

		//удаление всех элементов
		public override void Clear()
		{
			Count = 0;
			Head = null;
			Tail = null;
		}

		//копирование стека
		public override object Clone()
		{
			return new StackLink<T>(this);
		}

		//проверка содержит ли элемент стек
		public override bool Contains(T info)
		{
			Node<T> data = Tail;
			while (data != null || !data.info.Equals(info))
				data = data.previous;
			if (data == null)
				return false;
			else
				return true;
		}

		//копирование стека в массив
		public override void CopyTo(T[] array, int id)
		{
			Node<T> data = Tail;
			while (data.previous != null)
				data = data.previous;
			for (int i = id; i < id + Count; i++)
				if (i < array.Length)
				{
					array[i] = data.info;
					data = data.next;
				}
				else
					throw new ArgumentOutOfRangeException();
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Tail = null;
					Head = null;
				}
				disposed = true;
			}
		}

		protected override T this[int id]
		{
			get
			{
				if (id < Count)
				{
					Node<T> data = Tail;
					while (data.previous != null)
						data = data.previous;
					for (int i = 0; i < id; i++)
						data = data.next;
					return data.info;
				}
				else
					throw new ArgumentOutOfRangeException();
			}
			set
			{
				if (id < Count)
				{
					Node<T> data = Tail;
					while (data.previous != null)
						data = data.previous;
					for (int i = 0; i < id; i++)
						data = data.next;
					data.info = value;
				}
				else
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
