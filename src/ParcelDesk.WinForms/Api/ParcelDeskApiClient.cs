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

    public async Task<Shipment?> GetShipmentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Shipment>(
                $"api/shipments/{id}");
        }

    public async Task<Shipment?> UpdateShipmentAsync(
        int id,
        UpdateShipmentRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/shipments/{id}",
                request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Shipment>();
        }

    public async Task<List<ShipmentStatusHistory>> GetShipmentHistoryAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<List<ShipmentStatusHistory>>(
            $"api/shipments/{id}/history") ?? new List<ShipmentStatusHistory>();
    }

    public async Task<Shipment?> ChangeShipmentStatusAsync(
        int id,
        string status)
    {
        var request = new UpdateShipmentStatusRequest
        {
            Status = status
        };
        var response = await _httpClient.PatchAsJsonAsync(
            $"api/shipments/{id}/status",
            request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Shipment>();
    }
}