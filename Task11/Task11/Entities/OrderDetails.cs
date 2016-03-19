using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	class OrderDetails
	{
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public double Discount { get; set; }


		public OrderDetails()
		{
			this.Quantity = 1;
			this.UnitPrice = 0;
			this.Discount = 0;
		}
	}
}
