using Awesome_dotnet.Configuration;

namespace Awesome_dotnet.Repositories;

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