namespace ElectronicRecyclingSystem.Database.Models;

public class DeliveryApplicationDto
{
    public long Id { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; init; }
    public double Price { get; init; }
    public int Quantity { get; init;}
    public string? Image { get; set; }
}