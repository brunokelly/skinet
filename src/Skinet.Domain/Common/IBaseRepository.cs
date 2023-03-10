using Skinet.Domain.Common;
using Skinet.Domain.Specifications;

namespace Skinet.Domain
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(object id);
        Task<List<T>> GetListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();

    }
}
