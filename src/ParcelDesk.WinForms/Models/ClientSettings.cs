namespace ParcelDesk.WinForms.Models;

public class ClientSettings
{
    public bool IsConfigured { get; set; } = false;
    public string ApiBaseUrl {get; set;} = "http://localhost:5000";
    public bool AutoStartLocalApi { get; set; } = true;
    public string LocalApiExecutablePath { get; set; } = @"..\Api\ParcelDesk.Api.exe";
    public string LocalApiEnvironment { get; set; } = "Production";
    public string DatabaseProvider { get; set; } = "Sqlite";
    public string? SqliteDatabasePath { get; set; }
    public string? MySqlServer { get; set; }
    public int MySqlPort { get; set; } = 3306;
    public string? MySqlDatabase { get; set; }
    public string? MySqlUsername { get; set; }
}