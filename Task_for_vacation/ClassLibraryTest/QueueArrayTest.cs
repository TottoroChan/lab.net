using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibraryTest
{
	[TestClass]
	public class QueueArrayTest
	{
		[TestMethod] //Тест заполнения очереди 
		public void AddTest()
		{
			int n = 3;
			QueueArray<object> data = new QueueArray<object>(n);
			data.Add(8);
			data.Add(6);
			data.Add(10);

		}

		[TestMethod] //получение первого элемента
		public void TakeTest()
		{
			int n = 3;
			QueueArray<object> data = new QueueArray<object>(n);
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.Take();

		}

		[TestMethod] //получение элемента из пустой очереди
		public void TakeEmptyTest()
		{
			int n = 3;
			QueueArray<object> data = new QueueArray<object>(n);
			data.Take();

		}

		[TestMethod] //ICloneable
		public void CloneTest()
		{
			int n = 3;
			QueueArray<object> data = new QueueArray<object>(n);
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.Clone();

		}

		[TestMethod] //IEnumerable
		public void EnumerableTest()
		{
			int n = 3;
			QueueArray<object> data = new QueueArray<object>(n);
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.GetEnumerator();

		}

		[TestMethod] //IDisposable
		public void DisposeTest()
		{
			int n = 3;
			QueueArray<object> data = new QueueArray<object>(n);
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.Dispose();

		}
	}
}
