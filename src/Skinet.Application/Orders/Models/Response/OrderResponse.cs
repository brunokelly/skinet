using Skinet.Application.Common;
using Skinet.Application.Orders.Models.Dtos;
using Skinet.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Models.Response
{
    public class OrderResponse : BaseResponse
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderAddress ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus Status { get; set; }
        public string PaymentIntentId { get; set; }

        public static implicit operator OrderResponse(Order order)
        {
            if (order is null) return new OrderResponse();

            return new OrderResponse()
            {
                ShipToAddress = order.ShipToAddress,
                DeliveryMethod = order.DeliveryMethod,
                Status = order.Status,
                PaymentIntentId = order.PaymentIntentId,
                Subtotal = order.Subtotal,
                BuyerEmail = order.BuyerEmail,
                OrderDate = order.OrderDate,
                OrderItems = OrderItemDto.GetOrderItemDto(order.OrderItems.ToList()),
                Id = order.Id
            };
        }

        
    }
}
