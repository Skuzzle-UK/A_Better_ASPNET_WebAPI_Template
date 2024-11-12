namespace Example.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app
                .UseSwagger()
                .UseSwaggerUI();
        }

        app
            .UseHttpsRedirection()
            .UseAuthorization();

        // Required like this for middleware to work
        app.MapControllers();

        return app;
    }
}
