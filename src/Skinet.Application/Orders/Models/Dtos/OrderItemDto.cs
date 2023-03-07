using Skinet.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Models.Dtos
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public static implicit operator OrderItemDto(OrderItem orderItem)
        {
            if (orderItem == null)
                return new OrderItemDto();

            return new OrderItemDto
            {
                PictureUrl = orderItem.ItemOrdered.PictureUrl,
                ProductId = orderItem.ItemOrdered.ProductItemOrderedId,
                Price = orderItem.Price,
                ProductName = orderItem.ItemOrdered.ProductName,
                Quantity = orderItem.Quantity,
            };
        }

        public static List<OrderItemDto> GetOrderItemDto(List<OrderItem> orderItems)
        {
            var items = new List<OrderItemDto>();

            orderItems.ForEach(x =>
            {
                items.Add((OrderItemDto)x);
            });

            return items;
        }
    }
}
