using Awesome_dotnet.Repositories;

namespace Awesome_dotnet.Services;

public class WeatherService
{
    private readonly WeatherRepository _weatherRepository;

    public WeatherService(WeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public string GetDbConnectStr(string name)
    {
        return _weatherRepository.GetDbConnectStr(name);
    }
}