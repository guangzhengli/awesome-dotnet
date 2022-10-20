using System.ComponentModel.DataAnnotations;
using Awesome_dotnet.Models;

namespace Awesome_dotnet.Controllers.Request;

public class CreateGoodsRequest
{
    [Required] public string Name { get; set; }

    public string Desc { get; set; }
}