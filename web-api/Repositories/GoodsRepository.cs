using ISession = NHibernate.ISession;

namespace Awesome_dotnet.Repositories;

public class GoodsRepository : EntityStorage
{
    public GoodsRepository(ISession session) : base(session)
    {
    }
}