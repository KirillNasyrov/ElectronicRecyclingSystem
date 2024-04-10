using System;
using System.Collections.Immutable;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplicationItems.Models;
using ElectronicRecyclingSystem.Client.Contracts.RecyclingApplications.Models.GetRecyclingApplications;

namespace ElectronicRecyclingSystem.Client.Services;

public class RecyclingApplicationService : IRecyclingApplicationService
{
    private readonly HttpClient _httpClient;
    public RecyclingApplicationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetRecyclingApplicationsResponse> GetApplications()
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync("applications", new object());
            var applications = await response.Content.ReadFromJsonAsync<GetRecyclingApplicationsResponse>();
            return applications!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<RecyclingApplicationResponse> GetApplication(long id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"applications/{id}");
            var application = await response.Content.ReadFromJsonAsync<RecyclingApplicationResponse>();
            return application!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ImmutableArray<RecyclingApplicationItemResponse>> GetRecyclingApplicationItem(long applicationId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"applications/{applicationId}/application-items");
            var applicationItems = await response.Content
                .ReadFromJsonAsync<GetRecyclingApplicationItemsResponse>();

            return applicationItems!.RecyclingApplicationItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}