using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetRecyclingApplicationItem;

public record GetRecyclingApplicationItemResult(
    RecyclingApplicationItem RecyclingApplicationItem,
    ElectronicDevice ElectronicDevice);