using DemoProject.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data
{

	public class ApplicationDbContext : DbContext
	{
		public DbSet<Setting> Settings { get; set; } // DbSet for entity

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	}
}
