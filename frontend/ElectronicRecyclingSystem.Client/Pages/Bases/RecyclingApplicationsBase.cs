using System.Collections.Immutable;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ElectronicRecyclingSystem.Client.Pages.Bases;

public class RecyclingApplicationsBase : ComponentBase
{
    [Inject]
    public required IRecyclingApplicationService ApplicationService { get; set; }
    
    public ImmutableArray<RecyclingApplicationResponse> RecyclingApplications { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await ApplicationService.GetApplications();
        RecyclingApplications = response.RecyclingApplications;
    }
}