using Core.Models;

namespace Database.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product> GetAsync(int id);
    Task AddAsync(Product product);

    Task RemoveAsync(int id);
    Task UpdateAsync(Product product);
}