using Microsoft.EntityFrameworkCore;
using Skinet.Domain.Product;
using Skinet.Infra.Data.Context;

namespace Skinet.Infra.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
      _context = context;
    }

    public async Task<Product> GertProductByIdAsync(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
      return await _context.Products.ToListAsync();
    }
  }
}