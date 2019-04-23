using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
	public class BlogModel
	{
		[Key]
		public int PostId { get; set; }
		public string PostName { get; set; }
		public DateTime PostDate { get; set; }
		public string PostDesc { get; set; }
		public string Post { get; set; }
		public string PostImg { get; set; }
		public string PostUrl1 { get; set;}

	}
}
