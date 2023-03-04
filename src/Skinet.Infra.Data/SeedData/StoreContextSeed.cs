
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Skinet.Domain.Orders;
using Skinet.Domain.ProductModel;
using Skinet.Infra.Data.Context;

namespace Skinet.Infra.Data.SeedData
{
    public class StoreContextSeed
    {
        private readonly IConfiguration _configuration;

        public StoreContextSeed(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory, IConfiguration _configuration)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsDir = _configuration["SeedData:Brands"];
                    var brandsDataJson = File.ReadAllText(brandsDir);
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsDataJson);

                    brands.ForEach(x =>
                    {
                        context.ProductBrands.Add(x);
                    });
                }

                if (!context.ProductTypes.Any())
                {
                    var typesDir = _configuration["SeedData:Types"];
                    var typesData = File.ReadAllText(typesDir);
                    var types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);
                    await context.ProductTypes.AddRangeAsync(types);
                }

                if (!context.Products.Any())
                {
                    var productsDir = _configuration["SeedData:Products"];
                    var productData = File.ReadAllText(productsDir);
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products.AddRangeAsync(products);
                }

                if (!context.DeliveryMethods.Any())
                {
                    var deliveryDir = _configuration["SeedData:Delivery"];
                    var deliveryData = File.ReadAllText(deliveryDir);
                    var deliveryMethods = JsonConvert.DeserializeObject<List<DeliveryMethod>>(deliveryData);
                    await context.DeliveryMethods.AddRangeAsync(deliveryMethods);
                }

                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}
