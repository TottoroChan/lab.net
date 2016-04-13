using System;
using DAL.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{

	public class DALDB
	{
		/// <summary>
		/// Строка подключения к бд, подключена к локальной бд Northwind
		/// </summary>
		string ConnectionString = @"Data Source=(localdb)\ProjectsV13;" +
			"Initial Catalog=Northwind;Integrated Security=True;" +
			"Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;" +
			"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		/// <summary>
		/// Метод создания заказа
		/// </summary>
		/// <param name="order"></param>
		public bool CreateOrder(Orders order)
		{
			if (CheckCustomerID(order.CustomerID) == false)
				throw new ArgumentException("Incorrect value", "CustomerID");
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
				"INSERT INTO Northwind.Orders (CustomerID," +
				"OrderDate) values (@CustomerID, @OrderDate)", connection);

				command.Parameters.Add("@CustomerID",
							  SqlDbType.NChar, 5).Value = order.CustomerID;
				if (order.OrderDate == DateTime.MinValue)
					command.Parameters.AddWithValue("@OrderDate",
								   SqlDbType.DateTime).Value = DBNull.Value;
				else
					command.Parameters.AddWithValue("@OrderDate",
														   order.OrderDate);

				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}


		/// <summary>
		/// Детали заказа
		/// </summary>
		/// <param name="OrderID"></param>
		public IEnumerable<OrderDetails> ShowOrderDetails(int OrderID)
		{
			if (CheckOrderID(OrderID) == false)
				throw new ArgumentException("Incorrect value", "OrderID");
			var order = new List<OrderDetails>();

			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
					"SELECT o.OrderID, o.CustomerID, o.EmployeeID, " +
					"o.OrderDate, o.RequiredDate,  o.ShippedDate, " +
					"o.ShipVia, o.Freight, o.ShipName, o.ShipAddress, " +
					" o.ShipCity, o.ShipRegion, o.ShipPostalCode, " +
					" o.ShipCountry, p.ProductID, p.ProductName, " +
					"od.Quantity, od.UnitPrice, od.Discount FROM " +
					"Northwind.Orders AS o INNER JOIN " +
					"Northwind.[Order Details] AS od ON " +
					"o.OrderID = od.OrderID INNER JOIN " +
					"Northwind.Products AS p ON od.ProductID=p.ProductID" +
					" WHERE o.OrderID = @OrderID", connection);

				command.Parameters.AddWithValue("@OrderID", OrderID);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var o = new OrderDetails();

					o.OrderID = Convert.ToInt32(reader.GetValue(0));
					if (reader.GetValue(1).ToString() != "")
						o.CustomerID = Convert.ToString(reader.GetValue(1));
					if (reader.GetValue(2).ToString() != "")
						o.EmployeeID = Convert.ToInt32(reader.GetValue(2));
					if (reader.GetValue(3).ToString() != "")
						o.OrderDate = Convert.ToDateTime(reader.GetValue(3));
					if (reader.GetValue(4).ToString() != "")
						o.RequiredDate = Convert.ToDateTime(reader.GetValue(4));
					if (reader.GetValue(5).ToString() != "")
						o.ShippedDate = Convert.ToDateTime(reader.GetValue(5));
					if (reader.GetValue(6).ToString() != "")
						o.ShipVia = Convert.ToInt32(reader.GetValue(6));
					if (reader.GetValue(7).ToString() != "")
						o.Freight = Convert.ToDouble(reader.GetValue(7));
					if (reader.GetValue(8).ToString() != "")
						o.ShipName = Convert.ToString(reader.GetValue(8));
					if (reader.GetValue(9).ToString() != "")
						o.ShipAddress = Convert.ToString(reader.GetValue(9));
					if (reader.GetValue(10).ToString() != "")
						o.ShipCity = Convert.ToString(reader.GetValue(10));
					if (reader.GetValue(11).ToString() != "")
						o.ShipRegion = Convert.ToString(reader.GetValue(11));
					if (reader.GetValue(12).ToString() != "")
						o.ShipPostalCode = Convert.ToString(reader.GetValue(12));
					if (reader.GetValue(13).ToString() != "")
						o.ShipCountry = Convert.ToString(reader.GetValue(13));
					if (reader.GetValue(14).ToString() != "")
						o.ProductID = Convert.ToInt32(reader.GetValue(14));
					if (reader.GetValue(15).ToString() != "")
						o.ProductName = Convert.ToString(reader.GetValue(15));
					if (reader.GetValue(16).ToString() != "")
						o.Quantity = Convert.ToInt32(reader.GetValue(16));
					if (reader.GetValue(17).ToString() != "")
						o.UnitPrice = Convert.ToDouble(reader.GetValue(17));
					if (reader.GetValue(18).ToString() != "")
						o.Discount = Convert.ToDouble(reader.GetValue(18));

					order.Add(o);
				}
				return order;
			}
		}

		/// <summary>
		/// Детали заказа
		/// </summary>
		/// <param name="OrderID"></param>
		public OrderDetails OrderDetails(int OrderID)
		{
			if (CheckOrderID(OrderID) == false)
				throw new ArgumentException("Incorrect value", "OrderID");

			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
					"SELECT o.OrderID, o.CustomerID, o.EmployeeID, " +
					"o.OrderDate, o.RequiredDate,  o.ShippedDate, " +
					"o.ShipVia, o.Freight, o.ShipName, o.ShipAddress, " +
					" o.ShipCity, o.ShipRegion, o.ShipPostalCode, " +
					" o.ShipCountry FROM Northwind.Orders AS o " +
					" WHERE o.OrderID = @OrderID", connection);

				command.Parameters.AddWithValue("@OrderID", OrderID);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				OrderDetails o = new OrderDetails();
				while (reader.Read())
				{
					o.OrderID = Convert.ToInt32(reader.GetValue(0));
					if (reader.GetValue(1).ToString() != "")
						o.CustomerID = Convert.ToString(reader.GetValue(1));
					if (reader.GetValue(2).ToString() != "")
						o.EmployeeID = Convert.ToInt32(reader.GetValue(2));
					if (reader.GetValue(3).ToString() != "")
						o.OrderDate = Convert.ToDateTime(reader.GetValue(3));
					if (reader.GetValue(4).ToString() != "")
						o.RequiredDate = Convert.ToDateTime(reader.GetValue(4));
					if (reader.GetValue(5).ToString() != "")
						o.ShippedDate = Convert.ToDateTime(reader.GetValue(5));
					if (reader.GetValue(6).ToString() != "")
						o.ShipVia = Convert.ToInt32(reader.GetValue(6));
					if (reader.GetValue(7).ToString() != "")
						o.Freight = Convert.ToDouble(reader.GetValue(7));
					if (reader.GetValue(8).ToString() != "")
						o.ShipName = Convert.ToString(reader.GetValue(8));
					if (reader.GetValue(9).ToString() != "")
						o.ShipAddress = Convert.ToString(reader.GetValue(9));
					if (reader.GetValue(10).ToString() != "")
						o.ShipCity = Convert.ToString(reader.GetValue(10));
					if (reader.GetValue(11).ToString() != "")
						o.ShipRegion = Convert.ToString(reader.GetValue(11));
					if (reader.GetValue(12).ToString() != "")
						o.ShipPostalCode = Convert.ToString(reader.GetValue(12));
					if (reader.GetValue(13).ToString() != "")
						o.ShipCountry = Convert.ToString(reader.GetValue(13));
					break;
				}
				return o;
			}
		}

		/// <summary>
		/// Вывод таблицы заказов
		/// </summary>
		/// <param name=""></param>
		public IEnumerable<Orders> ShowOrders()
		{
			var order = new List<Orders>();
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
					"SELECT TOP(30) total.OrderID, o.CustomerID, c.ContactName, o.OrderDate," +
					" o.RequiredDate, o.ShippedDate, total.Total" +
					" FROM Northwind.Customers as c INNER JOIN Northwind.Orders as o" +
					" ON c.CustomerID = o.CustomerID INNER JOIN " +
					"(SELECT o.OrderID, SUM((UnitPrice * (1 - Discount)) * Quantity) as Total" +
					" FROM Northwind.Orders as o FULL OUTER JOIN Northwind.[Order Details] as od" +
					" ON o.OrderID = od.OrderID GROUP BY o.OrderID) as total" +
					" ON total.OrderID = o.OrderID ORDER BY o.OrderDate DESC", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var o = new Orders();
					o.OrderID = Convert.ToInt32(reader.GetValue(0));
					if (reader.GetValue(1).ToString() != "")
						o.CustomerID = Convert.ToString(reader.GetValue(1));
					if (reader.GetValue(2).ToString() != "")
						o.ContactName = Convert.ToString(reader.GetValue(2));
					if (reader.GetValue(3).ToString() != "")
						o.OrderDate = Convert.ToDateTime(reader.GetValue(3));

					if ((reader.GetValue(5).ToString() == DateTime.MinValue.ToString())
						|| (reader.GetValue(5).ToString() == ""))
					{
						o.OrderStatus = OrderTypes.Underway;
					}
					else
					{
						o.OrderStatus = OrderTypes.Done;
					}
					if ((o.OrderDate == DateTime.MinValue) || (o.OrderDate.ToString() == ""))
					{
						o.OrderStatus = OrderTypes.NotShipped;
					}
					if (reader.GetValue(6).ToString() != "")
						o.Total = Convert.ToDouble(reader.GetValue(6));

					Console.WriteLine();
					order.Add(o);
				}

				return order;
			}

		}

		/// <summary>
		/// Добавление деталей заказа
		/// </summary>
		/// <param name="order"></param>
		public bool AddOrderDetail(OrderDetails order)
		{
			if (CheckOrderID(order.OrderID) == false)
				throw new ArgumentException("Incorrect value", "OrderID");
			if (CheckCustomerID(order.CustomerID) == false)
				throw new ArgumentException("Incorrect value", "CustomerID");
			if (CheckEmployeeID(order.EmployeeID) == false)
				throw new ArgumentException("Incorrect value", "EmployeeID");
			if (CheckProductID(order.ProductID) == false)
				throw new ArgumentException("Incorrect value", "PrductID");
			
			if ((AddOrder(order) == true)&&(AddDetail(order) == true))
				return true;
			else return false;
		}

		/// <summary>
		/// Обновление информации о заказе
		/// </summary>
		/// <param name="order"></param>
		public bool AddOrder(OrderDetails order)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
				"UPDATE Northwind.Orders SET CustomerID = @CustomerID," +
				" EmployeeID = @EmployeeID, OrderDate = @OrderDate," +
				" RequiredDate = @OrderDate, ShippedDate = @ShippedDate," +
				" ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName," +
				" ShipAddress = @ShipAddress, ShipCity = @ShipCity," +
				" ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCode," +
				"ShipCountry = @ShipCountry WHERE OrderID = @OrderID", connection);

				command.Parameters.Add("@OrderID",
							  SqlDbType.Int).Value = order.OrderID;
				command.Parameters.Add("@CustomerID",
							  SqlDbType.NChar, 5).Value = order.CustomerID;
				command.Parameters.AddWithValue("@EmployeeID",
														 order.EmployeeID);
				if ((order.OrderDate == DateTime.MinValue) ||
						(order.OrderDate.ToString() == ""))
					command.Parameters.AddWithValue("@OrderDate",
								   SqlDbType.DateTime).Value = DBNull.Value;
				else
					command.Parameters.AddWithValue("@OrderDate",
														   order.OrderDate);
				if ((order.RequiredDate == DateTime.MinValue) ||
						(order.OrderDate.ToString() == ""))
					command.Parameters.AddWithValue("@RequiredDate",
								  SqlDbType.DateTime).Value = DBNull.Value;
				else
					command.Parameters.AddWithValue("@RequiredDate",
													   order.RequiredDate);
				if ((order.ShippedDate == DateTime.MinValue) ||
						(order.OrderDate.ToString() == ""))
					command.Parameters.AddWithValue("@ShippedDate",
								  SqlDbType.DateTime).Value = DBNull.Value;
				else
					command.Parameters.AddWithValue("@ShippedDate",
														order.ShippedDate);
				command.Parameters.AddWithValue("@ShipVia", order.ShipVia);
				command.Parameters.AddWithValue("@Freight", order.Freight);
				command.Parameters.Add("@ShipName", SqlDbType.NVarChar,
												40).Value = order.ShipName;
				command.Parameters.Add("@ShipAddress", SqlDbType.NVarChar,
												60).Value = order.ShipAddress;
				command.Parameters.Add("@ShipCity", SqlDbType.NVarChar,
												15).Value = order.ShipCity;
				command.Parameters.Add("@ShipRegion", SqlDbType.NVarChar,
											  15).Value = order.ShipRegion;
				command.Parameters.Add("@ShipPostalCode",
					  SqlDbType.NVarChar, 10).Value = order.ShipPostalCode;
				command.Parameters.Add("@ShipCountry", SqlDbType.NVarChar,
											 15).Value = order.ShipCountry;

				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// Добавление деталей заказа в таблицу Order Details
		/// </summary>
		/// <param name="order"></param>
		public bool AddDetail(OrderDetails order)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
				"INSERT INTO Northwind.[Order Details] (Quantity, OrderID, "+
				"ProductID, UnitPrice, Discount) values (@q, @id, @p, @u, @d)", connection);

				command.Parameters.Add("@q",
							  SqlDbType.Int).Value = order.Quantity;
				command.Parameters.Add("@id",
							  SqlDbType.Int).Value = order.OrderID;
				command.Parameters.Add("@p",
							  SqlDbType.Int).Value = order.ProductID;
				command.Parameters.Add("@u",
							  SqlDbType.Int).Value = order.UnitPrice;
				command.Parameters.Add("@d",
							  SqlDbType.Int).Value = order.Discount;
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// CheckCustomerID
		/// </summary>
		/// <param name="id"></param>\
		public bool CheckCustomerID(string id)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("select CustomerID from Northwind.Customers where CustomerID = @id");
				command.Connection = connection;
				command.Parameters.Add("@id",
						  SqlDbType.NChar, 5).Value = id;
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// CheckEmployeeID
		/// </summary>
		/// <param name="id"></param>
		public bool CheckEmployeeID(int id)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("select EmployeeID from Northwind.Employees where EmployeeID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// CheckOrderID
		/// </summary>
		/// <param name="id"></param>
		public bool CheckOrderID(int id)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("select OrderID from Northwind.Orders where OrderID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// ProductID
		/// </summary>
		/// <param name="id"></param>
		public bool CheckProductID(int id)
		{
			using (SqlConnection connection = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("select ProductID from Northwind.Products where ProductID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", id);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}
	}
}
