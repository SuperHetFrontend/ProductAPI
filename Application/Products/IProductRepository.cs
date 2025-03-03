using Domain.Products;

namespace Application.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}
