using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace database_migration
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();
            
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }
        
        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString("local")
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
            // .AddPostgres()
            // .WithGlobalConnectionString("Server=127.0.0.1;Port=5432;Database=awesome_dotnet;User Id=postgres;Password=postgrepassword;")
        }
        
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}