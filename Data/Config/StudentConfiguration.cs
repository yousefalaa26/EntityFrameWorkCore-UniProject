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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();
            
            builder.Property(x => x.LName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.ToTable("Students");

           
        }

    }
}
