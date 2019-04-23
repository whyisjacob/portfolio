using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	public class PortfolioModel
	{
		[Key]
		public int ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ProjectDesc { get; set; }
		public string ProjectTech { get; set; }
		public string ProjectRole { get; set; }
		public DateTime ProjectDate { get; set; }
		public DateTime DataEdited { get; set; }
		public string ProjectAccolade { get; set; }
		public string ProjectImage { get; set;}
		public string ProjectUrl1 { get; set; }
		public string ProjectUrl2 { get; set; }
	}
}
