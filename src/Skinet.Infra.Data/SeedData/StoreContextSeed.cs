
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
                var productsDir = _configuration["SeedData:Products"];
                var brandsDir = _configuration["SeedData:Brands"];
                var typesDir = _configuration["SeedData:Types"];

                if (!context.ProductBrands.Any())
                {
                    var brandsDataJson = File.ReadAllText(brandsDir);
                    var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandsDataJson);

                    brands.ForEach(x =>
                    {
                        context.ProductBrands.Add(x);
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(typesDir);
                    var types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);

                    await context.ProductTypes.AddRangeAsync(types);

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText(productsDir);
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);

                    products.ForEach(product =>
                    {
                        product.AddProductBrand(context.ProductBrands.FirstOrDefault(x => x.Id == product.ProductBrandId));
                        product.AddProductType(context.ProductTypes.FirstOrDefault(x => x.Id == product.ProductTypeId));
                    });

                    await context.Products.AddRangeAsync(products);
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
