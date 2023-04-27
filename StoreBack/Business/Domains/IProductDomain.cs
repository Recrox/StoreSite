using Core.Models;

namespace Business.Domains;

public interface IProductDomain
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task AddAsync(Product product);

    Task RemoveAsync(int id);
}