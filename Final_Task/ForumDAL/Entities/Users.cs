using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Users
	{
		public int UserID { get; set; }
		public string Name { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public int TypeID { get; set; }
		public string UserType { get; set; }

		public Users()
		{
			UserID = 0;
			Name = null;
			RegistrationDate = DateTime.MinValue;
			Login = null;
			Password = null;
			TypeID = 0;
			UserType = null;
		}

	}
}
