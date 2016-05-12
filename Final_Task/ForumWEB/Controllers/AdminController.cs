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
		/// Список тем на форуме
		/// </summary>
		/// <param name=""></param>
		public ActionResult TopicsList()
		{
			try
			{
				List<TopicsViewModel> topics = new List<TopicsViewModel>();
				var SectionsBLL = Data.GetSections();
				ViewBag.EmptySection = new string[SectionsBLL.Count()];
				foreach (var s in SectionsBLL)
				{
					var TopicsBLL = Data.GetTopicsForAdmin(s.SectionID);
					if (TopicsBLL.Count() == 0)
					{
						TopicsViewModel topic = new TopicsViewModel();
						topic.SectionID = s.SectionID;
						topic.SectionName = s.SectionName;
						topic.EmptySection = "В разделе ещё нет тем";
						topics.Add(topic);
					}
					else
					{
						foreach (var t in TopicsBLL)
						{
							TopicsViewModel topic = new TopicsViewModel();
							topic.SectionID = s.SectionID;
							topic.SectionName = s.SectionName;
							topic.TopicID = t.TopicID;
							topic.TopicName = t.TopicName;
							topic.AuthorName = t.Name;
							topic.CreateDate = t.CreateDate;
							topic.MessageCount = t.MessageCount;
							var u = Data.LastMessageForAdmin(t.TopicID);
							topic.Name = u.Name;
							topic.SendDate = u.RegistrationDate;
							var messages = Data.GetMessages(t.TopicID);
							foreach (var m in messages)
							{
								if (m.StatusID == 0)
									topic.InvisibleMessages++;
							}
							topics.Add(topic);
						}
					}
				}
				return PartialView(topics);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
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
				return View();
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
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

					return RedirectToAction("Index", "Home");
				}

				else
				{
					ModelState.AddModelError("Error", "Вы не ввели название раздела.");
					return View();
				}
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
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
					UserBLL.Avatar = user.Avatar;
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
				return RedirectToAction("Topic", "Home", new { TopicID = TopicID });
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}
		
		public ActionResult DropSection(int SectionID)
		{
			try
			{
				Data.DropSection(SectionID);
				return RedirectToAction("Index", "Home");
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		public ActionResult DropTopic(int TopicID)
		{
			try
			{
				Data.DropTopic(TopicID);
				return RedirectToAction("Index", "Home");
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		public ActionResult DropMessage(int MessageID,int TopicID)
		{
			try
			{
				Data.DropMessage(MessageID);
				return RedirectToAction("Topic", "Home", new { TopicID = TopicID });
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}
	}
}