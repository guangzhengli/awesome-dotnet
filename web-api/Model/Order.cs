using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Awesome_dotnet.Model;

public class Order : BaseEntity
{
    public virtual Goods Goods { get; set; }
    public virtual OrderStatus Status { get; set; }
    public virtual string UserName { get; set; }
    public virtual string Desc { get; set; }
}

public class OrderMapping : IAutoMappingOverride<Order>
{
    public void Override(AutoMapping<Order> mapping)
    {
        mapping.Table("order");
        mapping.Id(o => o.Id);
        mapping.References(o => o.Goods).Cascade.All();
        mapping.Map(o => o.Status);
        mapping.Map(o => o.UserName);
        mapping.Map(o => o.Desc);
    }
}