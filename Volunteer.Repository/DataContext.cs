using Microsoft.EntityFrameworkCore;
using Volunteer.Entities;

namespace Volunteer.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MyVolunteer> Volunteers => Set<MyVolunteer>();
        public DbSet<Role> Roles => Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Driver" },
                new Role { Id = 2, Name = "Medic" },
                new Role { Id = 3, Name = "Coordinator" }
            );

            modelBuilder.Entity<MyVolunteer>().HasData(
                new MyVolunteer { Id = 1, FirstName = "Yael", LastName = "Gutman", RoleId = 1 },
                new MyVolunteer { Id = 2, FirstName = "Yehudit", LastName = "Vaiss", RoleId = 2 }
            );
        }
    }
}
