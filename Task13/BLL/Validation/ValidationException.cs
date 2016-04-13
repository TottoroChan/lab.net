using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
	public class ValidationException : Exception
	{
		/// <summary>
		/// Валидация на уровне передачи данных и приёма из базы.
		/// </summary>
		public string Property { get; protected set; }
		public ValidationException(string message, string prop) : base(message)
		{
			Property = prop;
		}
	}
}
