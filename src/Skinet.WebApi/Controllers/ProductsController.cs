using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Product.Models.Response;
using Skinet.Application.Product.Models.Response.Brands;
using Skinet.Application.Product.Models.Response.ProductTypes;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain;
using Skinet.Domain.ProductModel;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specification;
using Skinet.WebApi.Helpers;

namespace Skinet.WebApi.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IBaseRepository<ProductBrand> _productBrandRepository;
        private readonly IBaseRepository<ProductType> _productTypeRepository;

        public ProductsController(INotification notification, IBaseRepository<Product> productRepository,
            IBaseRepository<ProductBrand> productBrandRepository,
            IBaseRepository<ProductType> productTypeRepository) : base(notification)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = (ProductListResponse)await _productRepository.ListAsync(spec);

            return Response(new Pagination<ProductResponse>(productParams.PageIndex, productParams.PageSize, totalItems, products.Items.ToList()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(id);

            return Response((ProductResponse)await _productRepository.GetEntityWithSpec(spec));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Response((ProductBrandListResponse)await _productBrandRepository.GetListAllAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            return Response((ProductTypeListResponse)await _productTypeRepository.GetListAllAsync());
        }
    }
}