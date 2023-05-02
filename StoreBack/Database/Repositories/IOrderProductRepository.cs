using Core.Models;

namespace Database.Repositories;

public interface IOrderProductRepository
{
    Task<IEnumerable<OrderProduct>> GetAllAsync();

    Task AddAsync(OrderProduct orderProduct);

    Task RemoveAsync(int id);
}