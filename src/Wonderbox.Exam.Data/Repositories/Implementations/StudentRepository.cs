using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Data.Repositories.Interfaces;
using Wonderbox.Exam.Data.Specs;
using Wonderbox.Exam.Infrastructure;

namespace Wonderbox.Exam.Data.Repositories.Implementations
{
    public class StudentDbRepository : BaseDbRepository<Student>, IStudentRepository
    {
        public StudentDbRepository(DbContext dbContext) : base(dbContext)
        {
        }

        Task<IPaginatedList<Student>> IStudentRepository.GetAsync(string searchText,
            SortOptions sortOptions,
            int pageNumber,
            int? pageSize)
        {
            var searching = new StudentSearchTextSpecification(searchText);
            var sorting = OrderSpecification<Student>.FromPropertyName(sortOptions.SortField, sortOptions.SortDirection);

            return ((IRepository<Student>) this)
                .RunSpecs(searching, sorting)
                .ToPaginationListAsync(pageNumber, pageSize ?? Constants.DEFAULT_PAGE_SIZE);
        }
    }
}
