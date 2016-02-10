using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibraryTest
{
	[TestClass]
	public class StackArrayTest
	{
		[TestMethod] //Тест заполнения стека 
		public void PushTest()
		{
			int n = 3;
			StackArray<object> data = new StackArray<object>(n);
			data.Push(8);
			data.Push(6);
			data.Push(10);

		}

		[TestMethod] //получение последнего элемента
		public void PopTest()
		{
			int n = 3;
			StackArray<object> data = new StackArray<object>(n);
			data.Push(8);
			data.Push(6);
			data.Push(10);
			data.Pop();

		}

		[TestMethod] //получение элемента из пустго стека
		public void PopEmptyTest()
		{
			int n = 3;
			StackArray<object> data = new StackArray<object>(n);
			data.Pop();

		}

		[TestMethod] //ICloneable
		public void CloneTest()
		{
			int n = 3;
			StackArray<object> data = new StackArray<object>(n);
			data.Push(8);
			data.Push(6);
			data.Push(10);
			data.Clone();

		}

		[TestMethod] //IEnumerable
		public void EnumerableTest()
		{
			int n = 3;
			StackArray<object> data = new StackArray<object>(n);
			data.Push(8);
			data.Push(6);
			data.Push(10);
			data.GetEnumerator();

		}

		[TestMethod] //IDisposable
		public void DisposeTest()
		{
			int n = 3;
			StackArray<object> data = new StackArray<object>(n);
			data.Push(8);
			data.Push(6);
			data.Push(10);
			data.Dispose();

		}
	}
}
