using Skinet.Domain.Common;
using Skinet.Domain.Specifications;

namespace Skinet.Domain
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);

    }
}
