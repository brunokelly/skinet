
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Skinet.Domain.ProductModel;
using Skinet.Infra.Data.Context;

namespace Skinet.Infra.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Skinet.Infra.Data/SeedData/brands.json");
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsData);

                    brands.ForEach(x =>
                    {
                        context.ProductBrands.Add(x);
                    });
                   
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Skinet.Infra.Data/SeedData/types.json");
                    var types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);

                    await context.ProductTypes.AddRangeAsync(types);
                }
                
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Skinet.Infra.Data/SeedData/products.json");
                    var product = JsonConvert.DeserializeObject<List<Product>>(productData);

                    await context.Products.AddRangeAsync(product);
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
