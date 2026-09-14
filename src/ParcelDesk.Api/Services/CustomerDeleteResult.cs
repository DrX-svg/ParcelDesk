namespace ParcelDesk.Api.Services;

public enum CustomerDeleteResult
{
    Deleted,
    NotFound,
    HasShipments
}