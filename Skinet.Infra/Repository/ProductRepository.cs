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

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        private IQueryable<Product> GetAll()
        {
            return _context.Products
                .AsNoTracking()
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductType)
                .AsQueryable();
        }
    }
}