using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Product.Models.Response;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain.ProductModel;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specification;
using Skinet.Infra;

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
        public async Task<IActionResult> GetProducts(string? sort, int? brandId, int? typeId)
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(sort, brandId, typeId);
            var response = new List<ProductResponse>();

            return Response((ProductListResponse)await _productRepository.ListAsync(spec));
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
            return Response(await _productBrandRepository.GetListAllAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            return Response(await _productTypeRepository.GetListAllAsync());
        }
    }
}