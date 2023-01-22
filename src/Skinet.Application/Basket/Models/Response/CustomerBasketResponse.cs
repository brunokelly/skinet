using Skinet.Application.Common;
using Skinet.Domain.Basket;

namespace Skinet.Application.Basket.Models.Response
{
    public class CustomerBasketResponse : BaseResponse
    {
        public CustomerBasket Items { get; set; }

        public static implicit operator CustomerBasketResponse(CustomerBasket customerBasket)
        {
            if(customerBasket == null) return new CustomerBasketResponse();

            return new CustomerBasketResponse()
            {
                Items = customerBasket
            };
        }
    }
}
