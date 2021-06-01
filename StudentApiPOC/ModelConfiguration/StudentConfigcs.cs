using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentApiPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiPOC.ModelConfiguration
{
    public class StudentConfigcs : IEntityTypeConfiguration<Student>
    {

        

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);

            builder.Property(student => student.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);

            builder.Property(student => student.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(student => student.Standerd)
            .IsRequired();

            builder.Property(student => student.DateOfBirth)
            .IsRequired();

            builder.Property(student => student.IsHnadicape);

            builder.Property(student => student.Gender)
            .IsRequired();

            builder.Property(student => student.CreatedBy)
            .IsRequired();

            builder.Property(student => student.ModifiedBy);

           builder.Property(student => student.CreatedDate)
            .IsRequired();
            
        }
    }
}
