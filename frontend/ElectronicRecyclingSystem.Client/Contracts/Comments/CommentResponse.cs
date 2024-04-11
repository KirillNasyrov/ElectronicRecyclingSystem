using System;

namespace ElectronicRecyclingSystem.Client.Contracts.Comments;

public record CommentResponse(
    string Text,
    long SenderId,
    DateTime SentAt,
    string Name,
    string Surname);