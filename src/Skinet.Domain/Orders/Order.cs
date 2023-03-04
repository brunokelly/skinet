using Skinet.Domain.Common;
using Skinet.Domain.Identity;

namespace Skinet.Domain.Orders
{
    public class Order : Entity
    {
        protected Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress,
            DeliveryMethod deliveryMethod, decimal subtotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
        public Address ShipToAddress { get; private set; }
        public DeliveryMethod DeliveryMethod { get; private set; }
        public IReadOnlyList<OrderItem> OrderItems { get; private set; }
        public decimal Subtotal { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; private set; }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}
