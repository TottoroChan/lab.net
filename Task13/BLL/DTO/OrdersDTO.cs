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
	public class OrdersDTO
	{

		public int OrderID { get; set; }
		public string CustomerID { get; set; }
		public string ContactName { get; set; }
		public DateTime OrderDate { get; set; }
		public string OrderStatus { get; set; }
		public double Total { get; set; }

		public OrdersDTO()
		{
			this.OrderID = 0;
			this.ContactName = null;
			this.OrderDate = DateTime.MinValue;
			this.Total = 0;
			this.OrderStatus = null;

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
