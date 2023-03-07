using Skinet.Domain.Orders;

namespace Skinet.Application.Orders.Models.Requests
{
    public class OrderRequest
    {
        public string BuyerEmail { get; set; }
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public OrderAddressRequest ShipToAddress { get; set; }
    }
}
