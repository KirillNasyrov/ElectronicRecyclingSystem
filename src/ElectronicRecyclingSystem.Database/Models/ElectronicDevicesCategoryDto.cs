using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("electronic_devices_categories")]
public class ElectronicDevicesCategoryDto
{
    [Column("id")]
    public short Id { get; set; }
    
    [Column("name")]
    public required string Name { get; set; }
}