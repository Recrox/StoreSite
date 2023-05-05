using Business.Domains;
using Database;
using Microsoft.AspNetCore.Mvc;
using StoreSite.ViewModels;

namespace StoreSite.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrderDomain orderDomain;

    public OrderController(IOrderDomain orderDomain)
    {
        this.orderDomain = orderDomain;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllAsync()
    {
        var orders = await this.orderDomain.GetAllAsync();

        var ordersToGet = orders.Select(o => new Order
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            TotalPrice = o.TotalPrice,
        });

        return this.Ok(ordersToGet);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(Order order)
    {
        var orderToAdd = new Core.Models.Order
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
        };

        await this.orderDomain.AddAsync(orderToAdd);

        return this.Ok(orderToAdd);
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        await this.orderDomain.RemoveAsync(id);
        return this.Ok();
    }
}