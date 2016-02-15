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
		public void ConstructorTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);

			Assert.AreEqual(data.Capacity, 5);
			Assert.AreEqual(data.Length, 0);
		}

		[TestMethod]
		public void DefaultConstructorTest()
		{
			DynamicArray<int> data = new DynamicArray<int>();

			Assert.AreEqual(data.Capacity, 8);
			Assert.AreEqual(data.Length, 0);
		}

		[TestMethod]
		public void IncorrectCapasityConstructorTest()
		{
			int n = -5;
			try
			{
				DynamicArray<int> data = new DynamicArray<int>(n);
			}
			catch (Exception e)
			{
				StringAssert.Contains(e.Message,
                    "Вместимость списка должна быть натуральным числом.");
				return;
			}
			Assert.Fail("Не было ни одного исключения");
		}

		/// <summary>
		///Заполнение списка
		/// </summary>
		[TestMethod] 
		public void AddTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for(int i = 0; i< n;i++)
			{
				data.Add(i);
			}

			Assert.AreEqual(data.Capacity, 5);
			Assert.AreEqual(data.Length, 5);
			Assert.AreEqual(data[4], 4);
		}
		
		/// <summary>
		/// Добавление элемента в заполненный список
		/// </summary>
		[TestMethod] 
		public void AddInFullListTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.Add(15);

			Assert.AreEqual(data.Capacity, 10);
			Assert.AreEqual(data.Length, 6);
			Assert.AreEqual(data[5], 15);
		}

		[TestMethod] 
		public void AddRangeTest()
		{
			int n = 5;
			int[] arr = new int[] { 1, 2, 3 };
			DynamicArray<int> data = new DynamicArray<int>(n);
			data.AddRange(arr);

			Assert.AreEqual(data.Capacity, 5);
			Assert.AreEqual(data.Length, 3);
			Assert.AreEqual(data[2], 3);
		}

		[TestMethod]
		public void AddRangeInFullListTest()
		{
			int n = 5;
			int[] arr = new int[] { 1, 2, 3 };
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.AddRange(arr);

			Assert.AreEqual(data.Capacity, 10);
			Assert.AreEqual(data.Length, 8);
			Assert.AreEqual(data[7], 3);
		}

		/// <summary>
		///Заполнение списка с использованием Insert
		/// </summary>
		[TestMethod]
		public void InsertTest()
		{
			DynamicArray<int> data = new DynamicArray<int>();
			for (int i = 0; i < 7; i++)
			{
				data.Add(i);
			}
			data.Insert(4, 1);

			Assert.AreEqual(data.Capacity, 8);
			Assert.AreEqual(data.Length, 8);
			Assert.AreEqual(data[1], 4);
			Assert.AreEqual(data[7], 6);

		}

		[TestMethod]
		public void IncorrectIndexInsertTest()
		{
			int n = 5;
			try
			{
				DynamicArray<int> data = new DynamicArray<int>(n);
				for (int i = 0; i < n - 1; i++)
				{
					data.Add(i);
				}
				data.Insert(4, 10);
			}
			catch (Exception e)
			{
				StringAssert.Contains(e.Message, "Индекс превышает длину массива");
				return;
			}
			Assert.Fail("Не было ни одного исключения");

		}

		/// <summary>
		///Удаление элемента из списка 
		/// </summary>
		[TestMethod] 
		public void RemoveTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}

			Assert.AreEqual(data.Remove(3), true);
			Assert.AreEqual(data.Length, 4);
		}

		/// <summary>
		/// Удаление несуществующего элемента
		/// </summary>
		[TestMethod] 
		public void RemoveNotExistItemTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.Remove(10);

			Assert.AreEqual(data.Length, 5);
			Assert.AreEqual(data.Remove(10), false);
		}

		/// <summary>
		///IEnumerable
		/// </summary>
		[TestMethod] 
		public void EnumerableTest()
		{
			int n = 5;
			DynamicArray<int> data = new DynamicArray<int>(n);
			for (int i = 0; i < n; i++)
			{
				data.Add(i);
			}
			data.GetEnumerator();

			Assert.AreEqual(data.Capacity, 5);
		}
	}
}

