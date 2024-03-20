using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("delivery_applications")]
public class DeliveryApplicationDto
{
    [Column("delivery_application_id")]
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Image { get; set; }
}