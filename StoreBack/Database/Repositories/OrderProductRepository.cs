using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly StoreContext storeContext;

    public OrderProductRepository(StoreContext storeContext)
    {
        this.storeContext = storeContext;
    }

    public async Task AddAsync(OrderProduct orderProduct)
    {
        var orderProductToAdd = new Database.Models.OrderProduct
        {
            OrderId = orderProduct.OrderId,
            ProductId = orderProduct.ProductId,
            Quantity = orderProduct.Quantity,
        };
        await storeContext.OrderProducts.AddAsync(orderProductToAdd);
        await this.storeContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderProduct>> GetAllAsync()
    {
        var orderProducts = await this.storeContext.OrderProducts.ToListAsync();

        var orderProductsToGet = orderProducts.Select(x => new OrderProduct
        {
            OrderId = x.OrderId,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
        });

        return orderProductsToGet;
    }

    public async Task RemoveAsync(int id)
    {
        var orderProductToRemove = new Database.Models.OrderProduct { OrderId = id };

        this.storeContext.OrderProducts.Remove(orderProductToRemove);
        await this.storeContext.SaveChangesAsync();
    }
}