using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
	public class MessagesDTO
	{
		public int MessageID { get; set; }
		public int TopicID { get; set; }
		public DateTime SendDate { get; set; }
		public string Text { get; set; }
		public int StatusID { get; set; }
		public string Name { get; set; }
		public DateTime RegistrationDate { get; set; }
		public int UserID { get; set; }
		public string Avatar { get; set; }

		public MessagesDTO()
		{
			MessageID = 0;
			TopicID = 0;
			SendDate = DateTime.MinValue;
			Text = null;
			StatusID = 0;
			Name = null;
			RegistrationDate = DateTime.MinValue;
			UserID = 0;
			Avatar = null;
		}
	}
}
