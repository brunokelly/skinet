using Skinet.Domain.Orders;
using Skinet.Domain.Orders.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data.Context;
using Skinet.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Infra.Data.Repository.Orders
{
    public class DeliveryMethodRepository : BaseRepository<DeliveryMethod>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(IUnitOfWork unitOfWork, INotification notification) : base(unitOfWork, notification)
        {
        }
    }
}
