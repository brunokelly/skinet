using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Basket.Models.Response;
using Skinet.Domain.Basket;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    public class BasketController : BaseController
    {
        readonly IBasketRepository basketRepository;

        public BasketController(INotification notification, IBasketRepository basketRepository) : base(notification)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketId(string id)
        {
            return Response((CustomerBasketResponse)await basketRepository.GetBasketAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(CustomerBasket customerBasket)
        {
            return Response((CustomerBasketResponse)await basketRepository.UpdateBasketAsync(customerBasket));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            return Response(await basketRepository.DeleteBasketAsync(id));
        }
    }
}
