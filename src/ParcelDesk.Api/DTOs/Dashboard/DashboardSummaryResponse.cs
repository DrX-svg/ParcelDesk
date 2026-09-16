namespace ParcelDesk.Api.DTOs.Dashboard;

public class DashboardSummaryResponse
{
    public int TotalShipments { get; set; }

    public int Created { get; set; }

    public int PickedUp { get; set; }

    public int InTransit { get; set; }

    public int Delivered { get; set; }

    public int Cancelled { get; set; }
}