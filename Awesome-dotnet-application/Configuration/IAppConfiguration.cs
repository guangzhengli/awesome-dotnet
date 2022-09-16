namespace Awesome_dotnet_application.configuration;

public interface IAppConfiguration
{
    string DBConnectionString { get; }
}