
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Awesome_dotnet_application;
using Awesome_dotnet_application.configuration;
using NLog.Web;

var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);

try
{
    // Add custom configuration
    builder.Configuration.AddJsonFile("configuration.json");
    builder.Services.AddSingleton<IAppConfiguration, AppConfiguration>();
    
    // Modify Log Providers
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    BootStrap.ConfigureServices(builder.Services);

    builder.Host
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(BootStrap.ConfigureContainer);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
}
finally
{
    NLog.LogManager.Shutdown();
}
