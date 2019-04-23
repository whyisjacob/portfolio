using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	public class EducationModel
	{
		[Key]
		public int InstitutionId { get; set; }
		public string Institution { get; set; }
		public string InstitutionDescription { get; set; }
		public string InstitutionContributions { get; set; }
		public DateTime InstitutionStart { get; set; }
		public DateTime InstitutionEnd { get; set; }
		public string InstitutionPhoto { get; set; }
		public string InstitutionUrl { get; set; }
		public string InstitutionUrl2 { get; set;}
		public string InstitutionAccolade { get; set; }

	}
}
