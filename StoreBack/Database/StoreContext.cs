using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    // Configuration de la relation many-to-many dans le DbContext
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildOrder(modelBuilder);
        BuildOrderProduct(modelBuilder);
    }

    private static void BuildOrder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
                   .Property(o => o.TotalPrice)
                   .HasColumnType("decimal(18,2)");
    }

    private static void BuildOrderProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
                    .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);
    }
}