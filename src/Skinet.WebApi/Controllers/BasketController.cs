using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Basket.Models.Request;
using Skinet.Application.Basket.Services;
using Skinet.Domain.Basket;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    public class BasketController : BaseController
    {
        readonly IBasketService _basketService;

        public BasketController(INotification notification, IBasketService basketService) : base(notification)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketId(string id)
        {
            return Response(await _basketService.GetBasketId(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasketRequest customerBasket)
        {
            return Response(await _basketService.UpdateBasket(customerBasket));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            return Response(await _basketService.DeleteBasket(id));
        }
    }
}
