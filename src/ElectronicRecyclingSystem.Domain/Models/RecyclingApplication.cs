using System;

namespace ElectronicRecyclingSystem.Domain.Models;

public record RecyclingApplication(
    long? Id,
    long UserId,
    RecyclingApplicationStatus Status,
    DateTime CreatedAtUtc,
    DateTime? ClosedAtUtc);