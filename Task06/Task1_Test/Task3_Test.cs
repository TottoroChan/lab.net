using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task1_Test
{
	[TestClass]
	public class Task3_Test
	{
		/// <summary>
		///Тесты создания списка 
		/// </summary>
		[TestMethod] 
		public void DAn_Test()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
		}

		[TestMethod]
		public void DA_Test()
		{
			DynamicArray<int> data = new DynamicArray<int>();
		}

		/// <summary>
		///Заполнение списка
		/// </summary>
		[TestMethod] 
		public void DAn_AddTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for(int i = 0; i< n;i++)
			{
				data.Add(i);
			}


		}

		/// <summary>
		///Заполнение списка с использованием Insert
		/// </summary>
		[TestMethod] 
		public void DA_InsertTest()
		{
			DynamicArray<int> data = new DynamicArray<int>();
			for (int i = 0; i < 7; i++)
			{
				data.Add(i);
			}
			data.Insert(4, 1);

		}
		[TestMethod] 
		public void DAn_InsertTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n-1; i++)
			{
				data.Add(i);
			}
			data.Insert(4, 1);

		}

		/// <summary>
		/// Добавление элемента в заполненный список
		/// </summary>
		[TestMethod] 
		public void DAn_AddInFullListTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.Add(15);


		}

		[TestMethod] 
		public void DAn_AddRangeTest()
		{
			int n = 5;
			int[] arr = new int[] { 1, 2, 3 };
			DynamicArray<int> data = new DynamicArray<int>(n);
			data.AddRange(arr);


		}

		/// <summary>
		///Удаление элемента из списка 
		/// </summary>
		[TestMethod] 
		public void DAn_RemoveTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.Remove(3);

		}

		/// <summary>
		/// Удаление несуществующего элемента
		/// </summary>
		[TestMethod] 
		public void DAn_RemoveNotExistItemTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.Remove(10);

		}

		/// <summary>
		///IEnumerable
		/// </summary>
		[TestMethod] 
		public void DAn_EnumerableTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.GetEnumerator();

		}
	}
}

