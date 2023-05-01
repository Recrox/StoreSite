using Core.Models;
using Database.Repositories;

namespace Business.Domains;

public class OrderDomain : IOrderDomain
{
    private readonly IOrderRepository orderRepository;

    public OrderDomain(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task AddAsync(Order order)
    {
        await this.orderRepository.AddAsync(order);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await this.orderRepository.GetAllAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await orderRepository.RemoveAsync(id);
    }
}