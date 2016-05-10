using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ForumWEB.Models;
using BLL.Validation;
using System.Web.Security;

namespace ForumWEB.Controllers
{
    public class AccountController : Controller
    {
		// GET: /Account/
		ForumBLL Data = new ForumBLL();

		/// <summary>
		/// Вход в систему
		/// </summary>
		/// <param name=""></param>
		public ActionResult LogIn()
		{
			return View();
		}

		/// <summary>
		/// Приём данных со страницы входа
		/// </summary>
		/// <param name=""></param>
		[HttpPost]
		public ActionResult LogIn(LoginViewModel userAndPassword)
		{
			try
			{
				if (!string.IsNullOrEmpty(userAndPassword.Login) && !string.IsNullOrEmpty(userAndPassword.Password)
					&& (Data.Login(userAndPassword.Login, userAndPassword.Password) == true))
				{
					FormsAuthentication.SetAuthCookie(userAndPassword.Login, false);

					return Redirect("~/");
				}
				if (Data.Login(userAndPassword.Login, userAndPassword.Password) == false)
				{
					ModelState.AddModelError("WrongPassword", "Вы ввели неправильный пароль");
					return View(userAndPassword);
				}
				else return View(userAndPassword);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View(userAndPassword);
			}
		}

		/// <summary>
		/// Выход из системы
		/// </summary>
		/// <param name=""></param>
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();

			return Redirect("~/");
		}
	}
}