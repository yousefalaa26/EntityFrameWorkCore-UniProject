using InitialMigration123.Entities;
using InitialMigration123.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialMigration123.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Title).HasColumnType("VARCHAR")
            //    .HasMaxLength(50).IsRequired();

            builder.Property(x => x.Title)
                .HasConversion(
                x => x.ToString(),
                x=> (ScheduleEnum) Enum.Parse(typeof(ScheduleEnum), x)
                );

            builder.ToTable("Schedules");
        }

    }
}
