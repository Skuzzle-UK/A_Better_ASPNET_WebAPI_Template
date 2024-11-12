namespace Example.Extensions;

// All host/services configuration moved away to host extensions to keep program.cs clean
public static partial class HostExtensions
{
    public static IHostBuilder ConfigureService(this IHostBuilder host)
    {
        return host.ConfigureServices((hostContext, services) =>
        {
            services.AddExampleApplication(hostContext);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        });
    }
}
