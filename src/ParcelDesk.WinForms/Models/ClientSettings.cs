namespace ParcelDesk.WinForms.Models;

public class ClientSettings
{
    public string ApiBaseUrl {get; set;} = "http://localhost:5000";

    public bool AutoStartLocalApi { get; set; } = true;

    public string LocalApiExecutablePath { get; set; } = @"..\Api\ParcelDesk.Api.exe";

    public string LocalApiEnvironment { get; set; } = "Production";
}