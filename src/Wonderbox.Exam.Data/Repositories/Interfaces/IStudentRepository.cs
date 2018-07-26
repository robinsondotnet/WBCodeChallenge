using System.Threading.Tasks;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Data.Specs;
using Wonderbox.Exam.Infrastructure;

namespace Wonderbox.Exam.Data.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IPaginatedList<Student>> GetAsync(string searchText,
            SortOptions sortOptions,
            int pageNumber,
            int? pageSize = null);
    }
}
