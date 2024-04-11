using System.Collections.Immutable;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Client.Contracts.Comments;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ElectronicRecyclingSystem.Client.Components.Bases;

public class RecyclingApplicationItemDetailsBase : ComponentBase
{
    [Inject]
    public required IRecyclingApplicationService ApplicationService { get; set; }
    
    [Parameter]
    public RecyclingApplicationItemResponse RecyclingApplicationItem { get; set; } = null!;
    
    public ImmutableArray<CommentResponse>? Comments { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        Comments = await GetComments();
    }
    
    
    async Task<ImmutableArray<CommentResponse>> GetComments()
    {
        return await ApplicationService.GetCommentsByApplicationItem(RecyclingApplicationItem.Id);
    }
}