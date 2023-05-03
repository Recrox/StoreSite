using Business.Domains;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSite.Models;

namespace StoreSite.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderProductController : ControllerBase
{
    private readonly IOrderProductDomain orderProductDomain;

    public OrderProductController(IOrderProductDomain orderProductDomain)
    {
        this.orderProductDomain = orderProductDomain;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderProduct>>> GetAllAsync()
    {
        var ordersProducts = await this.orderProductDomain.GetAllAsync();

        var ordersProdutcToGet = ordersProducts.Select(op => new StoreSite.Models.OrderProduct
        {
            OrderId = op.OrderId,
            ProductId = op.ProductId,
            Quantity = op.Quantity,
        });

        return this.Ok(ordersProdutcToGet);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(OrderProduct orderProduct)
    {
        var orderProductToAdd = new Core.Models.OrderProduct
        {
            OrderId = orderProduct.OrderId,
            ProductId = orderProduct.ProductId,
            Quantity = orderProduct.Quantity,
        };

        await this.orderProductDomain.AddAsync(orderProductToAdd);

        return this.Ok(orderProductToAdd);
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        await this.orderProductDomain.RemoveAsync(id);
        return this.Ok();
    }
}