using Skinet.Application.Common;
using Skinet.Application.ProductModel.Response;

namespace Skinet.Application.Product.Models.Response
{
    public class ProductListResponse : BaseResponse
    {
        public IEnumerable<ProductResponse> Items {  get; set; } =  new List<ProductResponse>();
        public int TotalPages { get; set; }
        public static implicit operator ProductListResponse(List<Skinet.Domain.ProductModel.Product> products)
        {
            if(products == null) return new ProductListResponse();

            return new ProductListResponse
            {
                Items = products.Select(product => (ProductResponse)product)
            };
        }
    }
}
