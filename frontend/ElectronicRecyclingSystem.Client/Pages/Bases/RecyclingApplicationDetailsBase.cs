using System;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.GetRecyclingApplications;
using ElectronicRecyclingSystem.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ElectronicRecyclingSystem.Client.Pages.Bases;

public class RecyclingApplicationDetailsBase : ComponentBase
{
    [Inject]
    public required IRecyclingApplicationService ApplicationService { get; set; }
    [Parameter]
    public long RecyclingApplicationId { get; set; }
    public RecyclingApplicationResponse? Application { get; set; }
    public string ErrorMessage { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Application = await ApplicationService.GetApplication(RecyclingApplicationId);
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }
}