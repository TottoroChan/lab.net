using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	/// <summary>
	/// Статус заказа
	/// </summary>
	public enum OrderTypes
	{
		NotShipped,
		Underway,
		Done
	}
}
