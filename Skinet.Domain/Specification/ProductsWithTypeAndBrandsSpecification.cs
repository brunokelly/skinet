using Skinet.Domain.Specifications;
using Skinet.Domain.ProductModel;

namespace Skinet.Domain.Specification
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<ProductModel.Product>
    {
        public ProductsWithTypeAndBrandsSpecification(string sort, int? brandId, int? typeId) : 
            base(x =>
                (!brandId.HasValue || x.ProductBrand.Id == brandId) &&
                (!typeId.HasValue || x.ProductType.Id == typeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypeAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}
