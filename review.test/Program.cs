using Microsoft.EntityFrameworkCore;
using review.test.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IServiceCollection services = builder.Services;

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
services.AddDbContext<TestDatabase>(opt => opt.UseNpgsql(connectionString));

services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

ApplyMigrations(app.Services);

static void ApplyMigrations(IServiceProvider serviceProvider)
{
	using IServiceScope scope = serviceProvider.CreateScope();
	using TestDatabase db = scope.ServiceProvider.GetService<TestDatabase>();
	db.Database.Migrate();
}