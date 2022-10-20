using Awesome_dotnet.Controllers.Request;
using Awesome_dotnet.Models;
using Awesome_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Awesome_dotnet.Controllers;

[ApiController]
[Route("/goods")]
public class GoodsController : ControllerBase
{
    private readonly ILogger<GoodsController> _logger;
    private readonly GoodsService _goodsService;

    public GoodsController(GoodsService goodsService, ILogger<GoodsController> logger)
    {
        _goodsService = goodsService;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult CreateOrder(CreateGoodsRequest request)
    {
        var goods = new Goods
        {
            Name = request.Name,
            Desc = request.Desc
        };
        _goodsService.CreateGoods(goods);
        return Ok();
    }
}