using System.Linq;
using System.Linq.Dynamic.Core;
using Wonderbox.Exam.Infrastructure;

namespace Wonderbox.Exam.Data.Specs
{
    public class OrderSpecification<TModel> : ISpecification<TModel>
    {
        private readonly string _propName;
        private readonly string _orderDirection;

        private OrderSpecification(string propName, string orderDirection)
        {
            _propName = propName;
            _orderDirection = orderDirection;
        }

        public static OrderSpecification<TModel> FromPropertyName(string propName,
            string orderDirection = Constants.SORT_ASC)
            => new OrderSpecification<TModel>(propName, orderDirection);

        IQueryable<TModel> ISpecification<TModel>.Execute(IQueryable<TModel> projection)
            => !string.IsNullOrWhiteSpace(_propName)
                ? projection.OrderBy($"{_propName} {_orderDirection}")
                : projection;
    }
}
