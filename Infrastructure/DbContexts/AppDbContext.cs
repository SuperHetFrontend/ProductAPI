using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

/// <summary>
/// Database context for the application.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product A", Price = 10.99m, Stock = 100 },
            new Product { Id = 2, Name = "Product B", Price = 15.99m, Stock = 200 },
            new Product { Id = 3, Name = "Product C", Price = 7.99m, Stock = 50 }
        );
    }

    public DbSet<Product> Products => Set<Product>();
}