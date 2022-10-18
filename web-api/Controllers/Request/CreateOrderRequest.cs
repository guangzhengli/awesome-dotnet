using System.ComponentModel.DataAnnotations;
using Awesome_dotnet.Models;

namespace Awesome_dotnet.Controllers.Request;

public class CreateOrderRequest
{
    [Required] public Guid GoodsId { get; set; }

    [Required] public string UserName { get; set; }

    public string Desc { get; set; }

    [Required]
    public Goods Goods { get; set; }
}