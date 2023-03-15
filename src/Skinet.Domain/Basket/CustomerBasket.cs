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
        public int? DeliveryMethodId { get; private set; }
        public string ClientSecret { get; private set; }
        public string? PaymentIntentId { get; private set; }

        public void UpdatePaymentIntent(string paymentIntent, string clientSecret)
        {
            PaymentIntentId = paymentIntent;
            ClientSecret = clientSecret;
        }
    }
}
