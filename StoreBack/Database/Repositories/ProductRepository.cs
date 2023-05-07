using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext storeContext;

    public ProductRepository(StoreContext storeContext)
    {
        this.storeContext = storeContext;
    }

    public async Task AddAsync(Product product)
    {
        var productToAdd = new Database.Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };
        await this.storeContext.Products.AddAsync(productToAdd);
        await this.storeContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await this.storeContext.Products.ToListAsync();

        var productsToGet = products.Select(p => new Product
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
        });

        return productsToGet;
    }

    public async Task<Product> GetAsync(int id)
    {
        var product = await this.storeContext.Products.FindAsync(id);

        if (product is null)
            throw new KeyNotFoundException();

        var productToGet = new Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };
        return productToGet;
    }

    public async Task RemoveAsync(int id)
    {
        var productToRemove = new Database.Models.Product { Id = id };
        this.storeContext.Remove(productToRemove);
        await this.storeContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var productToUpdtate = new Database.Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };
        this.storeContext.Products.Update(productToUpdtate);
        await this.storeContext.SaveChangesAsync();
    }
}