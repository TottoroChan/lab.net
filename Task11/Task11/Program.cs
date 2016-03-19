using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Task11
{
	class Program
	{
		static void Main(string[] args)
		{
			DALDB db = new DALDB();
			//string s = "RATTC";
			//int n = 10248;
			//	db.OrderDetails(n);
			int k = -10;
			db.OrderDetails(k);
			//db.ShowOrders();

			Console.ReadKey();
		}
	}
}
