using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StoreAPI.Areas.Identity.Data;
using StoreLibrary.DbModels;
using StoreLibrary.EfCoreMethods;



namespace StoreAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Read Connection Strings from appsettings.json
			var identityConn = builder.Configuration.GetConnectionString("IdentityContextConnection")
							   ?? throw new InvalidOperationException("Missing Identity connection string.");

			// Get the connection string from appsettings.json
			var storedbConn = builder.Configuration.GetConnectionString("StoreDBConnection") 
								?? throw new InvalidOperationException("Missing StoreDB connection string.");

			// Add DbContext to the service container
			//Add DB contexts to services
			builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(storedbConn));
			builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(identityConn));
			
			builder.Services.AddScoped<PurchaseMethods>();

			builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<IdentityContext>()
				.AddDefaultTokenProviders();

			// CORS
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
					policy.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader());
			});

			// JWT
			var jwtSettings = builder.Configuration.GetSection("JwtSettings");
			var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
			
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = jwtSettings["Issuer"],
					ValidAudience = jwtSettings["Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(key)
				};
			});

			builder.Services.AddAuthorization();
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			app.UseMiddleware<ExceptionMiddleware>();

			app.UseCors("AllowAll");

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
