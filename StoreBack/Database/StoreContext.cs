using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public StoreContext(DbContextOptions options) : base(options)
    {
    }
}