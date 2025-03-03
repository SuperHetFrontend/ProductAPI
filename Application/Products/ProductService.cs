using Domain.Products;

namespace Application.Products;

/// <summary>
/// Product service implementation.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
        await _repository.GetAllAsync();

    public async Task<Product?> GetProductByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task<Product> CreateProductAsync(Product product) =>
        await _repository.AddAsync(product);

    public async Task<bool> UpdateProductAsync(int id, Product product)
    {
        var existingProduct = await _repository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingProduct = await _repository.GetByIdAsync(id);
        if (existingProduct == null)
        {
            return false;
        }

        await _repository.DeleteAsync(id);
        return true;
    }
}
