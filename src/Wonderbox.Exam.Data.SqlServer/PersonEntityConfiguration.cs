using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wonderbox.Exam.Data.Models;

namespace Wonderbox.Exam.Data.SqlServer
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public static readonly Action<ModelBuilder> FromModelBuilderHook = builder => builder.ApplyConfiguration(new PersonEntityConfiguration());

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.Property(p => p.FirstMidName)
                .HasColumnName("FirstName");

            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<Instructor>("Instructor")
                .HasValue<Student>("Student");
        }
    }
}
