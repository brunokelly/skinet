using Skinet.Domain.Common;

namespace Skinet.Domain.ProductModel
{
    public class Product : Entity
    {
        public Product()
        {

        }

        public Product(string name, string description, decimal price, 
            string pictureUrl, ProductType productType, ProductBrand productBrand)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            ProductBrand = productBrand;
            ProductType = productType;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUrl { get; private set; }
        public ProductType ProductType { get; private set; }
        public ProductBrand ProductBrand { get; private set; }

        public void AddProductType(ProductType productType)
        {
            ProductType = productType;
        }

        public void AddProductBrand(ProductBrand productBrand)
        {
            ProductBrand = productBrand;
        }
        public void ChangePicture(string pictureUrl)
        {
            PictureUrl = pictureUrl;
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
        }


    }
}