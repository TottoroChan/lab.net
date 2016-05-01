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
				List<TopicsViewModel> Topics = new List<TopicsViewModel>();
				var SectionsBLL = Data.GetSections();
				
				foreach (var s in SectionsBLL)
				{
					var TopicsBLL = Data.GetTopics(s.SectionID);
					foreach (var t in TopicsBLL)
					{
						TopicsViewModel topic = new TopicsViewModel();
						topic.SectionName = s.SectionName;
						topic.TopicName = t.TopicName;
						topic.AuthorName = t.Name;
						topic.CreateDate = t.CreateDate;
						topic.MessageCount = t.MessageCount;
						var u = Data.LastMessage(t.TopicID);
						topic.Name = u.Name;
						topic.SendDate = u.RegistrationDate;
						Topics.Add(topic);
					}
				}

				return View(Topics);
			}
			catch (ValidationException ex)
			{
				return Content(ex.Message);
			}
		}
    }
}