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

        }
    }
}
