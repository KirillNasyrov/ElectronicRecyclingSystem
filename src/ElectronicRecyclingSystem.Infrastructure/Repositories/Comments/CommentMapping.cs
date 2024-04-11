using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.Comments;

public static class CommentMapping
{
    public static Comment MapToModel(
        this CommentDto dto)
    {
        return new Comment
        (
            dto.Id,
            dto.Text,
            dto.SenderId,
            dto.RecyclingApplicationItemId,
            dto.SentAt
        );
    }
    
    public static CommentDto MapToDto(
        this Comment model)
    {
        return new CommentDto
        {
            Id = model.Id,
            Text = model.Text,
            SenderId = model.SenderId,
            RecyclingApplicationItemId = model.RecyclingApplicationItemId,
            SentAt = model.SentAt
        };
    }
}