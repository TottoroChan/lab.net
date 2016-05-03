using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumWEB.Models
{
	public class UsersViewModel
	{
		public string Name { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Login { get; set; }
		public int TypeID { get; set; }
		public string UserType { get; set; }

	}
}
