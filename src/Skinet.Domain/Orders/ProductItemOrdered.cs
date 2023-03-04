namespace Skinet.Domain.Orders
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
    }
}
