using System.Reflection;
using Autofac;
using Awesome_dotnet.Controllers.Filters;
using Awesome_dotnet.Models;
using Awesome_dotnet.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Awesome_dotnet;

public static class BootStrap
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ValidationActionFilter>();
        });
    }
    
    public static void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("Repository")).SingleInstance();
        
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("Service")).SingleInstance();
        
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("Controller")).SingleInstance();

        ConfigureDatabase(builder);
    }

    private static void ConfigureDatabase(ContainerBuilder builder)
    {
        builder.Register(c =>
        {
            var session = c.Resolve<ISessionFactory>().OpenSession();
            session.FlushMode = FlushMode.Auto;
            return session;
        }).As<ISession>().InstancePerLifetimeScope();
        
        builder.RegisterType<EntityStorage>().InstancePerLifetimeScope();
        
        builder.Register(_ =>
        {
            // var connectString = AppConfiguration.StaticConfig["Database:Connect:URL"];
            const string connectString = "Server=127.0.0.1;Port=5432;Database=awesome_dotnet;User Id=postgres;Password=postgrepassword;";
            var persistenceConfiguration = PostgreSQLConfiguration.Standard.ConnectionString(connectString);
            return Fluently.Configure().Database(persistenceConfiguration)
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Program>()).BuildSessionFactory();
        }).SingleInstance();
    }
}