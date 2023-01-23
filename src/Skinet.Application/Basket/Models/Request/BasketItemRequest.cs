using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.Basket.Models.Request
{
    public class BasketItemRequest
    {
        public BasketItemRequest(int id, string productName, decimal price, int quantity, string pictureUrl, string brand)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            PictureUrl = pictureUrl;
            Brand = brand;
        }

        public int Id { get; private set; }
        public string ProductName { get; private set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; private set; }

        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; private set; }

        public string PictureUrl { get; private set; }
        public string Brand { get; private set; }
    }
}
