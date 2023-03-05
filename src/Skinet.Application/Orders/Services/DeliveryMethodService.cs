using Skinet.Application.Common;
using Skinet.Domain.Orders;
using Skinet.Domain.Orders.Repository;
using Skinet.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Services
{
    public class DeliveryMethodService : BaseService, IDeliveryMethodService
    {
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;

        public DeliveryMethodService(IDeliveryMethodRepository deliveryMethodRepository, INotification notification) : base(notification)
        {
            _deliveryMethodRepository = deliveryMethodRepository;
        }

        public async Task<DeliveryMethod> GetDeliveryMethodByIdAsync(int id)
        {
            return await _deliveryMethodRepository.GetByIdAsync(id);
        }

        public  async Task<List<DeliveryMethod>> ListAllAsync()
        {
            return await _deliveryMethodRepository.GetListAllAsync();
        }
    }
}
