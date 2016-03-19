using System;
using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
	
	public class DALDB : IDAL
	{
		/// <summary>
		/// Строка подключения к бд, подключена к локальной бд Northwind
		/// </summary>
		string ConnectionString = @"Data Source=(localdb)\ProjectsV13;"+
			"Initial Catalog=Northwind;Integrated Security=True;"+
			"Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;"+
			"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


		/// <summary>
		/// Метод создания заказа
		/// </summary>
		/// <param name="order"></param>
		public bool CreateOrder(Orders order)
		{try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					var command = new SqlCommand(
					"insert into Northwind.Orders (CustomerID, EmployeeID," +
					"OrderDate, RequiredDate,  ShippedDate, ShipVia, Freight,"+
					"ShipName, ShipAddress, ShipCity, ShipRegion,"+
					"ShipPostalCode, ShipCountry) values (@CustomerID," +
					"@EmployeeID, @OrderDate, @RequiredDate, @ShippedDate,"+ 
					"@ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity,"+
					"@ShipRegion, @ShipPostalCode, @ShipCountry)", connection);

					command.Parameters.Add("@CustomerID",
								  SqlDbType.NChar, 5).Value = order.CustomerID;
					command.Parameters.AddWithValue("@EmployeeID",
															 order.EmployeeID);
					if (order.OrderDate == DateTime.MinValue)
						command.Parameters.AddWithValue("@OrderDate",
								 	  SqlDbType.DateTime).Value = DBNull.Value;
					else
						command.Parameters.AddWithValue("@OrderDate",
													 		  order.OrderDate);
					if (order.RequiredDate == DateTime.MinValue)
						command.Parameters.AddWithValue("@RequiredDate",
									  SqlDbType.DateTime).Value = DBNull.Value;
					else
						command.Parameters.AddWithValue("@RequiredDate", 
														   order.RequiredDate);
					if (order.ShippedDate == DateTime.MinValue)
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
													60).Value = order.ShipCity;
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
			catch(Exception)
			{
				Console.Write("Произошла ошибка, перепроверьте вводимые данные");
				return false;
			}
		}

		/// <summary>
		/// CustOrderHist
		/// </summary>
		/// <param name="CostumerID"></param>
		public bool CustOrderHist(string CustomerID)
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					var command = new SqlCommand(
					"EXEC Northwind.CustOrderHist @CustomerID", connection);
					command.Parameters.Add("@CustomerID", 
									 SqlDbType.NChar, 5).Value = CustomerID;

					connection.Open();

					SqlDataReader reader = command.ExecuteReader();

					int rows = 0;
					while (reader.Read())
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							Console.Write(reader.GetName(i) + " = ");
							if (reader.GetValue(i).ToString() == "")
								Console.WriteLine("null;");
							else Console.WriteLine(reader.GetValue(i) + "; ");
						}

						Console.WriteLine();
						rows++;
					}

					if ((rows != 0) || (reader.HasRows == false))
						return true;
					else return false;
				}
			}
			catch (Exception)
			{
			Console.Write("Произошла ошибка, перепроверьте вводимые данные");
			return false;
			}

		}
		/// <summary>
		/// CustOrdersDetail
		/// </summary>
		/// <param name="OrderID"></param>
		public bool CustOrdersDetail(int OrderID)
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					var command = new SqlCommand(
					"EXEC Northwind.CustOrdersDetail @OrderID", connection);
					command.Parameters.AddWithValue("@OrderID", OrderID);

					connection.Open();

					SqlDataReader reader = command.ExecuteReader();

					int rows = 0;
					while (reader.Read())
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							Console.Write(reader.GetName(i) + " = ");
							if (reader.GetValue(i).ToString() == "")
								Console.WriteLine("null;");
							else Console.WriteLine(reader.GetValue(i) + "; ");
						}
						Console.WriteLine();
						rows++;
					}

					if ((rows != 0) || (reader.HasRows == false))
						return true;
					else return false;
				}
			}
			catch (Exception)
			{
			Console.Write("Произошла ошибка, перепроверьте вводимые данные");
			return false;
			}
		}

		/// <summary>
		/// "Получить" заказ
		/// </summary>
		/// <param name="OrderId"></param>
		public bool GetOrder(int OrderId)
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					var command = new SqlCommand(
					"UPDATE Northwind.Orders SET ShippedDate = @ShippedDate"+
					" WHERE OrderID = @OrderID", connection);

					command.Parameters.AddWithValue("@OrderID", OrderId);
					command.Parameters.AddWithValue("@ShippedDate", 
															DateTime.Now);
					connection.Open();
					return command.ExecuteNonQuery() == 1;

				}
			}
			catch (Exception)
			{
			Console.Write("Произошла ошибка, перепроверьте вводимые данные");
			return false;
			}
		}

		/// <summary>
		/// Детали заказа
		/// </summary>
		/// <param name="OrderID"></param>
		public bool OrderDetails(int OrderID)
		{
			try
			{
				var order = new List<Orders>();
				var products = new List<Products>();
				var orderdetails = new List<OrderDetails>();

				using (var connection = new SqlConnection(ConnectionString))
				{
					var command = new SqlCommand(
						"SELECT o.OrderID, o.CustomerID, o.EmployeeID, "+
						"o.OrderDate, o.RequiredDate,  o.ShippedDate, "+
						"o.ShipVia, o.Freight, o.ShipName, o.ShipAddress, "+ 
						" o.ShipCity, o.ShipRegion, o.ShipPostalCode, "+
						" o.ShipCountry, p.ProductID, p.ProductName, "+
						"od.Quantity, od.UnitPrice, od.Discount FROM "+
						"Northwind.Orders AS o INNER JOIN " +
						"Northwind.[Order Details] AS od ON " +
						"o.OrderID = od.OrderID INNER JOIN " +
						"Northwind.Products AS p ON od.ProductID=p.ProductID"+
						" WHERE o.OrderID = @OrderID", connection);

					command.Parameters.AddWithValue("@OrderID", OrderID);
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						var o = new Orders();
						var p = new Products();
						var od = new OrderDetails();
						for (int i = 0; i < reader.FieldCount; i++)
						{
							Console.Write(reader.GetName(i) + " = ");
							if (reader.GetValue(i).ToString() == "")
								Console.WriteLine("null;");
							else Console.WriteLine(reader.GetValue(i) + "; ");

							if (reader.GetName(i).ToString() == "OrderID")
								o.OrderID = Convert.ToInt32(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "CustomerID") &&
									(reader.GetValue(i).ToString() != ""))
								o.CustomerID = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "EmployeeID") &&
									(reader.GetValue(i).ToString() != ""))
								o.EmployeeID = Convert.ToInt32(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "OrderDate") &&
									(reader.GetValue(i).ToString() != ""))
								o.OrderDate = Convert.ToDateTime(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "RequiredDate") &&
									(reader.GetValue(i).ToString() != ""))
								o.RequiredDate = Convert.ToDateTime(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShippedDate") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShippedDate = Convert.ToDateTime(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipVia") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipVia = Convert.ToInt32(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "Freight") &&
									(reader.GetValue(i).ToString() != ""))
								o.Freight = Convert.ToDouble(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipName") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipName = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipAddress") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipAddress = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipCity") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipCity = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipRegion") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipRegion = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipPostalCode") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipPostalCode = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ShipCountry") &&
									(reader.GetValue(i).ToString() != ""))
								o.ShipCountry = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ProductID") &&
									(reader.GetValue(i).ToString() != ""))
								p.ProductID = Convert.ToInt32(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "ProductName") &&
									(reader.GetValue(i).ToString() != ""))
								p.ProductName = Convert.ToString(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "Quantity") &&
									(reader.GetValue(i).ToString() != ""))
								od.Quantity = Convert.ToInt32(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "UnitPrice") &&
									(reader.GetValue(i).ToString() != ""))
								od.UnitPrice = Convert.ToDouble(reader.GetValue(i));
							if ((reader.GetName(i).ToString() == "Discount") &&
									(reader.GetValue(i).ToString() != ""))
								od.Discount = Convert.ToDouble(reader.GetValue(i));
						}
						Console.WriteLine();
						order.Add(o);
						products.Add(p);
						orderdetails.Add(od);
					}

					if (((order.Count != 0) && (products.Count != 0) &&
						(orderdetails.Count != 0))||(reader.HasRows == false))
						return true;
					else return false;
				}
			}
			catch (Exception)
			{
			Console.Write("Произошла ошибка, перепроверьте вводимые данные");
			return false;
			}
		}

		/// <summary>
		/// "Отправить" заказ
		/// </summary>
		/// <param name="OrderId"></param>
		public bool SendOrder(int OrderId)
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					var command = new SqlCommand(
						"UPDATE Northwind.Orders SET RequiredDate =" +
						"@RequiredDate WHERE OrderID = @OrderID", connection);

					command.Parameters.AddWithValue("@OrderID", OrderId);
					command.Parameters.AddWithValue("@RequiredDate", 
															DateTime.Now);
					connection.Open();
					return command.ExecuteNonQuery() == 1;
				}
			}
			catch (Exception)
			{
			Console.Write("Произошла ошибка, перепроверьте вводимые данные");
			return false;
			}
		}

		/// <summary>
		/// Вывод таблицы заказов
		/// </summary>
		/// <param name=""></param>
		public bool ShowOrders()
		{
			var order = new List<Orders>();
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(
					"SELECT OrderID, CustomerID, EmployeeID, OrderDate," + 
					"RequiredDate,  ShippedDate, ShipVia, Freight, ShipName," +
					"ShipAddress, ShipCity, ShipRegion, ShipPostalCode," +
					"ShipCountry FROM Northwind.Orders", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var o = new Orders();
                    for (int i = 0; i < reader.FieldCount; i++)
					{

						Console.Write(reader.GetName(i) + " = ");
						if (reader.GetValue(i).ToString() == "")
							Console.WriteLine("null;");
						else Console.WriteLine(reader.GetValue(i) + "; ");

						if (reader.GetName(i).ToString() == "OrderID")
							o.OrderID = Convert.ToInt32(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "CustomerID") &&
								(reader.GetValue(i).ToString() != ""))
							o.CustomerID = Convert.ToString(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "EmployeeID") &&
								(reader.GetValue(i).ToString() != ""))
							o.EmployeeID = Convert.ToInt32(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "OrderDate") &&
								(reader.GetValue(i).ToString() != ""))
							o.OrderDate = Convert.ToDateTime(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "RequiredDate") &&
								(reader.GetValue(i).ToString() != ""))
							o.RequiredDate = Convert.ToDateTime(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShippedDate") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShippedDate = Convert.ToDateTime(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipVia") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipVia = Convert.ToInt32(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "Freight") &&
								(reader.GetValue(i).ToString() != ""))
							o.Freight = Convert.ToDouble(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipName") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipName = Convert.ToString(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipAddress") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipAddress = Convert.ToString(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipCity") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipCity = Convert.ToString(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipRegion") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipRegion = Convert.ToString(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipPostalCode") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipPostalCode = Convert.ToString(reader.GetValue(i));
						if ((reader.GetName(i).ToString() == "ShipCountry") &&
								(reader.GetValue(i).ToString() != ""))
							o.ShipCountry = Convert.ToString(reader.GetValue(i));
						if (i == reader.FieldCount - 1)
						{
							if (o.ShippedDate == DateTime.MinValue)
							{
								o.OrderStatus = OrderTypes.Underway;
							}
							else
							{
								o.OrderStatus = OrderTypes.Done;
							}
							if (o.OrderDate == DateTime.MinValue)
							{
								o.OrderStatus = OrderTypes.NotShipped;
							}
						}		
					}
					Console.WriteLine();
					order.Add(o);					
				}

				if (order.Count != 0)
					return true;
				else return false;
			}

		}
	}
}
