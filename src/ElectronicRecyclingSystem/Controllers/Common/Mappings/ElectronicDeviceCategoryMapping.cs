using ElectronicRecyclingSystem.Controllers.Common.ElectronicDevices;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.Common.Mappings;

public static class ElectronicDeviceCategoryMapping
{
    public static ElectronicDeviceCategory MapToModel(
        this ElectronicDeviceCategoryViewModel status)
    {
        return (ElectronicDeviceCategory)(short)status;
    }
}