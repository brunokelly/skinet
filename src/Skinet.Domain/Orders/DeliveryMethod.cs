using Skinet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Domain.Orders
{
    public class DeliveryMethod : Entity
    {
        public DeliveryMethod(string shortName, string deliveryTime, string description, decimal price)
        {
            ShortName = shortName;
            DeliveryTime = deliveryTime;
            Description = description;
            Price = price;
        }

        public string ShortName  { get; private set; }   
        public string DeliveryTime { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}
