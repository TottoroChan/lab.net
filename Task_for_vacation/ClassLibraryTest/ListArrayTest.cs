using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibraryTest
{
	[TestClass]
	public class ListArrayTest
	{
		[TestMethod] //Тест заполнения списка 
		public void AppendTest() 
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n); 
			data.Append(8); 
			data.Append(6); 
			data.Append(10);

		}

		[TestMethod] //Тест заполнения с использованием Insert
		public void InsertTest() 
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8); 
			data.Append(6); 
			data.Insert(4, 1);

		}

		[TestMethod] //Добавление элемента в заполненный список
		public void AppendInFullListTest() 
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8); 
			data.Append(6); 
			data.Append(4);
			data.Append(10);

		}

		[TestMethod] //получение последнего элемента
		public void GetLastItemTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8); 
			data.Append(6); 
			data.Append(10); 
			data.Get(2);

		}

		[TestMethod] //получение первого элемента
		public void GetFirstItemTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Get(2);

		}

		[TestMethod] //Поиск существующего элемента
		public void FindItemTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Find(10);
		}

		[TestMethod] //Поиск не существующего элемента
		public void FindNotExistItemTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Find(11);
		}

		[TestMethod] //Поиск в пустом списке
		public void FindInEmptyListTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Find(11);
		}

		[TestMethod] //Удаление элемента из списка 
		public void DeleteTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Delete(2);

		}

		[TestMethod] //Удаление несуществующего элемента 
		public void DeleteNotExistItemTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Delete(5);

		}

		[TestMethod] //ICloneable
		public void CloneTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Clone();

		}

		[TestMethod] //IEnumerable
		public void EnumerableTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.GetEnumerator();

		}

		[TestMethod] //IDisposable
		public void DisposeTest()
		{
			int n = 3;
			ListArray<object> data = new ListArray<object>(n);
			data.Append(8);
			data.Append(6);
			data.Append(10);
			data.Dispose();

		}



	}
}
