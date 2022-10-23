using Awesome_dotnet.Controllers.Request;
using Awesome_dotnet.Models;
using Awesome_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Awesome_dotnet.Controllers;

[ApiController]
[Route("/orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly OrderService _orderService;
    private readonly GoodsService _goodsService;

    public OrderController(ILogger<OrderController> logger, OrderService orderService, GoodsService goodsService)
    {
        _logger = logger;
        _orderService = orderService;
        _goodsService = goodsService;
    }

    [HttpPost]
    public IActionResult CreateOrder(CreateOrderRequest request)
    {
        var goods = _goodsService.GetGoods(request.GoodsId);
        var order = new Order
        {
            Goods = goods,
            Status = OrderStatus.Created,
            UserName = request.UserName,
            Description = request.Desc
        };
        _orderService.CreateOrder(order);
        return Ok();
    }
    
}