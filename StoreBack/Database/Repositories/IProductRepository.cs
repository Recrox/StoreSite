using Core.Models;

namespace Database.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task AddAsync(Product product);

    Task RemoveAsync(int id);
}