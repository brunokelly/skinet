using Skinet.Domain.Common;
namespace Skinet.Domain.Orders
{
    public class OrderItem : Entity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrdered ItemOrdered { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
