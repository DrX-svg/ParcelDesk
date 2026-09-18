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

public async Task<List<Shipment>> GetShipmentsAsync(
    string? search = null,
    string? status = null)
    {
        var queryParameters = new List<string>();

        if (!string.IsNullOrWhiteSpace(search))
        {
            queryParameters.Add($"search={Uri.EscapeDataString(search.Trim())}");
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            queryParameters.Add($"status={Uri.EscapeDataString(status.Trim())}");
        }

        var url = "api/shipments";

        if (queryParameters.Count > 0)
        {
            url += "?" + string.Join("&", queryParameters);
        }

        return await _httpClient.GetFromJsonAsync<List<Shipment>>(url) ?? new List<Shipment>();
    } 
}