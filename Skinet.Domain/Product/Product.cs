using Skinet.Domain.Common;

namespace Skinet.Domain.Product
{
  public class Product : Entity
  {
    public Product(string name, string description, decimal price, string pictureUrl)
    {
      Name = name;
      Description = description;
      Price = price;
      PictureUrl = pictureUrl;
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