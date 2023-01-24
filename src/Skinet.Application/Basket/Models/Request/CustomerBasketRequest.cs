using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Basket.Models.Request
{
    public class CustomerBasketRequest
    {
        public CustomerBasketRequest(string id, List<BasketItemRequest> items)
        {
            Id = id;
            Items = items;
        }

        public string Id { get; private set; }
        public List<BasketItemRequest> Items { get; set; } 
    }
}
