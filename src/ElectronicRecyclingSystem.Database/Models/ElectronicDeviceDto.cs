using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("electronic_devices")]
public class ElectronicDeviceDto
{
    [Column("electronic_device_id")]
    public long Id { get; set; }
    
    [Column("electronic_device_name")]
    public required string Name { get; set; }
    
    [Column("category_id")]
    public int CategoryId { get; set; }
    
    [Column("image_url")]
    public string? ImageUrl { get; set; }
};