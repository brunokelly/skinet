using Microsoft.EntityFrameworkCore;
using Skinet.Domain;
using Skinet.Domain.Common;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specifications;
using Skinet.Infra.Data;
using Skinet.Infra.Utils;

namespace Skinet.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotification _notification;

        public BaseRepository(IUnitOfWork unitOfWork, INotification notification)
        {
            _unitOfWork = unitOfWork;
            _notification = notification;
        }

        public virtual async Task<T?> GetByIdAsync(object id) => await _unitOfWork.Context.Set<T>().FindAsync(id);

        public virtual async Task<List<T>> GetListAllAsync() => await _unitOfWork.Context.Set<T>().ToListAsync();

        public virtual async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            var result = await ApplySpecification(spec).FirstOrDefaultAsync();
            if (result == null)
                _notification.AddNotification("Product", "No product found", NotificationModel.ENotificationType.NotFound);

            return result;
        }

        public virtual async Task<List<T>> ListAsync(ISpecification<T> spec) => await ApplySpecification(spec).ToListAsync();

        public virtual async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> spec) => SpecificationEvaluator<T>.GetQuery(_unitOfWork.Context.Set<T>().AsQueryable(), spec);

        public void Add(T entity) => _unitOfWork.Context.Set<T>().Add(entity);

        public void Update(T entity)
        {
            _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) => _unitOfWork.Context.Set<T>().Remove(entity);

        public void SaveChanges() => _unitOfWork.SaveChanges();
    }
}
