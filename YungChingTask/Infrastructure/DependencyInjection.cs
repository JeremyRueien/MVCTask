using MySqlConnector;

namespace YungChingTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(_ => new MySqlConnection(configuration.GetValue<string>("LocalDB")));
        services.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses(
            classes => classes.Where(t =>
            t.Name.EndsWith("repository", StringComparison.OrdinalIgnoreCase) ||
            t.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase)))
        .AsImplementedInterfaces()
        .WithTransientLifetime());
        return services;
    }
}
