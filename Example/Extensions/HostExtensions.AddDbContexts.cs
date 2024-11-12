using Example.Storage.DbContexts;

namespace Example.Extensions;

public static partial class HostExtensions
{
    public static IServiceCollection AddDbContexts(this IServiceCollection services) =>
        services
            .AddScoped<IDbContext, FakeDbContext>()
        ;
}
