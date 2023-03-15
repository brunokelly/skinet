using Microsoft.Extensions.Configuration;
using Skinet.Application.Basket.Models.Response;
using Skinet.Application.Basket.Services;
using Skinet.Application.Common;
using Skinet.Domain.Basket;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.Orders.Repository;
using Skinet.Domain.ProductModel.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Infra.Data;
using Stripe;

namespace Skinet.Application.Payments
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IBasketRepository _basketService;
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PaymentService(INotification notification, IBasketRepository basketService,
            IUnitOfWork unitOfWork, IConfiguration configuration, 
            IDeliveryMethodRepository deliveryMethodRepository, IProductRepository productRepository) : base(notification)
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _deliveryMethodRepository = deliveryMethodRepository;
            _productRepository = productRepository;
        }

        public async Task<CustomerBasketResponse> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var basket = await _basketService.GetBasketAsync(basketId);
            var shippingPrice = 0m;

            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethodPrice = (await _deliveryMethodRepository.GetByIdAsync(basket.DeliveryMethodId.Value))?.Price;
                shippingPrice = deliveryMethodPrice ?? 0m;
            }

            basket.Items.ForEach(async item =>
            {
                var productItem = await _productRepository.GetProductByIdAsync(item.Id);
                item.UpdatePriceByProduct(productItem);
            });

            await CreatePayment(basket, shippingPrice);

            await _basketService.UpdateBasketAsync(basket);

            return (CustomerBasketResponse)basket;
        }

        private async Task CreatePayment(CustomerBasket basket, decimal shippingPrice)
        {
            var service = new PaymentIntentService();

            PaymentIntent paymentIntent;

            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
                basket.UpdatePaymentIntent(paymentIntent.Id, paymentIntent.ClientSecret);
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                };

                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            
        }
    }
}
