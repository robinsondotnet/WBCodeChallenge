using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wonderbox.Exam.Data.Models;

namespace Wonderbox.Exam.Data.Context
{
    public class SchoolContext : DbContext
    {
        private readonly IEnumerable<Action<ModelBuilder>> _modelBuilderHooks;

        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Person> Persons { get; set; }

        public SchoolContext(DbContextOptionsBuilder<SchoolContext> dbContextBuilder,
            params Action<ModelBuilder>[] modelBuilderHooks) : base(dbContextBuilder.Options)
        {
            _modelBuilderHooks = modelBuilderHooks;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityTypeConfiguration in _modelBuilderHooks)
                entityTypeConfiguration(modelBuilder);
        }
    }
}
