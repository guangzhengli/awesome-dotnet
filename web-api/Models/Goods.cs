using FluentNHibernate.Mapping;

namespace Awesome_dotnet.Models;

public class Goods
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    
    public virtual string Desc { get; set; }
}

public class GoodsMapping : ClassMap<Goods>
{
    public GoodsMapping()
    {
        Table("goods");
        Id(g => g.Id).Column("id");
        Map(g => g.Name).Column("name");
        Map(g => g.Desc).Column("desc");
    }
}