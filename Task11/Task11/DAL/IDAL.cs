using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	/// <summary>
	/// Интерфейс DAL
	/// </summary>
	public interface IDAL
	{
		bool ShowOrders();
        bool OrderDetails(int id);
        bool CreateOrder(Entities.Orders order);
        bool SendOrder(int id);
        bool GetOrder(int id);
		bool CustOrderHist(string id);
		bool CustOrdersDetail(int id);
	}
}
