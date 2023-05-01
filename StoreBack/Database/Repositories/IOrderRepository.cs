using Core.Models;

namespace Database.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();

    Task AddAsync(Order order);

    Task RemoveAsync(int id);
}