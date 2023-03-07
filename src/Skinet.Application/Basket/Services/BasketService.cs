
using Skinet.Application.Basket.Models.Request;
using Skinet.Application.Basket.Models.Response;
using Skinet.Application.Common;
using Skinet.Domain.Basket;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.SeedOfWork;

namespace Skinet.Application.Basket.Services
{
    public class BasketService : BaseService, IBasketService
    {
        readonly IBasketRepository _basketRepository;
        public BasketService(INotification notification, IBasketRepository basketRepository) : base(notification)
        {
            _basketRepository = basketRepository;
        }

        public async Task<bool> DeleteBasket(string id)
        {
            return await _basketRepository.DeleteBasketAsync(id);
        }

        public async Task<CustomerBasketResponse> GetBasketId(string id)
        {
            return (CustomerBasketResponse)await _basketRepository.GetBasketAsync(id);
        }

        public async Task<CustomerBasketResponse> UpdateBasket(CustomerBasketRequest customerBasket)
        { 
            if (customerBasket is null) return new CustomerBasketResponse();

            var items = new List<BasketItem>();
            customerBasket.Items.ForEach(x =>
            {
                items.Add(new BasketItem(x.Id, x.ProductName, x.Price, x.Quantity, x.PictureUrl, x.Brand));
            });

            var basket = new CustomerBasket(customerBasket.Id, items, "");
            return (CustomerBasketResponse)await _basketRepository.UpdateBasketAsync(basket);
        }
    }
}
