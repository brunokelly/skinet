namespace Skinet.Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GertProductByIdAsync();
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}