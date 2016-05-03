using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ForumWEB.Models;
using BLL.Validation;

namespace ForumWEB.Controllers
{
    public class HomeController : Controller
    {
		ForumBLL Data = new ForumBLL();
        // GET: Home
        public ActionResult Index()
        {
			try
			{
				List<TopicsViewModel> topics = new List<TopicsViewModel>();
				var SectionsBLL = Data.GetSections();
				
				foreach (var s in SectionsBLL)
				{
					var TopicsBLL = Data.GetTopics(s.SectionID);
					foreach (var t in TopicsBLL)
					{
						TopicsViewModel topic = new TopicsViewModel();
						topic.TopicID = t.TopicID;
						topic.SectionName = s.SectionName;
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

				return View(topics);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

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
					message.Name = m.Name;
					message.SendDate = m.SendDate;
					message.Text = m.Text;
					messages.Add(message);
				}
				return View(messages);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}

		public ActionResult UserList()
		{
			try
			{
				List<UsersViewModel> userList = new List<UsersViewModel>();
				var UserBLL = Data.GetUsers();

				foreach (var u in UserBLL)
				{
					UsersViewModel user = new UsersViewModel();
					user.Login = u.Login;
					user.Name = u.Name;
					user.RegistrationDate = u.RegistrationDate;
					user.TypeID = u.TypeID;
					user.UserType = u.UserType;

					userList.Add(user);
				}
				return View(userList);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}
	}
}