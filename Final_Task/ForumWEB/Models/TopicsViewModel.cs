using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ForumWEB.Models
{
	public class TopicsViewModel
	{
		public int TopicID { get; set; }
		public string SectionName { get; set; }

		[Required(ErrorMessage = "Вы не ввели название темы")]
		public string TopicName { get; set; }

		[Required(ErrorMessage = "Вы не ввели текст темы")]
		public string TopicText { get; set; }
		public int SectionID { get; set; }
		public int UserID { get; set; }
		public string AuthorName { get; set; }
		public DateTime CreateDate { get; set; }
		public int MessageCount { get; set; }
		public string Name { get; set; }
		public DateTime SendDate { get; set; }
		public string Avatar { get; set; }
		public string EmptySection { get; set; }
	}
}
