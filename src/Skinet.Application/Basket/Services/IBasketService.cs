using Skinet.Application.Basket.Models.Request;
using Skinet.Application.Basket.Models.Response;
using Skinet.Domain.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Basket.Services
{
    public interface IBasketService
    {
        Task<CustomerBasketResponse> GetBasketId(string id);
        Task<CustomerBasketResponse> UpdateBasket(CustomerBasketRequest customerBasket);
        Task<bool> DeleteBasket(string id);
    }
}
