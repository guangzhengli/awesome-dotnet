using System.Reflection;
using Autofac;
using Awesome_dotnet_application.Controllers.Filters;

namespace Awesome_dotnet_application;

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
    }
}