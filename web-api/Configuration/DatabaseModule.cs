using System.Reflection;
using Autofac;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using Pluralize.NET;
using WebApi.Common.Repositories;
using Module = Autofac.Module;

namespace Awesome_dotnet.Configuration;

public class DatabaseModule : Module
{
    private readonly IAppConfiguration _configuration;
    private readonly Assembly assembly;

    public DatabaseModule(IAppConfiguration configuration)
    {
        _configuration = configuration;
        assembly = 
    }

    protected sealed override void Load(ContainerBuilder builder)
    {
        builder.Register(() =>
        {
            var factory = 
        })
    }
    
    private ISessionFactory CreateSessionFactory()
    {
        try
        {
            var connectString = _configuration.DBConnectionString;
            var persistenceConfiguration = PostgreSQLConfiguration.Standard.ConnectionString(connectString);
            var fluentConfiguration = Fluently.Configure().Database(persistenceConfiguration)
                .Mappings(m => m.AutoMappings.Add(CreateAutoPersistenceModel()))
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly));
            return fluentConfiguration.ExposeConfiguration(exposeAction).BuildSessionFactory();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private AutoPersistenceModel CreateAutoPersistenceModel()
    {
        var autoPersistenceModel = AutoMap.Assemblies(new AutomappingConfig(), assembly)
            .Conventions.Add(
                Table.Is(c => new Pluralizer().Pluralize(c.EntityType.Name)), 
                ConventionBuilder.Id.Always(c => c.GeneratedBy.Assigned()),
                ForeignKey.EndsWith("Id"),
                ConventionBuilder.Property.When(ac => ac.Expect(NotUpdate), pi => pi.Not.Update()));

        actionConvensions(autoPersistenceModel.Conventions);
        autoPersistenceModel.UseOverridesFromAssembly(assembly);
        return autoPersistenceModel;
    }
}