using Skinet.Application.Common;
using Skinet.Application.Orders.Models.Requests;
using Skinet.Application.Orders.Models.Response;
using Skinet.Application.Products.Services;
using Skinet.Domain;
using Skinet.Domain.Basket;
using Skinet.Domain.Basket.Repository;
using Skinet.Domain.Identity;
using Skinet.Domain.Orders;
using Skinet.Domain.Orders.Repository;
using Skinet.Domain.SeedOfWork;
using Skinet.Domain.Specification;
using Skinet.Infra.Data;

namespace Skinet.Application.Orders.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepo;
        private readonly IDeliveryMethodService _deliveryMethodService;
        private readonly IProductService _productService;

        public OrderService(IOrderRepository orderRepository,INotification notification, IBasketRepository basketRepository, IDeliveryMethodService deliveryMethodService, IProductService productService) : base(notification)
        {
            _orderRepository = orderRepository;
            _basketRepo = basketRepository;
            _deliveryMethodService = deliveryMethodService;
            _productService = productService;
        }

        public async Task<OrderResponse> CreateOrderAsync(string buyerEmail, OrderRequest orderRequest)
        {
            // get basket from repo
            var basket = await _basketRepo.GetBasketAsync(orderRequest.BasketId);
            if (basket is null) return new OrderResponse();

            // get items from the product repo
            var items = await GetProducts(basket);
            if(items is null) return new OrderResponse();

            var spec = new OrderByPaymentIntentIdSpecification(basket.PaymentIntentId);
            var order = await _orderRepository.GetEntityWithSpec(spec);

            // check to see if order exists
            await CreateNewOrder(order, orderRequest, items, buyerEmail, basket.PaymentIntentId);
            // save to db
             _orderRepository.SaveChanges();

            // return order
            return (OrderResponse)order;
        }

        public async Task<DeliveryMethodListReponse> GetDeliveryMethodsAsync()
        {
            return await _deliveryMethodService.ListAllAsync();
        }

        public async Task<OrderResponse> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

            return (OrderResponse)await _orderRepository.GetEntityWithSpec(spec);
        }

        public async Task<OrderListResponse> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return (OrderListResponse)await _orderRepository.ListAsync(spec);
        }

        private async Task CreateNewOrder(Order order, OrderRequest orderRequest, List<OrderItem> items, string buyerEmail, string paymentIntentId)
        {
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethodByIdAsync(orderRequest.DeliveryMethodId);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            if (order != null)
            {
                order.UpdateOrderAddress(order.ShipToAddress);
                order.UpdateDeliveryMethod(deliveryMethod);
                order.UpdateSubtotal(subtotal);
                _orderRepository.Update(order);
            }
            else
            {
                order = new Order(items, buyerEmail, orderRequest.ShipToAddress, deliveryMethod,
                    subtotal, paymentIntentId);
                _orderRepository.Add(order);
            }
        }

        private async Task<List<OrderItem>> GetProducts(CustomerBasket basket)
        {
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _productService.GetProductAsync(item.Id);

                if (productItem is null) break;

                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            return items;
        }
    }
}
