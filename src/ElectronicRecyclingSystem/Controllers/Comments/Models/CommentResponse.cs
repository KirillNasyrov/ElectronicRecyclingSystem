using System;

namespace ElectronicRecyclingSystem.Controllers.Comments.Models;

public record CommentResponse(
    string Text,
    long SenderId,
    DateTime SentAt,
    string Name,
    string Surname);