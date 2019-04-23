using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	public class EmploymentModel
	{
		[Key]
		public int EmploymentId { get; set; }
		public string Employment { get; set; }
		public string EmploymentDescription { get; set; }
		public string EmploymentContributions { get; set; }
		public DateTime EmploymentStart { get; set; }
		public DateTime EmploymentEnd { get; set; }
		public string EmploymentPhoto { get; set;}
		public string EmploymentUrl { get; set; }
		public string EmploymentAccolade { get; set; }

	}
}
