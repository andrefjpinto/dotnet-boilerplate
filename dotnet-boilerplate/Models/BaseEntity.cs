namespace dotnet_boilerplate.Models;

public class BaseEntity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }

    public BaseEntity()
    {
    }
}