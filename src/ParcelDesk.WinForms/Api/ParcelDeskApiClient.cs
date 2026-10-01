using ParcelDesk.WinForms.Models;
using System.Net.Http.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParcelDesk.WinForms.Api;

public class ParcelDeskApiClient
{
    private readonly HttpClient _httpClient;
    public ParcelDeskApiClient(string apiBaseUrl)
    {
        if (string.IsNullOrWhiteSpace(apiBaseUrl))
        {
            throw new ArgumentException(
                "API base URL cannot be empty",
                nameof(apiBaseUrl));
        }

        if (!Uri.TryCreate(
            apiBaseUrl,
            UriKind.Absolute,
            out var baseUri))
        {
            throw new ArgumentException(
                "API base URL is invalid.",
                nameof(apiBaseUrl));
        }

        if (baseUri.Scheme != Uri.UriSchemeHttp && 
            baseUri.Scheme != Uri.UriSchemeHttps)
        {
            throw new ArgumentException(
                "API base URL must use HTTP or HTTPS.",
                nameof(apiBaseUrl));
        }

        _httpClient = new HttpClient
        {
            BaseAddress = baseUri
        };
    }
    
    public async Task<DashboardSummary?> GetDashboardSummaryAsync()
    {
        return await _httpClient.GetFromJsonAsync<DashboardSummary>(
            "api/dashboard/summary");
    }

    public async Task<List<Shipment>> GetShipmentsAsync(
        string? search = null,
        string? status = null,
        int? customerId = null)
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

        if (customerId.HasValue)
        {
            queryParameters.Add(
                $"customerId={customerId.Value}");
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

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers") ?? new List<Customer>();
    }

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Customer>(
            $"api/customers/{id}");
    }

    public async Task<Customer?> CreateCustomerAsync(
        CreateCustomerRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"api/customers", request);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Customer>();
    }

    public async Task<Customer?> UpdateCustomerAsync(int id, UpdateCustomerRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"api/customers/{id}",
            request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Customer>();
    }

    public async Task<Shipment?> CreateShipmentAsync(
        CreateShipmentRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/shipments",
            request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Shipment>();
    }

    public async Task<bool> IsApiHealthyAsync(TimeSpan? timeout = null)
    {
        using var cancellationTokenSource = new CancellationTokenSource(timeout?? TimeSpan.FromSeconds(2));

        try
        {
            var response = await _httpClient.GetAsync(
                "api/health",
                cancellationTokenSource.Token);

            if(!response.IsSuccessStatusCode)
            {
                return false;
            }

            var health = await response.Content
                                            .ReadFromJsonAsync<HealthResponse>(
                                                                               cancellationToken: cancellationTokenSource.Token);

            return string.Equals(
                    health?.Status,
                    "ok",
                    StringComparison.OrdinalIgnoreCase);
        }
        catch (HttpRequestException)
        {
            return false;
        }
        catch (OperationCanceledException)
        {
            return false;
        }
    }

    public async Task<bool> WaitUntilHealthyAsync(TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;

        while (DateTime.UtcNow < deadline)
        {
            var healthy = await IsApiHealthyAsync(TimeSpan.FromMilliseconds(750));

            if(healthy)
            {
                return true;
            }
            await Task.Delay(250);
        }
        return false;
    }

}