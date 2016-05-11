using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForumWEB.Models
{
	public class UsersViewModel
	{
		public int UserID { get; set; }

		[Required(ErrorMessage = "Вы не ввели имя")]
		[MaxLength(20, ErrorMessage = "Имя должно быть от 4 до 20 символов")]
		[MinLength(4, ErrorMessage = "Имя должно быть от 4 до 20 символов")]
		public string Name { get; set; }
		public DateTime RegistrationDate { get; set; }


		[Required(ErrorMessage = "Вы не ввели логин")]
		[MaxLength(20, ErrorMessage = "Логин должен быть от 4 до 20 символов")]
		[MinLength(4, ErrorMessage = "Логин должен быть от 4 до 20 символов")]
		public string Login { get; set; }
		public int TypeID { get; set; }
		public string UserType { get; set; }

		[Required(ErrorMessage = "Вы не ввели пароль")]
		[MaxLength(20, ErrorMessage = "Пароль должен быть от 4 до 20 символов")]
		[MinLength(4, ErrorMessage = "Пароль должен быть от 4 до 20 символов")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Вы не повторили пароль")]
		public string ConfirmPassword { get; set; }
		public string Avatar { get; set; }

	}
}
