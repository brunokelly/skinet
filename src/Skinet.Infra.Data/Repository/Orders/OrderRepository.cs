using Skinet.Domain.Orders;
using Skinet.Domain.Orders.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data;
using Skinet.Infra.Data.Context;

namespace Skinet.Infra.Repository.Orders
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork unitOfWork, INotification notification) : base(unitOfWork, notification)
        {
        }
    }
}
