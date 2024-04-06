using ElectronicRecyclingSystem.Controllers.Common.RecyclingApplications;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Controllers.Common.Mappings;

public static class RecyclingApplicationStatusMapping
{
    public static RecyclingApplicationStatusViewModel MapToResponse(
        this RecyclingApplicationStatus status)
    {
        return (RecyclingApplicationStatusViewModel)(short)status;
    }
}