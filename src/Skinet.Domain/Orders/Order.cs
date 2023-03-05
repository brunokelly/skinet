using Skinet.Domain.Common;

namespace Skinet.Domain.Orders
{
    public class Order : Entity
    {
        protected Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, OrderAddress shipToAddress,
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
        public OrderAddress ShipToAddress { get; private set; }
        public DeliveryMethod DeliveryMethod { get; private set; }
        public IReadOnlyList<OrderItem> OrderItems { get; private set; }
        public decimal Subtotal { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; private set; }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

        public void UpdateOrderAddress(OrderAddress orderAddress)
        {
            ShipToAddress = orderAddress ?? ShipToAddress;
        }

        public void UpdateDeliveryMethod(DeliveryMethod delivery)
        {
            DeliveryMethod = delivery ?? DeliveryMethod;
        }

        public void UpdateSubtotal(decimal subtotal)
        {
            Subtotal = subtotal;
        }

    }
}
