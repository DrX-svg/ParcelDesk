using System.Net.Http.Json;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms.Api;

public class ParcelDeskApiClient
{
    private readonly HttpClient _httpClient;
    public ParcelDeskApiClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000/")
        };
    }
    public async Task<DashboardSummary?> GetDashboardSummaryAsync()
    {
        return await _httpClient.GetFromJsonAsync<DashboardSummary>(
            "api/dashboard/summary");
    }
}