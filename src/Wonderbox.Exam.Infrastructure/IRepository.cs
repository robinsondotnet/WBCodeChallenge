using System;
using System.Linq;
using System.Threading.Tasks;

namespace Wonderbox.Exam.Infrastructure
{
    public interface IRepository<TModel> : IDisposable
    {
        Task<TModel> GetAsync(int id);

        IQueryable<TModel> RunSpecs(params ISpecification<TModel>[] specs);

        Task AddAsync(TModel model);

        Task UpdateAsync(TModel model);

        Task DeleteAsync(TModel model);
    }
}
