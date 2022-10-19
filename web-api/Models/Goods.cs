using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Awesome_dotnet.Models;

public class Goods : BaseEntity
{
    public virtual string Name { get; set; }
    
    public virtual string Desc { get; set; }
}

public class GoodsMapping : IAutoMappingOverride<Goods>
{
    public void Override(AutoMapping<Goods> mapping)
    {
        mapping.Table("goods");
        mapping.Id(g => g.Id);
        mapping.Map(g => g.Name).Column("name");
        mapping.Map(g => g.Desc).Column("desc");
    }
}