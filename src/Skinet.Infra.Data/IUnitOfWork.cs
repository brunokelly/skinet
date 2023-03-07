using Skinet.Domain;
using Skinet.Domain.Common;
using Skinet.Infra.Data.Context;

namespace Skinet.Infra.Data
{
    public interface IUnitOfWork : IDisposable
    {
        StoreContext Context { get; }
        //IBaseRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
