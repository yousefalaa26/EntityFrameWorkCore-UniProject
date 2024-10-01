using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InitialMigration123.Entities;

namespace InitialMigration.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.CourseName)
                .HasColumnType("VARCHAR").HasMaxLength(225).IsRequired();

            builder.Property(x => x.Price).HasPrecision(15, 2);

            builder.ToTable("Courses");

            builder.HasData(LoadCourse());
        }

        private static List<Course> LoadCourse()
        {
            //INSERT INTO Courses(Id, CourseName, Price) VALUES(1, 'Mathematics', 1000.00);
            //INSERT INTO Courses(Id, CourseName, Price) VALUES(2, 'Physics', 2000.00);
            //INSERT INTO Courses(Id, CourseName, Price) VALUES(3, 'Chemistry', 1500.00);
            //INSERT INTO Courses(Id, CourseName, Price) VALUES(4, 'Biology', 1200.00);
            //INSERT INTO Courses(Id, CourseName, Price) VALUES(5, 'Computer Science', 3000.00);
            return new List<Course>
            {
                new Course{ Id= 1, CourseName= "Mathematics", Price= 1000m},
                new Course{ Id= 2, CourseName= "Physics", Price= 2000m},
                new Course{ Id= 3, CourseName= "Chemistry", Price= 1500m},
                new Course{ Id= 4, CourseName= "Biology", Price= 1200m},
                new Course{ Id= 5, CourseName= "CS-50", Price= 3000m}
            };
        }
    }
}
