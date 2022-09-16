namespace Awesome_dotnet_application.Model;

public class Order
{
    private Guid Id { get; set; }
    private Goods Goods { get; set; }
    private OrderStatus Status { get; set; }
    private string UserName { get; set; }
    private string Desc { get; set; }
}