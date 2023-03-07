using Skinet.Domain;
using Skinet.Domain.Common;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Repository;
using System.Collections;

namespace Skinet.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public StoreContext Context { get;  set; }
        //private Hashtable _repositories;

        public UnitOfWork(StoreContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        //public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        //{
        //    if (_repositories == null) { _repositories = new Hashtable(); }

        //    var type = typeof(TEntity).Name;
        //    if(!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(BaseRepository<>);
        //        var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

        //        _repositories.Add(type, repository);
        //    }

        //    return (IBaseRepository<TEntity>)_repositories[type];
        //}

        public void SaveChanges()
        {
           Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
