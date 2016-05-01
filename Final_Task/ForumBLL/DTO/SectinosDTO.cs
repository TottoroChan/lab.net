using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
	public class SectionsDTO
	{
		public int SectionID { get; set; }
		public string SectionName { get; set; }

		public SectionsDTO()
		{
			SectionID = 0;
			SectionName = null;
		}
    }
}
