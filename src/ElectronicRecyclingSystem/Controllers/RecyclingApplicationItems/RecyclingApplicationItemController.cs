using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Mappings;
using ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Domain.Services.RecyclingApplicationItemService;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicRecyclingSystem.Controllers.RecyclingApplicationItems;

[ApiController]
public class RecyclingApplicationItemController : ControllerBase
{
    private readonly IRecyclingApplicationItemService _recyclingApplicationItemService;

    public RecyclingApplicationItemController(IRecyclingApplicationItemService recyclingApplicationItemService)
    {
        _recyclingApplicationItemService = recyclingApplicationItemService;
    }
    
    [HttpPost("applications/{recyclingApplicationId:long}")]
    public async Task<IActionResult> AddRecyclingApplicationItemToApplication(
        [FromRoute] long recyclingApplicationId,
        [FromBody] AddRecyclingApplicationItemToApplicationRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.MapToModel(recyclingApplicationId);
        var result = await _recyclingApplicationItemService.AddRecyclingApplicationItemToApplication(
            command,
            cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.RecyclingApplicationItemId);
        }

        return BadRequest();
    }
    
    [HttpGet("application-items/{recyclingApplicationItemId:long}")]
    public async Task<IActionResult> GetRecyclingApplicationItem(
        [FromRoute] long recyclingApplicationItemId,
        CancellationToken cancellationToken)
    {
        var result = await _recyclingApplicationItemService.GetRecyclingApplicationItem(
            recyclingApplicationItemId,
            cancellationToken);

        return Ok(result.MapToResponse());
    }
    
    [HttpGet("applications/{recyclingApplicationId:long}/application-items")]
    public async Task<IActionResult> GetRecyclingApplicationItems(
        [FromRoute] long recyclingApplicationId,
        CancellationToken cancellationToken)
    {
        var result = await _recyclingApplicationItemService.GetRecyclingApplicationItems(
            recyclingApplicationId,
            cancellationToken);

        return Ok(result.MapToResponse());
    }
}