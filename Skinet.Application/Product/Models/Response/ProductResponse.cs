using Skinet.Application.Common;
using Skinet.Domain.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Application.ProductModel.Response
{
    public class ProductResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;  }
        public decimal Price { get; set; }
        public string PictureUrl { get; set;  }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }


        public static implicit operator ProductResponse(Product product)
        {
            if (product == null) return new ProductResponse();

            return new ProductResponse
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductBrand = product.ProductBrand != null ? product.ProductBrand.Name : String.Empty,
                Id = product.Id,
                ProductType = product.ProductType != null ? product.ProductType.Name : String.Empty,
            };
        }
    }
}
