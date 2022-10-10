using NHibernate;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ISession = NHibernate.ISession;

namespace Awesome_dotnet.Repositories
{
    public class EntityStorage : IDisposable
    {
        readonly ISession session;

        public EntityStorage(ISession session)
        {
            this.session = session;
        }

        public void Save(object entity)
        {
            session.SaveOrUpdate(entity);
            session.Flush();
        }

        public void Delete(object entity)
        {
            session.Delete(entity);
            session.Flush();
        }

        public T Load<T>(Guid id) where T: class
        {
            try
            {
                return session.Get<T>(id);
            }
            catch (GenericADOException)
            {
                return null;
            }
        }

        public IList<T> FindByCriteria<T>(ICriterion criterion) where T : class
        {
            return session.CreateCriteria<T>()
                .Add(criterion)
                .List<T>();
        }

        public IQueryable<T> Query<T>()
        {
            return session.Query<T>();
        }

        public ISQLQuery CreateSqlQuery(string sqlQuery)
        {
            return session.CreateSQLQuery(sqlQuery);
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}