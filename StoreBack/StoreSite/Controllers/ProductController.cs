using Business.Domains;
using Microsoft.AspNetCore.Mvc;
using StoreSite.Models;

namespace StoreSite.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductDomain productDomain;

    public ProductController(IProductDomain productDomain)
    {
        this.productDomain = productDomain;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
    {
        var products = await productDomain.GetAllAsync();
        var productToGet = products.Select(p => new Core.Models.Product
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
        });

        return this.Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(Product product)
    {
        var productToAdd = new Core.Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
        };
        await this.productDomain.AddAsync(productToAdd);

        return this.Ok(productToAdd);
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveAsync(int id)
    {
        await this.productDomain.RemoveAsync(id);
        return this.Ok();
    }
}