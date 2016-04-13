using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Orders
	{
		/// <summary>
		/// Данные для вывода краткой информации о заказе
		/// </summary>
		public int OrderID { get; set; }
		public string CustomerID { get; set; }
		public string ContactName { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderTypes OrderStatus { get; set; }
		public double Total { get; set; }

		public Orders()
		{
			this.OrderID = 0;
			this.ContactName = null;
			this.OrderDate = DateTime.MinValue;
			this.Total = 0;
			this.OrderStatus = 0;

		}

	/*	public Orders(string CustomerID, int EmployeeID,
			DateTime OrderDate, DateTime RequiredDate, DateTime ShippedDate,
			int ShipVia, float Freight, string ShipName, string ShipAddress,
			string ShipCity, string ShipRegion, string ShipPostalCode,
			string ShipCountry)
		{
			this.CustomerID = CustomerID;
			this.EmployeeID = EmployeeID;
			this.OrderDate = OrderDate;
			this.RequiredDate = RequiredDate;
			this.ShippedDate = ShippedDate;
		}*/
	}
}
