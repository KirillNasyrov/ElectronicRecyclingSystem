using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Features.GetElectronicDevice;

public record GetElectronicDeviceResult(
    ElectronicDevice? ElectronicDevice);