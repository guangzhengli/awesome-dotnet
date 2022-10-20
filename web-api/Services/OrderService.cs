using System.Reflection;
using Awesome_dotnet.Models;
using Awesome_dotnet.Repositories;

namespace Awesome_dotnet.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;

    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void CreateOrder(Order order)
    {
        _orderRepository.Save(order);
    }
}