using Awesome_dotnet.Controllers.Request;
using Microsoft.AspNetCore.Mvc;

namespace Awesome_dotnet.Controllers;

[ApiController]
[Route("/orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/create")]
    public IActionResult CreateOrder(CreateOrderRequest request)
    {
        _logger.LogInformation("request CreateOrder");
        _logger.LogInformation($"request is: {request}");
        return Ok("success");
    }
}