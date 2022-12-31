using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.ProductModel;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specification;
using Skinet.Infra;

namespace Skinet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetProducts()
        {
            var spec = new ProductsWithTypeAndBrandsSpecification();

            return Response(await _productRepository.ListAsync(spec));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Response(await _productRepository.GetByIdAsync(id));
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