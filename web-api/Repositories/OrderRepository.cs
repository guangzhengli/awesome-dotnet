using ISession = NHibernate.ISession;

namespace Awesome_dotnet.Repositories;

public class OrderRepository : EntityStorage
{
    public OrderRepository(ISession session) : base(session)
    {
    }
}