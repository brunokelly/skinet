namespace Skinet.Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GertProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}