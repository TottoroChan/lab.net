using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace BLL.DTO
{
	/// <summary>
	/// Объект для передачи данных их базы в слой представления 
	/// </summary>
	public class OrderDetailsDTO
	{
		public int OrderID { get; set; }
		public string CustomerID { get; set; }
		public int EmployeeID { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public DateTime ShippedDate { get; set; }
		public int ShipVia { get; set; }
		public double Freight { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }
		public string OrderStatus { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Discount { get; set; }


		public OrderDetailsDTO()
		{
			this.OrderID = 0;
			this.CustomerID = null;
			this.EmployeeID = 0;
			this.OrderDate = DateTime.MinValue;
			this.RequiredDate = DateTime.MinValue;
			this.ShippedDate = DateTime.MinValue;
			this.ShipVia = 0;
			this.Freight = 0.0;
			this.ShipName = null;
			this.ShipAddress = null;
			this.ShipCity = null;
			this.ShipRegion = null;
			this.ShipPostalCode = null;
			this.ShipCountry = null;
			this.OrderStatus = null;
			this.ProductID = 0;
			this.ProductName = null;
			this.Quantity = 0;
			this.UnitPrice = 0.0;
			this.Discount = 0.0;
		}
	}
}
