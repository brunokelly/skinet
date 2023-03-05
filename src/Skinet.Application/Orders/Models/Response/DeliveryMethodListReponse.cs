using Skinet.Application.Common;
using Skinet.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Models.Response
{
    public class DeliveryMethodListReponse : BaseResponse
    {
        public int Total { get; set; }
        public IEnumerable<DeliveryMethodResponse> Items { get; set; } = new List<DeliveryMethodResponse>();

        public static implicit operator DeliveryMethodListReponse(List<DeliveryMethod> deliveryMethods)
        {
            if (deliveryMethods is null) return new DeliveryMethodListReponse();

            return new DeliveryMethodListReponse
            {
                Items = deliveryMethods.Select(d => (DeliveryMethodResponse)d)
            };
        }
    }
}
