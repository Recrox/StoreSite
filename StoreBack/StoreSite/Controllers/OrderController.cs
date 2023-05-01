using Business.Domains;
using Microsoft.AspNetCore.Mvc;

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


}