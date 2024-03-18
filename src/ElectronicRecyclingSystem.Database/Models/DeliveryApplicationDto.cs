namespace ElectronicRecyclingSystem.Database.Models;

public class DeliveryApplicationDto
{
    public int Id { get; set; }
    public string Name { get; init; } = "";
    public string Description { get; init; } = "";
    public int CategoryId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set;}
    public string Image { get; set; } = "";
}