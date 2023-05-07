using Core.Models;
using Database.Repositories;

namespace Business.Domains;

public class ProductDomain : IProductDomain
{
    private readonly IProductRepository productRepository;

    public ProductDomain(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task AddAsync(Product product)
    {
        await this.productRepository.AddAsync(product);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await this.productRepository.GetAllAsync();
    }

    public async Task<Product> GetAsync(int id)
    {
        return await this.productRepository.GetAsync(id);
    }

    public async Task RemoveAsync(int id)
    {
        await this.productRepository.RemoveAsync(id);
    }

    public async Task UpdateAsync(Product product)
    {
        await this.productRepository.UpdateAsync(product);
    }
}