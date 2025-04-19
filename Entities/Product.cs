namespace openmarkethubAPI.Entities;
public class Product{
    public Guid ProductID { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
}