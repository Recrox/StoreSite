using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<OrderProduct>? OrderProducts { get; set; }
}