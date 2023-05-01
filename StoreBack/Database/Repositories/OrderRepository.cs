using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly StoreContext storeContext;

    public OrderRepository(StoreContext storeContext)
    {
        this.storeContext = storeContext;
    }

    public async Task AddAsync(Order order)
    {
        var orderToAdd = new Database.Models.Order
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
        };
        await storeContext.Orders.AddAsync(orderToAdd);
        await this.storeContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await this.storeContext.Orders.ToListAsync();

        var ordersToGet = orders.Select(o => new Order
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            TotalPrice = o.TotalPrice,
        });

        return ordersToGet;
    }

    public async Task RemoveAsync(int id)
    {
        var orderToRemove = new Database.Models.Order { Id = id };
        this.storeContext.Remove(orderToRemove);
        await this.storeContext.SaveChangesAsync();
    }
}