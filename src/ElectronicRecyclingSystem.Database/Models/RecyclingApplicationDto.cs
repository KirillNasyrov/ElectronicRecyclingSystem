using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("recycling_applications")]
public class RecyclingApplicationDto
{
    [Column("recycling_application_id")]
    public long Id { get; set; }
    
    [Column("user_id")]
    public long UserId { get; set; }
    
    [Column("status_id")]
    public short StatusId { get; set; }
    
    [Column("created_at_utc")]
    public DateTime CreatedAtUtc { get; set; }
    
    [Column("closed_at_utc")]
    public DateTime ClosedAtUtc { get; set; }
}