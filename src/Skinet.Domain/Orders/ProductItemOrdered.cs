namespace Skinet.Domain.Orders
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemOrderedId, string productName, string pictureUrl)
        {
            ProductItemOrderedId = productItemOrderedId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemOrderedId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
    }
}
