using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Entities
{
	public class Sections
	{
		public int SectionID { get; set; }
		public string SectionName { get; set; }

		public Sections()
		{
			SectionID = 0;
			SectionName = null;
		}
    }
}
