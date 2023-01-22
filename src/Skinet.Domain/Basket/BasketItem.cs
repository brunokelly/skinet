namespace Skinet.Domain.Basket
{
    public class BasketItem
    {
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string PictureUrl { get;  private set; }
        public string Brand { get; private set; }
    }
}
