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
            ProductBrandId = productBrandId;
            ProductTypeId = productTypeId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUrl { get; private set; }
        public int ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }
        public int ProductBrandId { get; private set; }
        public ProductBrand ProductBrand { get; private set; }


        public void AddProductType(ProductType productType)
        {
            ProductTypeId = productType.Id;
        }

        public void AddProductBrand(ProductBrand productBrand)
        {
            ProductBrandId = productBrand.Id;
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