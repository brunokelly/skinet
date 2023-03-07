namespace Skinet.Domain.Basket
{
    public class CustomerBasket
    {
        protected CustomerBasket()
        {
        }

        public CustomerBasket(string? id, List<BasketItem>? items = null, string? paymentIntentId = null)
        {
            Id = id;
            Items = items;
            PaymentIntentId = paymentIntentId;
        }

        public string Id { get; private set; }
        public List<BasketItem> Items { get; set; } = new();
        public string? PaymentIntentId { get; private set; }
    }
}
