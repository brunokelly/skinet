using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Orders.Models.Requests;
using Skinet.Application.Orders.Services;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        readonly IOrderService _orderService;
        protected OrderController(INotification notification, IOrderService orderService) : base(notification)
        {
            _orderService = orderService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            var email = GetCustomerEmail();

            return Response(await _orderService.CreateOrderAsync(email, orderRequest));
        }
    }
}
