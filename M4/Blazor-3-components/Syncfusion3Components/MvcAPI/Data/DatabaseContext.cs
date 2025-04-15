using Microsoft.EntityFrameworkCore;
using MvcAPI.Models;

namespace MvcAPI.Data
{
	public class DatabaseContext
	{
		public class AppDbContext: DbContext
		{
			public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

			public DbSet<Tarefa> Tarefas { get; set; }
		}
	}
}
