using Core.Models;

namespace Business.Domains;

public interface IOrderDomain
{
    Task<IEnumerable<Order>> GetAllAsync();

    Task AddAsync(Order order);

    Task RemoveAsync(int id);
}