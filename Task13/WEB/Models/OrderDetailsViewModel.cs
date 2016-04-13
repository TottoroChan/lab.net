using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
	public class OrderDetailsViewModel
	{
		[Required(ErrorMessage = "Order ID Required")]
		[Range(10000, 99999, ErrorMessage = "Must be 5 characters")]
		public int OrderID { get; set; }

		[Required(ErrorMessage = "Customer ID Required")]
		[StringLength(5, ErrorMessage = "Must be 5 characters")]
		[MinLength(5, ErrorMessage = "Must be 5 characters")]
		public string CustomerID { get; set; }

		[Required(ErrorMessage = "Employee ID Required")]
		[Range(1, 9, ErrorMessage = "Must be between 1 and 9")]
		public int EmployeeID { get; set; }

		[Required(ErrorMessage = "Order Date Required")]
		public DateTime OrderDate { get; set; }

		[Required(ErrorMessage = "Required Date Required")]
		public DateTime RequiredDate { get; set; }

		[Required(ErrorMessage = "Shipped Date Required")]
		public DateTime ShippedDate { get; set; }

		[Required(ErrorMessage = "Ship Via Required")]
		[Range(1, 3, ErrorMessage = "Ship Via must be between 1 and 3")]
		public int ShipVia { get; set; }

		[Required(ErrorMessage = "Freight Required")]
		public string Freight { get; set; }

		[Required(ErrorMessage = "Ship Name Required")]
		[StringLength(40, ErrorMessage = "Must be under 40 characters")]
		public string ShipName { get; set; }

		[Required(ErrorMessage = "Ship Addres Required")]
		[StringLength(60, ErrorMessage = "Must be under 60 characters")]
		public string ShipAddress { get; set; }

		[Required(ErrorMessage = "Ship City Required")]
		[StringLength(15, ErrorMessage = "Must be under 15 characters")]
		public string ShipCity { get; set; }

		[Required(AllowEmptyStrings = true, ErrorMessage = "Ship Region Required")]
		[StringLength(15, ErrorMessage = "Must be under 15 characters")]
		public string ShipRegion { get; set; }

		[Required(ErrorMessage = "Ship Postal Code Required")]
		[StringLength(10, ErrorMessage = "Must be under 10 characters")]
		public string ShipPostalCode { get; set; }

		[Required(ErrorMessage = "Ship Country Required")]
		[StringLength(15, ErrorMessage = "Must be under 15 characters")]
		public string ShipCountry { get; set; }
		
		public string OrderStatus { get; set; }

		[Required(ErrorMessage = "Product ID Required")]
		[Range(1, 77, ErrorMessage = "Prodect ID must be between 1 and 77")]
		public int ProductID { get; set; }
		
		public string ProductName { get; set; }

		[Required(ErrorMessage = "Quantity Required")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Unit Price Required")]
		public string UnitPrice { get; set; }

		[Required(ErrorMessage = "Discount Required")]
		public string Discount { get; set; }
	}
}