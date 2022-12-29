using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skinet.Application.Common;
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