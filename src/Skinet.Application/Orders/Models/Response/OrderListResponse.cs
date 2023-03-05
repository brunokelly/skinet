using Skinet.Application.Common;
using Skinet.Application.Product.Models.Response;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain.Orders;
using Skinet.Domain.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Orders.Models.Response
{
    public class OrderListResponse : BaseResponse
    {
        public int Total { get; set; }
        public IEnumerable<OrderResponse> Items { get; set; } = new  List<OrderResponse>();

        public static implicit operator OrderListResponse(List<Order> orders)
        {
            if (orders is null) return new OrderListResponse();

            return new OrderListResponse
            {
                Items = orders.Select(order => (OrderResponse)order)
            };
        }
    }
}
