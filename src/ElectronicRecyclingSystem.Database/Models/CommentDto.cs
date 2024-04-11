using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicRecyclingSystem.Database.Models;

[Table("comments")]
public class CommentDto
{
    [Column("id")]
    public long Id { get; set; }
    [Column("test")]
    public required string Text { get; set; }
    [Column("user_id")]
    public long SenderId { get; set; }
    [Column("recycling_application_item_id")]
    public long RecyclingApplicationItemId { get; set; }
    [Column("sent_at")]
    public DateTime SentAt { get; set; }
}