using Core.Models;

namespace Business.Domains;

public interface IOrderProductDomain
{
    Task<IEnumerable<OrderProduct>> GetAllAsync();

    Task AddAsync(OrderProduct orderProduct);

    Task RemoveAsync(int id);
}