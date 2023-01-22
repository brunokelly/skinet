using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Domain.Basket
{
    public class CustomerBasket
    {
        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
        public List<BasketItem> Items { get; set; } = new();
    }
}
