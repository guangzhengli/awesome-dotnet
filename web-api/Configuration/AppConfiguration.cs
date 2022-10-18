namespace Awesome_dotnet.Configuration;

public class AppConfiguration : IAppConfiguration
{
    private readonly IConfiguration _configuration;

    public AppConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
        StaticConfig = configuration;
    }

    public string DBConnectionString => _configuration["Database:Connect:URL"];
    
    public static IConfiguration StaticConfig { get; private set; }
}