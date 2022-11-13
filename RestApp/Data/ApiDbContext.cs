using System;
using Microsoft.EntityFrameworkCore;
using RestApp.Models;

namespace RestApp.Data
{
	public class ApiDbContext : DbContext
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
		{
		}
		public DbSet<Song> songs { get; set; }
	}
}

