using Microsoft.EntityFrameworkCore;
using Wonderbox.Exam.Data.Context;

namespace Wonderbox.Exam.Data.SqlServer
{
    public static class SchoolDbContextFactory
    {
        public static SchoolContext FromConnectionString(string connectionString)
            => new SchoolContext(new DbContextOptionsBuilder<SchoolContext>()
                .UseSqlServer(connectionString), PersonEntityConfiguration.FromModelBuilderHook);
    }
}
