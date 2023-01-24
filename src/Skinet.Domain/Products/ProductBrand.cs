using Skinet.Domain.Common;

namespace Skinet.Domain.ProductModel
{
    public class ProductBrand : Entity
    {

        public ProductBrand()
        {

        }
        public ProductBrand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}