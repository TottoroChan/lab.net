using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace Task1_Test
{
	[TestClass]
	public class Task1_Test
	{
		/// <summary>
		///  Проверка создания списков
		/// </summary>
		[TestMethod]
		public void GeneratePeople1()
		{
			People P = new People();
		}

		[TestMethod]
		public void GeneratePeople2()
		{
			People P = new People(10);
		}

		/// <summary>
		///  Проверка удаления каждого второго
		/// </summary>
		[TestMethod]
		public void CountPeople1()
		{
			People P = new People();
			Assert.AreEqual(1, P.Print());
		}

		[TestMethod]
		public void CountPeople2()
		{
			People P = new People(10);
			Assert.AreEqual(5, P.Print());
		}
	}
}
