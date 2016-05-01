using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumWEB.Models;
using System.Web.Security;

namespace ForumWEB.Controllers
{
    public class AccountController : Controller
    {
		// GET: /Account/

		public ActionResult LogOn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(LoginViewModel userAndPassword, string ReturnUrl)
		{
			if (!string.IsNullOrEmpty(userAndPassword.Login) && !string.IsNullOrEmpty(userAndPassword.Password))
			{
				FormsAuthentication.SetAuthCookie(userAndPassword.Login, false);

				return Redirect(ReturnUrl);
			}

			return View(userAndPassword);
		}

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return Redirect("~/");
		}
	}
}