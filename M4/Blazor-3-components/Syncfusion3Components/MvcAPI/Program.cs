using Microsoft.EntityFrameworkCore;
using MvcAPI.Data;
using static MvcAPI.Data.DatabaseContext;

namespace MvcAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

			builder.Services.AddDbContext<AppDbContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
