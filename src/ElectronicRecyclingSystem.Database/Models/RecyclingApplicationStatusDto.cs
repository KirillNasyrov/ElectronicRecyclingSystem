using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("recycling_application_statuses")]
public class RecyclingApplicationStatusDto
{
    [Column("id")]
    public short Id { get; set; }
    
    [Column("name")]
    public required string Name { get; set; }
}