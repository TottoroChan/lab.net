using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForumWEB.Models

{
	public class MessagesViewModel
	{
		public int MessageID { get; set; }
		public int TopicID { get; set; }
		public DateTime SendDate { get; set; }

		[Required(ErrorMessage = "Вы не ввели текст сообщения")]
		public string Text { get; set; }
		public string Name { get; set; }
		public int StatusID { get; set; }
		public string Avatar { get; set; }
		public int UserID { get; set; }
	}
}
