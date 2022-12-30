using Microsoft.AspNetCore.Mvc;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
  [ApiController]
  [Route("api/[controller")]
  public class ProductsController : BaseController
  {
    private readonly ILogger<ProductsController> _logger;
    public ProductsController(ILogger<ProductsController> logger, INotification notification) : base(notification)
    {
      _logger = logger;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
      return Response("Product");
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
      return Response("Product");
    }
  }
}