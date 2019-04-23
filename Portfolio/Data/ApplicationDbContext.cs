using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Portfolio.Models.PortfolioModel> PortfolioModel { get; set; }
		public DbSet<Portfolio.Models.BlogModel> BlogModel { get; set; }
		public DbSet<Portfolio.Models.EmploymentModel> EmploymentModel { get; set; }
		public DbSet<Portfolio.Models.EducationModel> EducationModel { get; set; }
	}
}
