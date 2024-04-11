using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("recycling_application_items")]
public class RecyclingApplicationItemDto
{
    [Column("recycling_application_item_id")]
    public long Id { get; set; }
    
    [Column("recycling_application_id")]
    public long RecyclingApplicationId { get; set; }
    
    [Column("electronic_device_id")]
    public long ElectronicDeviceId { get; set; }
    
    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("price")]
    public decimal? Price { get; set; }
}