namespace Awesome_dotnet_application.configuration;

public class AppConfiguration : IAppConfiguration
{
    private readonly IConfiguration _configuration;

    public AppConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string DBConnectionString => _configuration["Database:Connect:URL"];
}