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
	
	public class HomeController : Controller
    {
		ForumBLL Data = new ForumBLL();
		// GET: Home

		/// <summary>
		/// Главная страница форума, если пользователь являтся администратором,
		/// то его перенаправляют в контроллер администратора
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

				for (int i = 0; i< length; i++)
				{
					ViewBag.SectionID[i] = SectionsBLL.ElementAt(i).SectionID;
					ViewBag.SectionName[i] = SectionsBLL.ElementAt(i).SectionName;

					if (User.IsInRole("Administrator"))
					{
						return RedirectToAction("Index", "Admin");
					}
					else
					{
						var TopicsBLL = Data.GetTopics(SectionsBLL.ElementAt(i).SectionID);
						foreach (var t in TopicsBLL)
						{
							TopicsViewModel topic = new TopicsViewModel();
							topic.SectionName = ViewBag.SectionName[i];
							topic.TopicID = t.TopicID;
							topic.TopicName = t.TopicName;
							topic.AuthorName = t.Name;
							topic.CreateDate = t.CreateDate;
							topic.MessageCount = t.MessageCount;
							var u = Data.LastMessage(t.TopicID);
							topic.Name = u.Name;
							topic.SendDate = u.RegistrationDate;
							topics.Add(topic);
						}
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
		/// Создание новой темы
		/// </summary>
		/// <param name="SectionID"></param>
		/// <param name="SectionName"></param>
		public ActionResult NewTopic(int[] SectionID, string[] SectionName)
		{
			try
			{
				TopicsViewModel newTopic = new TopicsViewModel();
				ViewBag.SectionID = SectionID;
				ViewBag.SectionName = SectionName;
				var curentUser = Data.GetCurentUser(User.Identity.Name);
				ViewBag.Avatar = curentUser.Avatar;
				ViewBag.Name = curentUser.Name;
				ViewBag.UserID = curentUser.UserID;
				return PartialView(newTopic);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return RedirectToAction("Index");
			}
		}

		/// <summary>
		/// Приём данных о новой теме
		/// </summary>
		/// <param name="newTopic"></param>
		[HttpPost]
		public ActionResult NewTopic(TopicsViewModel newTopic)
		{
			try
			{
				if (ModelState.IsValid)
				{

					TopicsDTO TopicBLL = new TopicsDTO();
					TopicBLL.SectionID = newTopic.SectionID;
					TopicBLL.TopicName = newTopic.TopicName;
					TopicBLL.TopicText = newTopic.TopicText;
					TopicBLL.UserID = newTopic.UserID;
					Data.CreateTopic(TopicBLL);

					return RedirectToAction("Index");
				}

				else return PartialView("NewTopic");
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return PartialView("NewTopic");
			}
		}

		/// <summary>
		/// Вывод темы с сообщениями
		/// </summary>
		/// <param name="TopicID"></param>
		public ActionResult Topic(int TopicID)
		{
			try
			{
				List<MessagesViewModel> messages = new List<MessagesViewModel>();
				var TopicBLL = Data.GetTopicByID(TopicID);

				var MessagesBLL = Data.GetMessages(TopicBLL.TopicID);

				ViewBag.SectionID = TopicBLL.SectionID;
				ViewBag.TopicID = TopicBLL.TopicID;
                ViewBag.TopicName = TopicBLL.TopicName;
				ViewBag.TopicText = TopicBLL.TopicText;
				ViewBag.AuthorName = TopicBLL.Name;
				ViewBag.CreateDate = TopicBLL.CreateDate;

				foreach (var m in MessagesBLL)
				{
					MessagesViewModel message = new MessagesViewModel();
					message.MessageID = m.MessageID;
					message.Name = m.Name;
					message.SendDate = m.SendDate;
					message.Text = m.Text;
					message.StatusID = m.StatusID;
					messages.Add(message);
				}
				return View(messages);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View(TopicID);
			}
		}

		/// <summary>
		/// Создание нового сообщения
		/// </summary>
		/// <param name="TopicID"></param>
		public ActionResult NewMessage(int TopicID)
		{
			try
			{
				MessagesViewModel newMessage = new MessagesViewModel();
				ViewBag.TopicID = TopicID;
				if (User.IsInRole("Administrator")||User.IsInRole("Ban")||User.IsInRole("User"))
				{
					var curentUser = Data.GetCurentUser(User.Identity.Name);
					ViewBag.Avatar = curentUser.Avatar;
					ViewBag.Name = curentUser.Name;
					ViewBag.UserID = curentUser.UserID;
				}				
				return PartialView(newMessage);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View(TopicID);
			}			
		}

		/// <summary>
		/// Приём данных о новом сообщении
		/// </summary>
		/// <param name="newMessage"></param>
		[HttpPost]
		public ActionResult NewMessage(MessagesViewModel newMessage)
		{
			try
			{
				if (ModelState.IsValid)
				{

					MessagesDTO MessageBLL = new MessagesDTO();
					MessageBLL.TopicID = newMessage.TopicID;
					MessageBLL.Text = newMessage.Text;
					MessageBLL.UserID = newMessage.UserID;
					Data.CreateMessage(MessageBLL);

					return RedirectToAction("Topic", new { TopicID = newMessage.TopicID });
				}

				else return RedirectToAction("Topic", new { TopicID = newMessage.TopicID });
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return RedirectToAction("Topic", new { TopicID = newMessage.TopicID });
			}
		}

		/// <summary>
		/// Список пользователей
		/// </summary>
		/// <param name=""></param>
		public ActionResult UsersList()
		{
			try
			{
				List<UsersViewModel> userList = new List<UsersViewModel>();
				var UserBLL = Data.GetUsers();

				foreach (var u in UserBLL)
				{
					UsersViewModel user = new UsersViewModel();
					if (u.UserID != 1)
					{
						user.UserID = u.UserID;
						user.Login = u.Login;
						user.Name = u.Name;
						user.Avatar = u.Avatar;
						user.RegistrationDate = u.RegistrationDate;
						user.TypeID = u.TypeID;
						user.UserType = u.UserType;

						userList.Add(user);
					}
				}
				return View(userList);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return RedirectToAction("UsersList");
			}
		}

		/// <summary>
		/// Регистрация
		/// </summary>
		/// <param name=""></param>
		public ActionResult Registration()
		{
			try
			{
				return View();
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View();
			}
		}

		/// <summary>
		/// Приём данных со страницы регистрации
		/// </summary>
		/// <param name="user"></param>
		[HttpPost]
		public ActionResult Registration(UsersViewModel user)
		{
			try
			{
				if ((ModelState.IsValid) && (user.Password == user.ConfirmPassword))
				{

					UsersDTO UserBLL = new UsersDTO();
					UserBLL.Name = user.Name;
					UserBLL.Login = user.Login;
					UserBLL.Password = user.Password;
					UserBLL.Avatar = user.Avatar;
					Data.Registration(UserBLL);

					return RedirectToAction("Index");
				}
				if (user.Password != user.ConfirmPassword)
				{
					ModelState.AddModelError("WrongConfirmPassword", "Пароли на совпадают.");
					return View(user);
				}
                else return View(user);
			}
			catch (ValidationException ex)
			{
				ModelState.AddModelError("DalError", ex.Message);
				return View(user);
			}
		}
	}
}