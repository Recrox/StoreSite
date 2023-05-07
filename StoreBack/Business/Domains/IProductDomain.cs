using Core.Models;

namespace Business.Domains;

public interface IProductDomain
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetAsync(int id);
    Task AddAsync(Product product);

    Task RemoveAsync(int id);
    Task UpdateAsync(Product product);
}