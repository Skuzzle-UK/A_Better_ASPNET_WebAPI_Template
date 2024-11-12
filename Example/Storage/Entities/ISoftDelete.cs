namespace Example.Storage.Entities;

public interface ISoftDelete
{
    DateTimeOffset? DeletedOn { get; set; }
}
