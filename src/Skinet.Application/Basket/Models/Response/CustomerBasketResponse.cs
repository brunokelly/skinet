using Skinet.Application.Common;
using Skinet.Domain.Basket;

namespace Skinet.Application.Basket.Models.Response
{
    public class CustomerBasketResponse : BaseResponse
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }

        public static implicit operator CustomerBasketResponse(CustomerBasket customerBasket)
        {
            if(customerBasket == null) return new CustomerBasketResponse();

            return new CustomerBasketResponse()
            {
                Id = customerBasket.Id,
                Items = customerBasket.Items.Select(x => x).ToList()
            };
        }
    }
}
