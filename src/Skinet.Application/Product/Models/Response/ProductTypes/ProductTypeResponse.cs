using Skinet.Application.Common;


namespace Skinet.Application.Product.Models.Response.ProductTypes
{
    public class ProductTypeResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator ProductTypeResponse(Domain.ProductModel.ProductType productType)
        {
            if (productType == null) return new ProductTypeResponse();

            return new ProductTypeResponse
            {
                Id = productType.Id,
                Name = productType.Name,
            };
        }
    }
}
