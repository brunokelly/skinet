using Skinet.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Services
{
    public interface IDeliveryMethodService
    {
        Task<DeliveryMethod> GetDeliveryMethodByIdAsync(int id);
        Task<List<DeliveryMethod>> ListAllAsync();
    }
}
