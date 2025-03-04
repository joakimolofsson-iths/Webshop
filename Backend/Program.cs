
namespace Backend
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();

			// Add CORS policy to allow frontend access
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowFrontend", policy =>
					policy.WithOrigins("https://localhost:5002") // Adjust this to your frontend URL
						  .AllowAnyMethod()
						  .AllowAnyHeader());
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();

			// Enable CORS
			app.UseCors("AllowFrontend");

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
