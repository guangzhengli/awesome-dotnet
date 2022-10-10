namespace Awesome_dotnet.Configuration;

public interface IAppConfiguration
{
    string DBConnectionString { get; }
}