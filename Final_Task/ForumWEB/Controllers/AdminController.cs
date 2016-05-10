using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ForumWEB.Models;
using BLL.Validation;
using BLL.DTO;

namespace ForumWEB.Controllers
{
    public class AdminController : Controller
    {
		ForumBLL Data = new ForumBLL();
		// GET: Admin

		/// <summary>
		/// Главная страница форума со списком разделов и тем
		/// </summary>
		/// <param name=""></param>
		public ActionResult Index()
		{
			try
			{
				List<TopicsViewModel> topics = new List<TopicsViewModel>();
				var SectionsBLL = Data.GetSections();

				int length = SectionsBLL.Count();
				ViewBag.SectionID = new int[length];
				ViewBag.SectionName = new string[length];

				for (int i = 0; i < length; i++)
				{
					ViewBag.SectionID[i] = SectionsBLL.ElementAt(i).SectionID;
					ViewBag.SectionName[i] = SectionsBLL.ElementAt(i).SectionName;

					var TopicsBLL = Data.GetTopicsForAdmin(SectionsBLL.ElementAt(i).SectionID);
					foreach (var t in TopicsBLL)
					{
						TopicsViewModel topic = new TopicsViewModel();
						topic.SectionName = ViewBag.SectionName[i];
						topic.TopicID = t.TopicID;
						topic.TopicName = t.TopicName;
						topic.AuthorName = t.Name;
						topic.CreateDate = t.CreateDate;
						topic.MessageCount = t.MessageCount;
						var u = Data.LastMessageForAdmin(t.TopicID);
						topic.Name = u.Name;
						topic.SendDate = u.RegistrationDate;
						topics.Add(topic);
					}

				}

				return View(topics);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return RedirectToAction("Index");
			}
		}
		/// <summary>
		/// Создание нового раздела
		/// </summary>
		/// <param name=""></param>
		public ActionResult NewSection()
		{
			try
			{
				ViewBag.SectionName = null;
				return PartialView();
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View("Index");
			}
		}

		/// <summary>
		/// Приём данных создания нового раздела
		/// </summary>
		/// <param name="sectionName"></param>
		[HttpPost]
		public ActionResult NewSection(string sectionName)
		{
			try
			{
				if (sectionName != "")
				{
					Data.CreateSection(sectionName);

					return RedirectToAction("Index");
				}

				else
				{
					ModelState.AddModelError("Error", "Вы не ввели название раздела.");
					return View();
				}
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return RedirectToAction("Index");
			}
		}

		/// <summary>
		/// Изменение информации о пользователе
		/// </summary>
		/// <param name="UserID"></param>
		public ActionResult ChangeUserType(int UserID)
		{
			try
			{
				var UserBLL = Data.GetUserById(UserID);
				UsersViewModel user = new UsersViewModel();
				user.UserID = UserBLL.UserID;
				user.Login = UserBLL.Login;
				user.Password = UserBLL.Password;
				user.Name = UserBLL.Name;
				user.Avatar = UserBLL.Avatar;
				user.RegistrationDate = UserBLL.RegistrationDate;
				user.TypeID = UserBLL.TypeID;
				user.UserType = UserBLL.UserType;

				return View(user);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View(UserID);
			}
		}

		/// <summary>
		/// Приём данных о пользователе
		/// </summary>
		/// <param name="user"></param>
		[HttpPost]
		public ActionResult ChangeUserType(UsersViewModel user)
		{
			try
			{
				ModelState.Remove("ConfirmPassword");
				if ((ModelState.IsValid))
				{

					UsersDTO UserBLL = new UsersDTO();
					UserBLL.Name = user.Name;
					UserBLL.Login = user.Login;
					UserBLL.Password = user.Password;
					UserBLL.UserID = user.UserID;
					UserBLL.TypeID = user.TypeID;
					UserBLL.RegistrationDate = user.RegistrationDate;
					Data.ChangeUserType(UserBLL);

					return RedirectToAction("Index");
				}

				else return View(user);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View(user);
			}
		}

		/// <summary>
		/// изменение видимости сообщения
		/// </summary>
		/// <param name="MessageID"></param>
		/// <param name="StatusID"></param>
		/// <param name="TopicID"></param>
		public ActionResult ChangeMessageStatus(int MessageID, int StatusID, int TopicID)
		{
			try
			{
				Data.ChangeMessageStatus(MessageID, StatusID);
				return RedirectToAction("Topic", new { TopicID = TopicID });
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return RedirectToAction("Topic", new { TopicID = TopicID });
			}
		}

	}
}