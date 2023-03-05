using Skinet.Application.Common;
using Skinet.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Models.Response
{
    public class DeliveryMethodResponse : BaseResponse
    {
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public static implicit operator DeliveryMethodResponse(DeliveryMethod deliveryMethod)
        {
            if (deliveryMethod is null) return new DeliveryMethodResponse();

            return new DeliveryMethodResponse
            {
                DeliveryTime = deliveryMethod.DeliveryTime,
                Description = deliveryMethod.Description,
                Price = deliveryMethod.Price,
                ShortName = deliveryMethod.ShortName,
            };

        }
    }
}
