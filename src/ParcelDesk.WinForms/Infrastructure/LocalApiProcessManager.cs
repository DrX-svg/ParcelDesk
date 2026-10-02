using System.Diagnostics;
using ParcelDesk.WinForms.Configuration;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms.Infrastructure;

public static class LocalApiProcessManager
{
    private static Process? _startedProcess;
    public static bool TryStart(ClientSettings settings, out string? error)
    {
        error = null;
        if(!settings.AutoStartLocalApi)
        {
            error = "Automatic local API startup is disabled.";

            return false;
        }

        string connectionString;
        if(settings.DatabaseProvider.Equals(
            "Sqlite",
            StringComparison.OrdinalIgnoreCase))
        {
            if(string.IsNullOrWhiteSpace(settings.SqliteDatabasePath))
            {
                error = "SQLite database path is not configured.";
                return false;
            }

            var databaseDirectory = Path.GetDirectoryName(settings.SqliteDatabasePath);

            if(!string.IsNullOrWhiteSpace(databaseDirectory))
            {
                Directory.CreateDirectory(databaseDirectory);
            }

            connectionString = $"Data Source = {settings.SqliteDatabasePath}";
        }
        else if(
            settings.DatabaseProvider.Equals(
                "MySql",
                StringComparison.OrdinalIgnoreCase))
        {
            var password = MySqlSecretStore.LoadPassword();

            if(string.IsNullOrWhiteSpace(password))
            {
                error = "The saved MySQL password could not be loaded.";
                return false;
            }

            if(string.IsNullOrWhiteSpace(
                settings.MySqlServer) ||
                string.IsNullOrWhiteSpace(
                settings.MySqlDatabase) ||
               string.IsNullOrWhiteSpace(
                settings.MySqlUsername))
            {
                error = "MySQL configuration is incomplete.";
                return false;
            }
            connectionString = MySqlConnectionStringFactory.Build(
                settings.MySqlServer,
                settings.MySqlPort,
                settings.MySqlDatabase,
                settings.MySqlUsername,
                password);
        }
        else
        {
            error = $"Unsupported database provider: {settings.DatabaseProvider}";
            return false;
        }

        var started = TryStartProcess(
            settings,
            settings.ApiBaseUrl,
            settings.DatabaseProvider,
            connectionString,
            autoMigrate: true,
            out var process,
            out error);

        if(!started)
        {
            return false;
        }

        _startedProcess = process;
        return true;
    }

    public static bool TryStartForDatabaseTest(
        ClientSettings settings,
        string apiBaseUrl,
        string databaseProvider,
        string connectionString,
        out Process? process,
        out string? error)
    {
        return TryStartProcess(
            settings,
            apiBaseUrl,
            databaseProvider,
            connectionString,
            autoMigrate: false,
            out process,
            out error);
    }

    private static bool TryStartProcess(
        ClientSettings settings,
        string apiBaseUrl,
        string databaseProvider,
        string connectionString,
        bool autoMigrate,
        out Process? process,
        out string? error)
    {
        process = null;
        error = null;

        var executablePath = ResolveExecutablePath(
            settings.LocalApiExecutablePath);

        if(!File.Exists(executablePath))
        {
            error = $"ParcelDesk API executable was not found:\n{executablePath}";
            return false;
        }

        try
        {
            var workingDirectory = Path.GetDirectoryName(executablePath);

            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                error = "The API working directory could not be determined.";
                return false;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = executablePath,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            startInfo.Environment["ASPNETCORE_URLS"] = apiBaseUrl.TrimEnd('/');
            startInfo.Environment["Database__Provider"] = databaseProvider;
            startInfo.Environment["Database__AutoMigrate"] = autoMigrate ? "true" : "false";
            startInfo.Environment["ConnectionStrings__ParcelDeskDb"] = connectionString;

            if(!string.IsNullOrWhiteSpace(
                settings.LocalApiEnvironment))
            {
                startInfo.Environment["ASPNETCORE_ENVIRONMENT"] = settings.LocalApiEnvironment;
                startInfo.Environment["DOTNET_ENVIRONMENT"] = settings.LocalApiEnvironment;
            }
            process = Process.Start(startInfo);

            if(process is null)
            {
                error = "The ParcelDesk API process could not be started.";
                return false;
            }
            return true;
        }
        catch(Exception ex)
        {
            error = ex.Message;
            return false;
        }
    }

    public static void StopIfStarted()
    {
        StopProcess(_startedProcess);
        _startedProcess = null;
    }

    public static void StopProcess(Process? process)
    {
        if(process is null)
        {
            return;
        }
        try
        {
            if(!process.HasExited)
            {
                process.Kill(entireProcessTree: true);
                process.WaitForExit(3000);
            }
        }
        catch
        {
            //Aplication shutdown should continue even if the process cannot be stopped.
        }
        finally
        {
            process.Dispose();
        }
        
    }
    private static string ResolveExecutablePath(string configuredPath)
    {
        if (Path.IsPathRooted(configuredPath))
        {
            return Path.GetFullPath(configuredPath);
        }

        return Path.GetFullPath(Path.Combine(
                                            AppContext.BaseDirectory,
                                            configuredPath));
    }
}