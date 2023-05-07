using Business.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreSite.ViewModels;

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

    //[Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
    {
        var products = await productDomain.GetAllAsync();
        var productToGet = products.Select(p => new Product
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
        });

        return this.Ok(productToGet);
    }

    [HttpGet]
    public async Task<ActionResult<Product>> GetAsync(int id)
    {
        var product = await productDomain.GetAsync(id);
        var productToGet = new Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };
        return this.Ok(productToGet);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(Product product)
    {
        var productToAdd = new Core.Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
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

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(Product product)
    {
        var productToUpdtate = new Core.Models.Product
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };

        await this.productDomain.UpdateAsync(productToUpdtate);
        return this.Ok(productToUpdtate);
    }

    [HttpGet]
    public IActionResult GetImage()
    {
        //string imagePath = Path.Combine("Images", "i102005-chocolat-nu.webp"); // chemin d'accès à l'image
        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Database", "Images", "i102005-chocolat-nu.webp");

        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath); // lit les octets de l'image
        var file = this.File(imageBytes, "image/webp");// renvoie l'image en tant que réponse HTTP
        return this.Ok(file);
    }
}