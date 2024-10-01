using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InitialMigration123.Entities;

namespace InitialMigration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR").HasMaxLength(225).IsRequired();

            builder.HasOne(x => x.Office).WithOne(x => x.Instructor)
                .HasForeignKey<Instructor>(x => x.OfficeId);

            builder.ToTable("Instructors");

            builder.HasData(LoadInstructor());
        }

        private static List<Instructor> LoadInstructor()
        {
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(1, 'Ahmed Abdullah', 1);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(2, 'Yasmeen Mohammed', 2);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(3, 'Khalid Hassan', 3);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(4, 'Nadia Ali', 4);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(5, 'Omar Ibrahim', 5);
            return new List<Instructor>
            {
                new Instructor { Id = 1,Name = "Ahmed Abdullah", OfficeId= 1},
                new Instructor { Id = 2,Name = "Yasmeen Mohammed", OfficeId= 2},
                new Instructor { Id = 3,Name = "Khalid Hassan", OfficeId = 3},
                new Instructor { Id = 4,Name = "Nadia Ali", OfficeId = 4},
                new Instructor { Id = 5,Name = "Omar Ibrahim", OfficeId= 5 }
            };
        }
    }
}
