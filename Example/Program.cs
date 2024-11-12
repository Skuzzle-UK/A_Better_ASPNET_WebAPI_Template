using Example.Extensions;

namespace Example;

// Prefer traditional format over top level statements
public sealed class Program
{
    public static void Main(string[] args)
    {
        // Clean and grouped
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.ConfigureService();
        
        var app = builder.Build();
        app.ConfigureApplication().Run();
    }
}
