using Skinet.Application.Common;
using Skinet.Application.Product.Models.Response;
using Skinet.Application.Product.Models.Response.Brands;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain;
using Skinet.Domain.ProductModel;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specification;

namespace Skinet.Application.Products.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IBaseRepository<Skinet.Domain.ProductModel.Product> _productRepository;
        private readonly IBaseRepository<ProductBrand> _productBrandRepository;
        private readonly IBaseRepository<ProductType> _productTypeRepository;

        public ProductService(INotification notification, IBaseRepository<Domain.ProductModel.Product> productRepository, IBaseRepository<ProductBrand> productBrandRepository, IBaseRepository<ProductType> productTypeRepository) : base(notification)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

        public async Task<ProductBrandListResponse> GetBrandsListAsync()
        {
            return (ProductBrandListResponse)await _productBrandRepository.GetListAllAsync();
        }

        public async Task<ProductResponse> GetProductAsync(int id)
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(id);
            return (ProductResponse)await _productRepository.GetEntityWithSpec(spec);
        }

        public async Task<Pagination<ProductResponse>> GetProductsAsync(ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = (ProductListResponse)await _productRepository.ListAsync(spec);

            return new Pagination<ProductResponse>(productParams.PageIndex, productParams.PageSize, totalItems, products.Items.ToList());
        }

        public async Task<ProductTypeListResponse> GetTypesListAsync()
        {
            return (ProductTypeListResponse)await _productTypeRepository.GetListAllAsync();
        }
    }
}
