using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InitialMigration123.Entities;

namespace InitialMigration123.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet <Course> Courses { get; set; }
        public DbSet <Instructor> Instructors { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <Office> Offices { get; set; }
        public DbSet <Section> Sections { get; set; }
        public DbSet <Schedule> Schedules { get; set; }
        public DbSet <Enrollment> Enrollments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\youse\source\repos\InitialMigration123\AppSettings.json")
                .Build();
            var constr = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
