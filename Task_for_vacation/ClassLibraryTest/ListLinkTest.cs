using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibraryTest
{
	[TestClass]
	public class ListLinkTest
	{
		[TestMethod] //Тест заполнения списка 
		public void AppendTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);

		}

		[TestMethod] //Тест заполнения с использованием Insert
		public void InsertTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Insert(4, 1);

		}

		[TestMethod] //Добавление элемента в заполненный список
		public void AppendInFullListTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8); 
			data.Append(6); 
			data.Append(4);
			data.Append(10);

		}

		[TestMethod] //получение последнего элемента
		public void GetLastItemTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Get(2);

		}

		[TestMethod] //получение первого элемента
		public void GetFirstItemTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Get(0);

		}

		[TestMethod] //Поиск существующего элемента
		public void FindItemTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Find(10);
		}

		[TestMethod] //Поиск не существующего элемента
		public void FindNotExistItemTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Find(11);
		}

		[TestMethod] //Поиск в пустом списке
		public void FindInEmptyListTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Find(11);
		}

		[TestMethod] //Удаление элемента из списка 
		public void DeleteTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Delete(2);

		}

		[TestMethod] //Удаление несуществующего элемента 
		public void DeleteNotExistItemTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Delete(5);

		}

		[TestMethod] //ICloneable
		public void CloneTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Clone();

		}

		[TestMethod] //IEnumerable
		public void EnumerableTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.GetEnumerator();

		}

		[TestMethod] //IDisposable
		public void DisposeTest()
		{
			ListLink<object> data = new ListLink<object>();
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Dispose();

		}
	}
}
