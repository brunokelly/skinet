using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Common;
using Skinet.Domain.Specifications;
using System.Data;

namespace Skinet.Infra.Data
{
    public class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
           
            return spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        }
    }
}
