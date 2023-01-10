using Skinet.Domain.ProductModel;
using Skinet.Domain.Specifications;
namespace Skinet.Domain.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {

        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) 
            :  base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrand.Id == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductType.Id == productParams.TypeId))
        {

        }
    }
}
