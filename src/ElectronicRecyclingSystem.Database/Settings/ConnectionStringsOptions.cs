namespace ElectronicRecyclingSystem.Database.Settings;

public record ConnectionStringsOptions
{
    public required string PostgresConnectionString { get; init; } = string.Empty;
    
    public required string RedisConnectionString { get; init; } = string.Empty;
}