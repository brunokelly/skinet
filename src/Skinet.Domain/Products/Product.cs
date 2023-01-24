using Skinet.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skinet.Domain.ProductModel
{
    public class Product : Entity
    {
        protected Product()
        {

        }

        protected Product(string name, string description, decimal price, 
            string pictureUrl, ProductType productType, ProductBrand productBrand)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            ProductBrand = productBrand;
            ProductType = productType;
        }

        public Product(string name, string description, decimal price, string pictureUrl, int productTypeId, int productBrandId)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            ProductBrand = new ProductBrand
            {
                Id = productBrandId
            };
            ProductType = new ProductType
            {
                Id = productTypeId
            };
        }

        public static implicit operator Product(string Json)
        {
            return new Product();
            /* return new Product
            {
                Name = name,
                Description = description,
                Price = price,
                PictureUrl = pictureUrl,
                ProductBrand = new ProductBrand(productBrandId),
                ProductType = new ProductType(productTypeId),
            }; */
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUrl { get; private set; }
        public ProductType ProductType { get; private set; }
        [NotMapped]
        public int ProductTypeId { get; private set; }
        public ProductBrand ProductBrand { get; private set; }
        [NotMapped]
        public int ProductBrandId { get; private set; }


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