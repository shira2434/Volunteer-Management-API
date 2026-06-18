using Microsoft.EntityFrameworkCore;
using Volunteer.Entities;
using Volunteer.Repository;
using Volunteer.Service;

namespace Volunteer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite("Data Source=volunteers.db"));

            builder.Services.AddScoped<IVolunteerRepository, VolunteerRepository>();
            builder.Services.AddScoped<VolunteerService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();
            }

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
