using Example.Storage.DbContexts;
using Example.Storage.Entities;
using FluentResults;

namespace Example.Storage;

// Using the fake dbcontext really messes this up.. Would usually be IEntity not WeatherForecastEntity
public sealed class Repository<T> : IRepository<T> where T : WeatherForecastEntity, new()
{
    private readonly ILogger<Repository<T>> _logger;
    private readonly IDbContext _dbContext;

    public Repository(
        ILogger<Repository<T>> logger,
        IDbContext dbcontext)
    {
        _logger = logger;
        _dbContext = dbcontext;
    }

    public async Task<Result<List<T>>> GetManyAsync(CancellationToken ct)
    {
        try
        {
            return Result.Ok(await _dbContext.GetManyAsync<T>(ct));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Failed to GetMany for type of {type} with error: {errorMessage}",
                    nameof(T),
                    ex.Message);

            return Result.Fail(ex.Message);
        }
    }
}
