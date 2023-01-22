using Skinet.Application.Common;
using Skinet.Application.Product.Models.Response.ProductTypes;
using Skinet.Domain.ProductModel;

namespace Skinet.Application.Product.Models.Response.Brands
{
    public class ProductTypeListResponse : BaseResponse
    {
        public IEnumerable<ProductTypeResponse> Items { get; set; } = new List<ProductTypeResponse>();

        public static implicit operator ProductTypeListResponse(List<ProductType> productTypes)
        {
            if (productTypes == null) return new ProductTypeListResponse();

            return new ProductTypeListResponse
            {
                Items = productTypes.Select(types => (ProductTypeResponse)types)
            };
        }
    }
}
