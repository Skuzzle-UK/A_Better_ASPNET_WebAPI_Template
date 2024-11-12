namespace Example.Extensions;

public static partial class HostExtensions
{
    public static IServiceCollection AddExampleApplication(this IServiceCollection services, HostBuilderContext hostContext)
    {
        services
            .AddValidatedSettings(hostContext)
            .AddDbContexts()
            .AddRepositories()
            .AddServices()
            .AddMapping()
        ;

        return services;
    }
}
