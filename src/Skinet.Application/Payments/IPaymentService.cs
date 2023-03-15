using Skinet.Application.Basket.Models.Response;
using Skinet.Domain.Basket;

namespace Skinet.Application.Payments
{
    public interface IPaymentService
    {
        Task<CustomerBasketResponse> CreateOrUpdatePaymentIntent(string basketId);
    }
}
