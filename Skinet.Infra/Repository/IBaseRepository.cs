using Skinet.Domain.Common;
using Skinet.Domain.Specifications;

namespace Skinet.Infra
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

    }
}
