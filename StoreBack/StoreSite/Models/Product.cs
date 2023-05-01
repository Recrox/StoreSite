namespace StoreSite.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public ICollection<OrderProduct>? OrderProducts { get; set; }
}