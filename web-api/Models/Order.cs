using FluentNHibernate.Mapping;

namespace Awesome_dotnet.Models;

public class Order
{
    public virtual int Id { get; set; }
    public virtual Goods Goods { get; set; }
    public virtual OrderStatus Status { get; set; }
    public virtual string UserName { get; set; }
    public virtual string Description { get; set; }
}

public class OrderMapping : ClassMap<Order>
{
    public OrderMapping()
    {
        Table("order");
        Id(o => o.Id).Column("id");
        References(o => o.Goods).Column("goods_id").Cascade.All();
        Map(o => o.Status).Column("status");
        Map(o => o.UserName).Column("username");
        Map(o => o.Description).Column("description");
    }
}