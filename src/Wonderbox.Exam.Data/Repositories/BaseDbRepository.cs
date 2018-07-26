using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wonderbox.Exam.Infrastructure;

namespace Wonderbox.Exam.Data.Repositories
{
    public abstract class BaseDbRepository<TModel> : IRepository<TModel> where TModel : class, IModel
    {
        private readonly DbContext _dbContext;

        protected BaseDbRepository(DbContext dbContext) => _dbContext = dbContext;

        Task<TModel> IRepository<TModel>.GetAsync(int id)
            => _dbContext.Set<TModel>().FirstOrDefaultAsync(model => model.Id == id);

        IQueryable<TModel> IRepository<TModel>.RunSpecs(params ISpecification<TModel>[] specs)
        {
            var projection = _dbContext.Set<TModel>()
                .AsQueryable();

            foreach (var spec in specs)
                projection = spec.Execute(projection);

            return projection;
        }
            
        Task IRepository<TModel>.AddAsync(TModel model)
        {
            _dbContext.Set<TModel>().Add(model);
            return CommitChanges();
        }

        Task IRepository<TModel>.UpdateAsync(TModel model)
        {
            _dbContext.Set<TModel>().Update(model);
            return CommitChanges();
        }

        Task IRepository<TModel>.DeleteAsync(TModel model)
        {
            _dbContext.Set<TModel>().Remove(model);
            return CommitChanges();
        }

        private Task<int> CommitChanges() => _dbContext.SaveChangesAsync();

        void IDisposable.Dispose() => _dbContext?.Dispose();
    }
}
