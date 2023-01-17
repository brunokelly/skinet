using Skinet.Application.Common;
using Skinet.Domain.ProductModel;

namespace Skinet.Application.Product.Models.Response.Brands
{
    public class ProductBrandListResponse : BaseResponse
    {
        public IEnumerable<ProductBrandResponse> Items { get; set; } = new List<ProductBrandResponse>();

        public static implicit operator ProductBrandListResponse(List<ProductBrand> productBrands)
        {
            if (productBrands == null) return new ProductBrandListResponse();

            return new ProductBrandListResponse
            {
                Items = productBrands.Select(brands => (ProductBrandResponse)brands)
            };
        }
    }
}
