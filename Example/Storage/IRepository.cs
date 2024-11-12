using Example.Storage.Entities;
using FluentResults;

namespace Example.Storage;

public interface IRepository<T> where T : IEntity, new()
{
    Task<Result<List<T>>> GetManyAsync(CancellationToken ct);
}