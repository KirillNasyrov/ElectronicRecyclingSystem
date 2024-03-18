using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Controllers.DeliveryApplications.Mappings;
using ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.CreateDeliveryApplication;
using ElectronicRecyclingSystem.Controllers.DeliveryApplications.Models.GetDeliveryApplications;
using ElectronicRecyclingSystem.Domain.Services.DeliveryApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicRecyclingSystem.Controllers.DeliveryApplications;

[Route("")]
[ApiController]
public class DeliveryApplicationController : ControllerBase
{
    private readonly IDeliveryApplicationService _deliveryApplicationService;

    public DeliveryApplicationController(
        IDeliveryApplicationService deliveryApplicationService)
    {
        _deliveryApplicationService = deliveryApplicationService;
    }

    [HttpPut("applications")]
    public async Task<GetDeliveryApplicationsResponse> GetDeliveryApplications(
        [FromBody] GetDeliveryApplicationsRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.MapToModel();
        var result = await _deliveryApplicationService.GetDeliveryApplicationsAsync(query);
        return result.MapToResponse();
    }

    [HttpPost("applications")]
    public async Task<IActionResult> CreateDeliveryApplication(
        [FromBody] CreateDeliveryApplicationRequest request)
    {
        var command = request.MapToModel();
        var result = await _deliveryApplicationService.CreateDeliveryApplicationAsync(command);
        if (result.IsSuccess)
        {
            return Ok(result.DeliveryApplicationId);
        }

        return BadRequest();
    }
}