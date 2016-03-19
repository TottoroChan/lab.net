using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Entities;

namespace DALtests
{
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		///  Вывод таблицы заказов
		/// </summary>
		[TestMethod]
		public void ShowOrdersTest()
		{
			DALDB db = new DALDB();
			Assert.AreEqual(true, db.ShowOrders());
		}

		/// <summary>
		/// Детали заказа
		/// </summary>
		[TestMethod]
		public void OrderDetailsTest()
		{
			DALDB db = new DALDB();
			int n = 10248;
			Assert.AreEqual(true, db.OrderDetails(n));

		}

		/// <summary>
		///  Если таблица заказов пустая
		/// </summary>
		[TestMethod]
		public void EmptyTablegOrderDetailsTest()
		{
			DALDB db = new DALDB();
			int n = 10;
			Assert.AreEqual(true, db.OrderDetails(n));

		}

		/// <summary>
		///  Добавление нового заказа
		/// </summary>
		[TestMethod]
		public void CreateOrderTest()
		{
			DALDB db = new DALDB();
			
			string CustomerID = "RATTC";
			int EmployeeID = 1;
			DateTime OrderDate = DateTime.MinValue;
			DateTime RequiredDate = DateTime.MinValue;
			DateTime ShippedDate = DateTime.MinValue;
			int ShipVia = 1;
			float Freight = 1;
			string ShipName = "Rattlesnake Canyon Grocery";
			string ShipAddress = "2817 Milton Dr.";
			string ShipCity = "Albuquerque";
			string ShipRegion = "NM";
			string ShipPostalCode = "87110";
			string ShipCountry = "USA";

			Orders note = new Orders(CustomerID, EmployeeID, OrderDate, 
			RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, 
			ShipCity, ShipRegion, ShipPostalCode, ShipCountry);

			Assert.AreEqual(true, db.CreateOrder(note));
		}

		/// <summary>
		///  Добавление заказа с неправильными данными
		/// </summary>
		[TestMethod]
		public void CreateWrongOrderTest()
		{
			DALDB db = new DALDB();

			string CustomerID = "";
			int EmployeeID = 0;
			DateTime OrderDate = DateTime.MinValue;
			DateTime RequiredDate = DateTime.MinValue;
			DateTime ShippedDate = DateTime.MinValue;
			int ShipVia = -1;
			float Freight = -1;
			string ShipName = "Rattlesnake Canyon Grocery";
			string ShipAddress = "2817 Milton Dr.";
			string ShipCity = "Albuquerque";
			string ShipRegion = "NM";
			string ShipPostalCode = "87110";
			string ShipCountry = "USA";

			Orders note = new Orders(CustomerID, EmployeeID, OrderDate,
			RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress,
			ShipCity, ShipRegion, ShipPostalCode, ShipCountry);

			Assert.AreEqual(false, db.CreateOrder(note));
		}

		/// <summary>
		/// Изменить статус заказа на "Отправленно"
		/// </summary>
		[TestMethod]
		public void SendOrderTest()
		{
			DALDB db = new DALDB();
			int id = 12083;
			Assert.AreEqual(true, db.SendOrder(id));
		}

		/// <summary>
		///  Изменить статус несуществующего заказа
		/// </summary>
		[TestMethod]
		public void SendWrongOrderTest()
		{
			DALDB db = new DALDB();
			int id = 0;
			Assert.AreEqual(false, db.SendOrder(id));
		}

		/// <summary>
		/// Изменить статус заказа на "Доставленно"
		/// </summary>
		[TestMethod]
		public void GetOrderTest()
		{
			DALDB db = new DALDB();
			int id = 12083;
			Assert.AreEqual(true, db.GetOrder(id));
		}

		/// <summary>
		///  Изменить статус несуществующего заказа
		/// </summary>
		[TestMethod]
		public void GetWrongOrderTest()
		{
			DALDB db = new DALDB();
			int id = -15;
			Assert.AreEqual(false, db.GetOrder(id));
		}

		/// <summary>
		///  CustOrderHistTest
		/// </summary>
		[TestMethod]
		public void CustOrderHistTest()
		{
			DALDB db = new DALDB();
			string s = "RATTC";
			Assert.AreEqual(true, db.CustOrderHist(s));
		}

		/// <summary>
		///  CustOrderHistTest пустая таблица
		/// </summary>
		[TestMethod]
		public void EmptyTableCustOrderHistTest()
		{
			DALDB db = new DALDB();
			string s = "test";
			Assert.AreEqual(true, db.CustOrderHist(s));
		}

		/// <summary>
		///  CustOrdersDetailTest 
		/// </summary>
		[TestMethod]
		public void CustOrdersDetailTest()
		{
			DALDB db = new DALDB();
			int s = 10250;
			Assert.AreEqual(true, db.CustOrdersDetail(s));
		}

		/// <summary>
		///  CustOrdersDetailTest пустая таблица
		/// </summary>
		[TestMethod]
		public void EmptyTableCustOrdersDetailTest()
		{
			DALDB db = new DALDB();
			int s = -9;
			Assert.AreEqual(true, db.CustOrdersDetail(s));
		}
	}
}
