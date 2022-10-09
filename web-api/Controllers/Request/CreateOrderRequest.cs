using System.ComponentModel.DataAnnotations;
using Awesome_dotnet_application.Model;

namespace Awesome_dotnet_application.Controllers.Request;

public class CreateOrderRequest
{
    [Required] public Guid GoodsId { get; set; }

    [Required] public string UserName { get; set; }

    public string Desc { get; set; }

    [Required]
    public Goods Goods { get; set; }
}