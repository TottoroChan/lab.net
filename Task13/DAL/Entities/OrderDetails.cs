using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	/// <summary>
	/// Данные о заказе и его деталях
	/// </summary>
	public class OrderDetails
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
		public OrderTypes OrderStatus { get; set; }
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Discount { get; set; }


		public OrderDetails()
		{
			this.OrderID = -1;
			this.CustomerID = null;
			this.EmployeeID = -1;
			this.OrderDate = DateTime.MinValue;
			this.RequiredDate = DateTime.MinValue;
			this.ShippedDate = DateTime.MinValue;
			this.ShipVia = -1;
			this.Freight = -1;
			this.ShipName = null;
			this.ShipAddress = null;
			this.ShipCity = null;
			this.ShipRegion = null;
			this.ShipPostalCode = null;
			this.ShipCountry = null;
			this.OrderStatus = 0;
			this.ProductID = -1;
			this.ProductName = null;
			this.Quantity = -1;
			this.UnitPrice = -1;
			this.Discount = -1;
		}
	}
}
