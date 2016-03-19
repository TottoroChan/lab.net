using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Orders
	{
	
		public int OrderID { get; set; }
		public string CustomerID  { get; set; }
		public int EmployeeID  { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate{ get; set; }
		public DateTime ShippedDate{ get; set; }
		public int ShipVia { get; set; }
		public double Freight { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }
		public OrderTypes OrderStatus { get; set; }
		
		public Orders()
		{
			this.OrderID = 0;
			this.CustomerID = null;
			this.EmployeeID = 0;
			this.OrderDate = DateTime.MinValue;
			this.RequiredDate = DateTime.MinValue;
			this.ShippedDate = DateTime.MinValue;
			this.ShipVia = 0;
			this.Freight = 0;
			this.ShipName = null;
			this.ShipAddress = null;
			this.ShipCity = null;
			this.ShipRegion = null;
			this.ShipPostalCode = null;
			this.ShipCountry = null;
			this.OrderStatus = 0;

		}

		public Orders( string CustomerID, int EmployeeID, 
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
			this.ShipVia = ShipVia;
			this.Freight = Freight;
			this.ShipName = ShipName;
			this.ShipAddress = ShipAddress;
			this.ShipCity = ShipCity;
			this.ShipRegion = ShipRegion;
			this.ShipPostalCode = ShipPostalCode;
			this.ShipCountry = ShipCountry;
		}
	}
}
