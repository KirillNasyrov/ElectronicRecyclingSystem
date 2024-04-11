using System.Collections.Immutable;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetCommentsByRecyclingApplicationItem;

public record GetCommentsByRecyclingApplicationItemResult(
    ImmutableArray<Comment> Comments,
    ImmutableArray<User> Users);