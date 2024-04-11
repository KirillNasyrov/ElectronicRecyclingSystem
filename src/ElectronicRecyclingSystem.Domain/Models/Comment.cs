using System;

namespace ElectronicRecyclingSystem.Domain.Models;

public record Comment(
    long Id,
    string Text,
    long SenderId,
    long RecyclingApplicationItemId,
    DateTime SentAt);