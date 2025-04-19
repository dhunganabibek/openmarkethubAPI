public record ProductDTO
{
    public required Guid ProductID { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
}