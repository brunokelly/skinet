using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Orders.Models.Requests;
using Skinet.Application.Orders.Services;
using Skinet.Domain.Orders;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Utils.Extensions;

namespace Skinet.WebApi.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        readonly IOrderService _orderService;
        public OrdersController(INotification notification, IOrderService orderService) : base(notification)
        {
            _orderService = orderService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            var email = GetCustomerEmail();

            return Response(await _orderService.CreateOrderAsync(email, orderRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersForUser()
        {
            var email = GetCustomerEmail();

            return Response(await _orderService.GetOrdersForUserAsync(email, orderRequest));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdForUser(int id)
        {
            var email = GetCustomerEmail();

            return  Response(await _orderService.GetOrderByIdAsync(email, orderRequest));
    }

        [HttpGet("deliveryMethods")]
        public async Task<IActionResult> GetDeliveryMethods()
        {
        return Response(await _orderService.GetDeliveryMethodsAsync(email, orderRequest));
    }
    }
}
