using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
	public class TopicsDTO
	{
		public int TopicID { get; set; }
		public int SectionID { get; set; }
		public string TopicName { get; set; }
		public string TopicText { get; set; }
		public string Name { get; set; }
		public DateTime CreateDate { get; set; }
		public int MessageCount { get; set; }
		public int UserID { get; set; }

		public TopicsDTO()
		{
			TopicID = 0;
			SectionID = 0;
			TopicName = null;
			TopicText = null;
			Name = null;
			CreateDate = DateTime.MinValue;
			MessageCount = 0;
			UserID = 0;
		}
	}
}
