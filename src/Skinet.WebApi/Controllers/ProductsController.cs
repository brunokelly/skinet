using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Product.Models.Response;
using Skinet.Application.Product.Models.Response.Brands;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain;
using Skinet.Domain.ProductModel;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specification;
using Skinet.Application.Common;
using Skinet.Application.Products.Services;

namespace Skinet.WebApi.Controllers
{
    public class ProductsController : BaseController
    {
        readonly IProductService _productService;
        public ProductsController(INotification notification, IProductService productService) : base(notification)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            return Response(await _productService.GetProductsAsync(productParams));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Response(await _productService.GetProductAsync(id));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Response(await _productService.GetBrandsListAsync());
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            return Response(await _productService.GetTypesListAsync());
        }
    }
}