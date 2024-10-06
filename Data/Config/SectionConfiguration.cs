using InitialMigration123.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialMigration123.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.SectionName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Course).WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId).IsRequired();

            builder.HasOne(x=>x.Instructor).WithMany(x => x.Sections)
                .HasForeignKey(x => x.InstructorId).IsRequired(false);

            builder.OwnsOne(x => x.TimeSlot, ts =>
            {
                ts.Property(x=>x.StartTime).HasColumnType("time").HasColumnName("StartTime");
                ts.Property(x=>x.EndTime).HasColumnType("time").HasColumnName("EndTime");
            });

            builder.HasOne(x => x.Schedule).WithMany(x => x.Sections)
                .HasForeignKey(x =>x.ScheduleId).IsRequired();

            builder.HasMany(x => x.Students).WithMany(x => x.Sections)
               .UsingEntity<Enrollment>();

            builder.ToTable("Sections");
        }
    }
}
