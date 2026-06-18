using Microsoft.EntityFrameworkCore;
using Volunteer.Entities;

namespace Volunteer.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MyVolunteer> Volunteers => Set<MyVolunteer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyVolunteer>().HasData(
                new MyVolunteer { Id = 1, FirstName = "Yael", LastName = "Gutman" },
                new MyVolunteer { Id = 2, FirstName = "Yehudit", LastName = "Vaiss" }
            );
        }
    }
}
