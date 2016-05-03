using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumWEB.Models
{
	public class MessagesViewModel
	{
		public int MessageID { get; set; }
		public int TopicID { get; set; }
		/*public string TopicName { get; set; }
		public string TopicText { get; set; }
		public string AuthorName { get; set; }
		public DateTime CreateDate { get; set; }*/
		public DateTime SendDate { get; set; }
		public string Text { get; set; }
		public string Name { get; set; }
		public int StatusID { get; set; }
	}
}
