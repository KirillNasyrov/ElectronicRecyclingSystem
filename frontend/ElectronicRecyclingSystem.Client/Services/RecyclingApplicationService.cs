using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
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
            //var applications = await _httpClient.GetFromJsonAsync<GetRecyclingApplicationsResponse>("applications");
            var applications = await response.Content.ReadFromJsonAsync<GetRecyclingApplicationsResponse>();
            return applications!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}