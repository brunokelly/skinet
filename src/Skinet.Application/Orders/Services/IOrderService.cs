using Skinet.Application.Orders.Models.Requests;
using Skinet.Application.Orders.Models.Response;

namespace Skinet.Application.Orders.Services
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(string email, OrderRequest orderRequest);
        Task<OrderListResponse> GetOrdersForUserAsync(string buyerEmail);
        Task<OrderResponse> GetOrderByIdAsync(int id, string buyerEmail);
        Task<DeliveryMethodListReponse> GetDeliveryMethodsAsync();
    }
}
