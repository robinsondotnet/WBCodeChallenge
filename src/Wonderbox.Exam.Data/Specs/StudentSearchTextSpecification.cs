using System.Linq;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Infrastructure;

namespace Wonderbox.Exam.Data.Specs
{
    public class StudentSearchTextSpecification : ISpecification<Student>
    {
        private readonly string _searchText;

        public StudentSearchTextSpecification(string searchText)
        {
            _searchText = searchText;
        }

        IQueryable<Student> ISpecification<Student>.Execute(IQueryable<Student> projection) => string.IsNullOrWhiteSpace(_searchText)
            ? projection
            : projection.Where(student => student.LastName.ToLower().Contains(_searchText.ToLower())
                               || student.FirstMidName.ToLower().Contains(_searchText.ToLower()));
    }
}
