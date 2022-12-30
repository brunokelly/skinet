using Skinet.Domain.Product;

namespace Skinet.Infra.Repository
{
  public class ProductRepository : IProductRepository
  {
    public Task<Product> GertProductByIdAsync()
    {
      throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetProductsAsync()
    {
      throw new NotImplementedException();
    }
  }
}