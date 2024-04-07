using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Mappings;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.CreateRecyclingApplication;
using ElectronicRecyclingSystem.Controllers.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplications;

[Route("applications")]
[ApiController]
public class RecyclingApplicationController : ControllerBase
{
    private readonly IRecyclingApplicationService _recyclingApplicationService;

    public RecyclingApplicationController(
        IRecyclingApplicationService recyclingApplicationService)
    {
        _recyclingApplicationService = recyclingApplicationService;
    }

    [HttpPut("")]
    public async Task<GetRecyclingApplicationsResponse> GetRecyclingApplications(
        [FromBody] GetRecyclingApplicationsRequest request,
        CancellationToken cancellationToken)
    {
        var query = request.MapToModel();
        var result = await _recyclingApplicationService.GetRecyclingApplicationsAsync(query, cancellationToken);
        return result.MapToResponse();
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateRecyclingApplication(
        [FromBody] CreateRecyclingApplicationRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel();
        var result = await _recyclingApplicationService.CreateRecyclingApplicationAsync(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.RecyclingApplicationId);
        }

        return BadRequest();
    }
    
    [HttpGet("{id:long}")]
    public async Task<RecyclingApplicationResponse> GetRecyclingApplication(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _recyclingApplicationService.GetRecyclingApplicationAsync(id, cancellationToken);
        return result.MapToResponse();
    }
}