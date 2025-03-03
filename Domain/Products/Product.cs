using System.ComponentModel.DataAnnotations;

namespace Domain.Products;

/// <summary>
/// Product entity class - represents a product in the system.
/// </summary>
public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;
    [Range(0.01, 10000.00)]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
