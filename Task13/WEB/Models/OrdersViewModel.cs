using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
	public class OrdersViewModel
	{
		[Required(ErrorMessage = "Order ID Required")]
		[Range(10000, 99999, ErrorMessage = "Must be 5 characters")]
		public int OrderID { get; set; }

		[Required(ErrorMessage = "Customer ID Required")]
		[StringLength(5, ErrorMessage = "Must be 5 characters")]
		[MinLength(5, ErrorMessage = "Must be 5 characters")]
		public string CustomerID { get; set; }
		
		public string ContactName { get; set; }

		[Required(ErrorMessage = "Order Date Required")]
		public DateTime OrderDate { get; set; }
		
		public string OrderStatus { get; set; }
		
		public double Total { get; set; }
	}
}