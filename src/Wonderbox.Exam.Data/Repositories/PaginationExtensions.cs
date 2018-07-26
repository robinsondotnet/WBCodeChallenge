using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Wonderbox.Exam.Data.Repositories
{
    public interface IPaginatedList<TModel>
    {
        int TotalItemsCount { get; }

        int CurrentPage { get; }

        int PageSize { get; }

        List<TModel> Value { get; set; }
    }

    public class PaginatedList<TModel> : IPaginatedList<TModel>
    {
        public int TotalItemsCount { get; }

        public int CurrentPage { get; }

        public int PageSize { get; }

        public List<TModel> Value { get; set; }

        public PaginatedList(List<TModel> value, int currentPage, int pageSize, int totalItemsCount)
        {
            Value = value;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
        }
    }

    public static class PaginationExtensions
    {
        public static async Task<IPaginatedList<TModel>> ToPaginationListAsync<TModel>(this IQueryable<TModel> projection, int currentPage, int pageSize)
        {
            var materializedList = await projection.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalItemsCount = projection.Count();

            return new PaginatedList<TModel>(materializedList, currentPage, pageSize, totalItemsCount);
        }
    }
}
