using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Common;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specifications;
using Skinet.Infra.Data;
using Skinet.Infra.Data.Context;

namespace Skinet.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly StoreContext _context;
        private readonly INotification _notification;

        public BaseRepository(StoreContext context, INotification notification)
        {
            _context = context;
            _notification = notification;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            var result = await ApplySpecification(spec).FirstOrDefaultAsync();

            if (result == null)
                _notification.AddNotification("Product", "No product found", NotificationModel.ENotificationType.NotFound);

            return result;
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
