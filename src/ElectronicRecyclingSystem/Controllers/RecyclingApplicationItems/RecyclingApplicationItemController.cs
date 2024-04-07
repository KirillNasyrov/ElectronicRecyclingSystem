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
        var result = await _recyclingApplicationItemService.AddRecyclingApplicationToApplication(
            command,
            cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.RecyclingApplicationItemId);
        }

        return BadRequest();
    }
}