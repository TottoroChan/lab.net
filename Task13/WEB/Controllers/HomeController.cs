using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.DTO;
using BLL.Validation;
using WEB.Models;

namespace WEB.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		BLLDB Data = new BLLDB();

		/// <summary>
		/// Вывод таблицы заказов
		/// </summary>
		/// <param name=""></param>
		public ActionResult Index()
		{
			try {
				List<OrdersViewModel> Orders = new List<OrdersViewModel>();
				var OrdersBLL = Data.ShowOrders();

				foreach (var o in OrdersBLL)
				{
					OrdersViewModel order = new OrdersViewModel();
					order.OrderID = o.OrderID;
					order.CustomerID = o.CustomerID;
					order.ContactName = o.ContactName;
					order.OrderDate = o.OrderDate;
					order.OrderStatus = o.OrderStatus.ToString();
					order.Total = o.Total;
					Orders.Add(order);
				}

				return View(Orders);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		/// <summary>
		/// Вывод детальной информации о заказе
		/// </summary>
		/// <param name="id"></param>
		public ActionResult OrderDetails(int id)
		{
			try
			{
				List<OrderDetailsViewModel> Orders = new List<OrderDetailsViewModel>();
				var OrdersBLL = Data.ShowOrderDetails(id);

				foreach (var o in OrdersBLL)
				{
					OrderDetailsViewModel order = new OrderDetailsViewModel();
					order.OrderID = o.OrderID;
					order.CustomerID = o.CustomerID;
					order.EmployeeID = o.EmployeeID;
					order.OrderDate = o.OrderDate;
					order.RequiredDate = o.RequiredDate;
					order.ShippedDate = o.ShippedDate;
					order.ShipVia = o.ShipVia;
					order.Freight = o.Freight.ToString();
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
					order.UnitPrice = o.UnitPrice.ToString();
					order.Discount = o.Discount.ToString();
					Orders.Add(order);
				}

				return View(Orders);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		/// <summary>
		/// Страница для создания нового заказа или обновления уже существующего
		/// </summary>
		/// <param name=""></param>
		[HttpGet]
		public ActionResult CreateOrder()
		{
			try
			{
				OrdersViewModel Order = new OrdersViewModel();
				return View(Order);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		/// <summary>
		/// Создание нового заказа
		/// </summary>
		/// <param name="order"></param>
		[HttpPost]
		public ActionResult CreateOrder(OrdersViewModel order)
		{
			try
			{
				//Если введены поля CustomerId и OrderDate, то создаётся новый заказ
				if ((ModelState.IsValidField("CustomerId")) && (ModelState.IsValidField("OrderDate")))
				{

					OrdersDTO OrderBLL = new OrdersDTO();
					OrderBLL.CustomerID = order.CustomerID;
					OrderBLL.OrderDate = order.OrderDate;
					Data.CreateOrder(OrderBLL);
					//После успешного создания заказа, пользователя перенаправляют на главную страницу
					return RedirectToAction("Index");
				}
				else //если введено поле OrderID то пользователя перенаправляют на страницу с редактированием заказа
					if (ModelState.IsValidField("OrderID"))
						return RedirectToAction("UpdateOrder", new { OrderID = order.OrderID });
				//Если валидация не проходит, то пользователя возвращают на страницу создания заказа
					else return View(order);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}

		}

		/// <summary>
		/// Получение информации о заказе и передача 
		/// полученного на страницу обновления заказа
		/// </summary>
		/// <param name="OrderID"></param>
		[HttpGet]
		public ActionResult UpdateOrder(int OrderID)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var o = Data.OrderDetails(OrderID);
					OrderDetailsViewModel order = new OrderDetailsViewModel();
					order.OrderID = o.OrderID;
					order.CustomerID = o.CustomerID;
					order.EmployeeID = o.EmployeeID;
					order.OrderDate = o.OrderDate;
					order.RequiredDate = o.RequiredDate;
					order.ShippedDate = o.ShippedDate;
					order.ShipVia = o.ShipVia;
					order.Freight = o.Freight.ToString();
					order.ShipName = o.ShipName;
					order.ShipAddress = o.ShipAddress;
					order.ShipCity = o.ShipCity;
					order.ShipRegion = o.ShipRegion;
					order.ShipPostalCode = o.ShipPostalCode;
					order.ShipCountry = o.ShipCountry;
					return View(order);
				}
				else return CreateOrder();
            }
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		/// <summary>
		/// Обновление существующего заказа и добавление новых полей 
		/// </summary>
		/// <param name="OrderID"></param>
		[HttpPost]
		public ActionResult UpdateOrder(OrderDetailsViewModel order)
		{
			try
			{
				if (ModelState.IsValid)
				{
					OrderDetailsDTO OrderBLL = new OrderDetailsDTO();

					OrderBLL.OrderID = order.OrderID;
					OrderBLL.CustomerID = order.CustomerID;
					OrderBLL.EmployeeID = order.EmployeeID;
					OrderBLL.OrderDate = order.OrderDate;
					OrderBLL.RequiredDate = order.RequiredDate;
					OrderBLL.ShippedDate = order.ShippedDate;
					OrderBLL.ShipVia = order.ShipVia;
					OrderBLL.Freight = Convert.ToDouble(order.Freight);
					OrderBLL.ShipName = order.ShipName;
					OrderBLL.ShipAddress = order.ShipAddress;
					OrderBLL.ShipCity = order.ShipCity;
					OrderBLL.ShipRegion = order.ShipRegion;
					OrderBLL.ShipPostalCode = order.ShipPostalCode;
					OrderBLL.ShipCountry = order.ShipCountry;
					OrderBLL.OrderStatus = order.OrderStatus;
					OrderBLL.ProductID = order.ProductID;
					OrderBLL.ProductName = order.ProductName;
					OrderBLL.Quantity = order.Quantity;
					OrderBLL.UnitPrice = Convert.ToDouble(order.UnitPrice);
					OrderBLL.Discount = Convert.ToDouble(order.Discount);

					Data.AddOrderDetails(OrderBLL);

					//После успешного обновления заказа, пользователя перенаправляют на главную страницу
					return RedirectToAction("Index");
				}
				else return View(order);
			}
			catch(ValidationException ex)
			{
				return Content(ex.Message);
			}
		}
	}
}