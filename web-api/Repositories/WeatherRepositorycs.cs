using Awesome_dotnet_application.configuration;

namespace Awesome_dotnet_application;

public class WeatherRepository
{
    private readonly IAppConfiguration _configuration;

    public WeatherRepository(IAppConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetDbConnectStr(string name)
    {
        return _configuration.DBConnectionString + name;
    }
}