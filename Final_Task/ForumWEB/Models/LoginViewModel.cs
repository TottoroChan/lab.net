using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForumWEB.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Вы не ввели Логин")]
		public string Login { get; set; }
		
		[Required(ErrorMessage = "Вы не ввели Пароль")]
		public string Password { get; set; }
	}
}
