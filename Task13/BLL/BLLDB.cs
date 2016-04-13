using System;
using DAL.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLL.DTO;
using BLL.Validation;
using DAL;

namespace BLL
{
	public class BLLDB
	{
		DALDB Data = new DALDB();

		/// <summary>
		/// Метод создания заказа
		/// </summary>
		/// <param name="order"></param>
		public bool CreateOrder(OrdersDTO order)
		{
			try
			{
				Orders OrderDAL = new Orders();
				OrderDAL.CustomerID = order.CustomerID;
				OrderDAL.OrderDate = order.OrderDate;

				if (Data.CreateOrder(OrderDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}


		/// <summary>
		/// Детали заказа для таблицы заказов
		/// </summary>
		/// <param name="OrderID"></param>
		public IEnumerable<OrderDetailsDTO> ShowOrderDetails(int OrderID)
		{
			try {
				List<OrderDetailsDTO> Orders = new List<OrderDetailsDTO>();
				var OrdersDAL = Data.ShowOrderDetails(OrderID);

				foreach (var o in OrdersDAL)
				{
					OrderDetailsDTO order = new OrderDetailsDTO();
					order.OrderID = o.OrderID;
					order.CustomerID = o.CustomerID;
					order.EmployeeID = o.EmployeeID;
					order.OrderDate = o.OrderDate;
					order.RequiredDate = o.RequiredDate;
					order.ShippedDate = o.ShippedDate;
					order.ShipVia = o.ShipVia;
					order.Freight = o.Freight;
					order.ShipName = o.ShipName;
					order.ShipAddress = o.ShipAddress;
					order.ShipCity = o.ShipCity;
					order.ShipRegion = o.ShipRegion;
					order.ShipPostalCode = o.ShipPostalCode;
					order.ShipCountry = o.ShipCountry;
					order.OrderStatus = o.OrderStatus.ToString();
					order.ProductID = o.ProductID;
					order.ProductName = o.ProductName;
					order.Quantity = o.Quantity;
					order.UnitPrice = o.UnitPrice;
					order.Discount = o.Discount;
					Orders.Add(order);
				}
				return Orders;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Детали заказа для обновления данных
		/// </summary>
		/// <param name="OrderID"></param>
		public OrderDetailsDTO OrderDetails(int OrderID)
		{
			try
			{
				var o = Data.OrderDetails(OrderID);
				OrderDetailsDTO order = new OrderDetailsDTO();
				order.OrderID = o.OrderID;
				order.CustomerID = o.CustomerID;
				order.EmployeeID = o.EmployeeID;
				order.OrderDate = o.OrderDate;
				order.RequiredDate = o.RequiredDate;
				order.ShippedDate = o.ShippedDate;
				order.ShipVia = o.ShipVia;
				order.Freight = o.Freight;
				order.ShipName = o.ShipName;
				order.ShipAddress = o.ShipAddress;
				order.ShipCity = o.ShipCity;
				order.ShipRegion = o.ShipRegion;
				order.ShipPostalCode = o.ShipPostalCode;
				order.ShipCountry = o.ShipCountry;
				order.OrderStatus = o.OrderStatus.ToString();
				order.ProductID = o.ProductID;
				order.ProductName = o.ProductName;
				order.Quantity = o.Quantity;
				order.UnitPrice = o.UnitPrice;
				order.Discount = o.Discount;
				return order;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Вывод таблицы заказов
		/// </summary>
		/// <param name=""></param>
		public IEnumerable<OrdersDTO> ShowOrders()
		{
			List<OrdersDTO> Orders = new List<OrdersDTO>();
			var OrdersDAL = Data.ShowOrders();

			foreach (var o in OrdersDAL)
			{
				OrdersDTO order = new OrdersDTO();
				order.OrderID = o.OrderID;
				order.CustomerID = o.CustomerID;
				order.ContactName = o.ContactName;
				order.OrderDate = o.OrderDate;
				order.OrderStatus = o.OrderStatus.ToString();
				order.Total = o.Total;
				Orders.Add(order);
			}
			return Orders;
		}

		/// <summary>
		/// Добавление деталей заказа 
		/// </summary>
		/// <param name="order"></param>
		public bool AddOrderDetails(OrderDetailsDTO order)
		{
			try {
				OrderDetails orderDAL = new OrderDetails();
				orderDAL.OrderID = order.OrderID;
				orderDAL.CustomerID = order.CustomerID;
				orderDAL.EmployeeID = order.EmployeeID;
				orderDAL.OrderDate = order.OrderDate;
				orderDAL.RequiredDate = order.RequiredDate;
				orderDAL.ShippedDate = order.ShippedDate;
				orderDAL.ShipVia = order.ShipVia;
				orderDAL.Freight = order.Freight;
				orderDAL.ShipName = order.ShipName;
				orderDAL.ShipAddress = order.ShipAddress;
				orderDAL.ShipCity = order.ShipCity;
				orderDAL.ShipRegion = order.ShipRegion;
				orderDAL.ShipPostalCode = order.ShipPostalCode;
				orderDAL.ShipCountry = order.ShipCountry;
				orderDAL.ProductID = order.ProductID;
				orderDAL.ProductName = order.ProductName;
				orderDAL.Quantity = order.Quantity;
				orderDAL.UnitPrice = order.UnitPrice;
				orderDAL.Discount = order.Discount;

				if (Data.AddOrderDetail(orderDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

	}
}
