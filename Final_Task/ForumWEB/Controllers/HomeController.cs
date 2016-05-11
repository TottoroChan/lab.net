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

	namespace ForumWEB.Controllers
	{

		public class HomeController : Controller
		{
			ForumBLL Data = new ForumBLL();
			// GET: Home
			
			/// <summary>
			/// Главная страница, создание тем
			/// </summary>
			/// <param name="SectionID"></param>
			/// <param name="SectionName"></param>
			public ActionResult Index()
			{
				try
				{
					var SectionsBLL = Data.GetSections();

					int length = SectionsBLL.Count();
					ViewBag.SectionID = new int[length];
					ViewBag.SectionName = new string[length];

					for (int i = 0; i < length; i++)
					{
						ViewBag.SectionID[i] = SectionsBLL.ElementAt(i).SectionID;
						ViewBag.SectionName[i] = SectionsBLL.ElementAt(i).SectionName;
					}

					if (User.Identity.Name != "")
					{
						var curentUser = Data.GetCurentUser(User.Identity.Name);
						ViewBag.Avatar = curentUser.Avatar;
						ViewBag.Name = curentUser.Name;
						ViewBag.UserID = curentUser.UserID;
					}
					return View();
				}
				catch (ValidationException ex)
				{
					return Content(ex.Message);
				}
			}

			/// <summary>
			/// Приём данных о новой теме
			/// </summary>
			/// <param name="newTopic"></param>
			[HttpPost]
			public ActionResult Index(TopicsViewModel newTopic)
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
					else

					{
						var SectionsBLL = Data.GetSections();

						int length = SectionsBLL.Count();
						ViewBag.SectionID = new int[length];
						ViewBag.SectionName = new string[length];

						for (int i = 0; i < length; i++)
						{
							ViewBag.SectionID[i] = SectionsBLL.ElementAt(i).SectionID;
							ViewBag.SectionName[i] = SectionsBLL.ElementAt(i).SectionName;
						}
						if (User.Identity.Name != "")
						{
							var curentUser = Data.GetCurentUser(User.Identity.Name);
							ViewBag.Avatar = curentUser.Avatar;
							ViewBag.Name = curentUser.Name;
							ViewBag.UserID = curentUser.UserID;
						}
						ViewBag.TopicName = newTopic.TopicName;
						ViewBag.TopicText = newTopic.TopicText;

						return View();
					}
				}
				catch (ValidationException ex)
				{
					ModelState.AddModelError("DalError", ex.Message);
					return View(newTopic);
				}
			}

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

					foreach (var s in SectionsBLL)
					{
						var TopicsBLL = Data.GetTopics(s.SectionID);
						if (TopicsBLL.Count() == 0)
						{
							TopicsViewModel topic = new TopicsViewModel();
							topic.SectionName = s.SectionName;
							topic.EmptySection = "В разделе ещё нет тем";
							topics.Add(topic);
						}
						else
						{
							foreach (var t in TopicsBLL)
							{
								TopicsViewModel topic = new TopicsViewModel();
								topic.SectionName = s.SectionName;
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
					return PartialView(topics);
				}
				catch (ValidationException ex)
				{
					return Content(ex.Message);
				}
			}

			/// <summary>
			/// Вывод сообщений в теме
			/// </summary>
			/// <param name="TopicID"></param>
			public ActionResult MessagesList(int TopicID)
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
					ViewBag.Avatar = TopicBLL.Avatar;

					foreach (var m in MessagesBLL)
					{
						MessagesViewModel message = new MessagesViewModel();
						message.MessageID = m.MessageID;
						message.Name = m.Name;
						message.SendDate = m.SendDate;
						message.Text = m.Text;
						message.StatusID = m.StatusID;
						message.Avatar = m.Avatar;
						messages.Add(message);
					}
					return PartialView(messages);
				}
				catch (ValidationException ex)
				{
					return Content(ex.Message);
				}
			}

			/// <summary>
			/// Создание нового сообщения
			/// </summary>
			/// <param name="TopicID"></param>
			public ActionResult Topic(int TopicID)
			{
				try
				{
					ViewBag.TopicID = TopicID;
					ViewBag.TopicName = Data.GetTopicByID(TopicID).TopicName;
					if (User.Identity.Name != "")
					{
						var curentUser = Data.GetCurentUser(User.Identity.Name);
						ViewBag.Avatar = curentUser.Avatar;
						ViewBag.Name = curentUser.Name;
						ViewBag.UserID = curentUser.UserID;
					}
					return View();
				}
				catch (ValidationException ex)
				{
					return Content(ex.Message);
				}
			}

			/// <summary>
			/// Приём данных о новом сообщении
			/// </summary>
			/// <param name="newMessage"></param>
			[HttpPost]
			public ActionResult Topic(MessagesViewModel newMessage)
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
					else
					{
						if (User.Identity.Name != "")
						{
							var curentUser = Data.GetCurentUser(User.Identity.Name);
							ViewBag.Avatar = curentUser.Avatar;
							ViewBag.Name = curentUser.Name;
							ViewBag.UserID = curentUser.UserID;
						}
						ViewBag.Text = newMessage.Text;
						ViewBag.TopicID = newMessage.TopicID;						
						return View();
					}
				}
				catch (ValidationException ex)
				{
					ModelState.AddModelError("DalError", ex.Message);
					return View(newMessage);
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
					return Content(ex.Message);
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
					return Content(ex.Message);
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
}
