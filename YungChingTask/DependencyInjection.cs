using MySqlConnector;
using YungChingTask.Repository;
using YungChingTask.Repository.Interface;
using YungChingTask.Services;
using YungChingTask.Services.Interface;

namespace YungChingTask;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        services.AddTransient<IMemberService, MemberService>();
        services.AddTransient<IMemberRepository, MemberRepository>();
        services.AddTransient(_ => new MySqlConnection(configuration.GetValue<string>("localDB")));
        return services;
    }
}
