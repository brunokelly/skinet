using Skinet.Application.Common;

namespace Skinet.Application.Product.Models.Response.Brands
{
    public class ProductBrandResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator ProductBrandResponse(Domain.ProductModel.ProductBrand productBrand)
        {
            if (productBrand == null) return new ProductBrandResponse();

            return new ProductBrandResponse
            {
                Id = productBrand.Id,
                Name = productBrand.Name,
            };
        }
    }
}
