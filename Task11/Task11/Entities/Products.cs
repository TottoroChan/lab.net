using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	class Products
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }

		public Products()
		{
			this.ProductID = 0;
			this.ProductName = null;
		}

	}
}
