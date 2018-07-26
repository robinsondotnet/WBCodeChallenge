using System.Linq;

namespace Wonderbox.Exam.Infrastructure
{
    public interface ISpecification<TModel>
    {
        IQueryable<TModel> Execute(IQueryable<TModel> projection);
    }
}
