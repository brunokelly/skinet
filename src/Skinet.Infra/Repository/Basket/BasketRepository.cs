using Skinet.Domain.Basket;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.SeedOfWork;
using StackExchange.Redis;
using System.Text.Json;

namespace Skinet.Infra.Repository.Basket
{
    public class BasketRepository : IBasketRepository
    {
        readonly IDatabase _database;
        readonly INotification _notification;

        public BasketRepository(IConnectionMultiplexer redis, INotification notification)
        {
            _database = redis.GetDatabase();
            _notification = notification;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? new CustomerBasket(basketId) : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            if (basket is null) return null;

            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
