using System.Reflection;
using Autofac;
using Awesome_dotnet.Configuration;
using Awesome_dotnet.Controllers.Filters;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

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

        ConfigureDatabase(builder);
    }

    private static void ConfigureDatabase(ContainerBuilder builder)
    {
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