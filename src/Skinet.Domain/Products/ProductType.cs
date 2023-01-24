using Skinet.Domain.Common;

namespace Skinet.Domain.ProductModel
{
    public class ProductType : Entity
    {
        public ProductType()
        {

        }
        public ProductType(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}