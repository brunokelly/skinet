using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.Product;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, INotification notification, IProductRepository productRepository) : base(notification)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Response(await _productRepository.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Response(await _productRepository.GetProductByIdAsync(id));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Response(await _productRepository.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            return Response(await _productRepository.GetProductTypesAsync());
        }
    }
}