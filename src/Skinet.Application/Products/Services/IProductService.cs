using Skinet.Application.Common;
using Skinet.Application.Product.Models.Response.Brands;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain.Specification;

namespace Skinet.Application.Products.Services
{
    public interface IProductService
    {
        Task<Pagination<ProductResponse>> GetProductsAsync(ProductSpecParams productParams);
        Task<ProductResponse> GetProductAsync(int id);
        Task<ProductBrandListResponse> GetBrandsListAsync();
        Task<ProductTypeListResponse> GetTypesListAsync();

    }
}
