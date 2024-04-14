using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ShoeWebStore.Models.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public Category Category { get; set; }
    [Required]
    public string Brand { get; set; }
    [Range(1D, 10000D)]
    public decimal Price { get; set; }
    [Required]
    public string Color { get; set; }
    public string Gender { get; set; }
    [Required]
    public string Material { get; set; }
    // [ValidateNever]
    // public string? ImageUrl { get; set; }
    public int StockQuantity { get; set; }
}
