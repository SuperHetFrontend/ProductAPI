using Application.Products;
using Domain.Products;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products;

/// <summary>
/// Product repository implementation.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _dbContext.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _dbContext.Products.FindAsync(id);

    public async Task<Product> AddAsync(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync();
}
