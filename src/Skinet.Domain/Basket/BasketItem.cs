namespace Skinet.Domain.Basket
{
    public class BasketItem
    {
        public BasketItem(int id, string productName, decimal price, int quantity, string pictureUrl, string brand)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            PictureUrl = pictureUrl;
            Brand = brand;
        }

        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string PictureUrl { get;  private set; }
        public string Brand { get; private set; }

        public void UpdatePriceByProduct(ProductModel.Product product)
        {
            if (Price != product.Price)  Price = product.Price;
        }
    }
}
