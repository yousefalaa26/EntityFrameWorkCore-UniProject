﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}
