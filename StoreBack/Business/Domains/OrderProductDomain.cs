using Core.Models;
using Database.Repositories;

namespace Business.Domains;

public class OrderProductDomain : IOrderProductDomain
{
    private readonly IOrderProductRepository orderProductRepository;

    public OrderProductDomain(IOrderProductRepository orderProductRepository)
    {
        this.orderProductRepository = orderProductRepository;
    }

    public async Task AddAsync(OrderProduct orderProduct)
    {
        await this.orderProductRepository.AddAsync(orderProduct);
    }

    public async Task<IEnumerable<OrderProduct>> GetAllAsync()
    {
        return await this.orderProductRepository.GetAllAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await this.orderProductRepository.RemoveAsync(id);
    }
}