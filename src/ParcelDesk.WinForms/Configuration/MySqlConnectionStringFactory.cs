using System.Data.Common;

namespace ParcelDesk.WinForms.Configuration;

public static class MySqlConnectionStringFactory
{
    public static string Build(
        string server,
        int port,
        string database,
        string username,
        string password)
    {
        var builder = new DbConnectionStringBuilder
        {
            ["Server"] = server,
            ["Port"] = port,
            ["Database"] = database,
            ["User Id"] = username,
            ["Password"] = password,
            ["SslMode"] = "Preferred"
        };
        return builder.ConnectionString;
    }
}