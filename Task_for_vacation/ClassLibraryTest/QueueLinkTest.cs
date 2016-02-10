using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibraryTest
{
	[TestClass]
	public class QueueLinkTest
	{
		[TestMethod] //Тест заполнения очереди 
		public void AddTest()
		{
			QueueLink<object> data = new QueueLink<object>();
			data.Add(8);
			data.Add(6);
			data.Add(10);

		}

		[TestMethod] //получение первого элемента
		public void TakeTest()
		{
			QueueLink<object> data = new QueueLink<object>();
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.Take();

		}

		[TestMethod] //получение элемента из пустой очереди
		public void TakeEmptyTest()
		{
			QueueLink<object> data = new QueueLink<object>();
			data.Take();

		}

		[TestMethod] //ICloneable
		public void CloneTest()
		{
			QueueLink<object> data = new QueueLink<object>();
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.Clone();

		}

		[TestMethod] //IEnumerable
		public void EnumerableTest()
		{
			QueueLink<object> data = new QueueLink<object>();
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.GetEnumerator();

		}

		[TestMethod] //IDisposable
		public void DisposeTest()
		{
			QueueLink<object> data = new QueueLink<object>();
			data.Add(8);
			data.Add(6);
			data.Add(10);
			data.Dispose();

		}
	}
}
