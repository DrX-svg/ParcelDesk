using System.Diagnostics;
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

        var executablePath = ResolveExecutablePath(settings.LocalApiExecutablePath);

        if(!File.Exists(executablePath))
        {
            error = $"ParcelDesk API executable was not found:\n" + $"{executablePath}";

            return false;
        }
        try
        {
            var workingDirectory = Path.GetDirectoryName(executablePath);

            if(string.IsNullOrWhiteSpace(workingDirectory))
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

            startInfo.Environment["ASPNETCORE_URLS"] = settings.ApiBaseUrl.TrimEnd('/');

            startInfo.Environment["Database_Provider"] = settings.DatabaseProvider;

            if(settings.DatabaseProvider.Equals(
                "Sqlite",
                StringComparison.OrdinalIgnoreCase))
            {
                if(string.IsNullOrWhiteSpace(
                    settings.SqliteDatabasePath))
                {
                    error = "SQLite database path is not configured.";
                    return false;
                }

                var databaseDirectory = Path.GetDirectoryName(settings.SqliteDatabasePath);

                if(!string.IsNullOrWhiteSpace(databaseDirectory))
                {
                    Directory.CreateDirectory(databaseDirectory);
                }

                startInfo.Environment[
                    "ConnectionStrings__ParcelDeskDb"] = $"Data Source = {settings.SqliteDatabasePath}";
            }

            if(!string.IsNullOrWhiteSpace(settings.LocalApiEnvironment))
            {
                startInfo.Environment["ASPNETCORE_ENVIRONMENT"] = settings.LocalApiEnvironment;

                startInfo.Environment["DOTNET_ENVIRONMENT"] = settings.LocalApiEnvironment;
            }

            var process = Process.Start(startInfo);

            if(process is null)
            {
                error = "The ParcelDesk API process could not be started.";
                return false;
            }
            _startedProcess = process;
            return true;
        }
        catch(Exception ex)
        {
            error = ex.Message;
            return false;
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

    public static void StopIfStarted()
    {
        if(_startedProcess is null)
        {
            return;
        }
        try
        {
            if(!_startedProcess.HasExited)
            {
                _startedProcess.Kill(entireProcessTree: true);
                _startedProcess.WaitForExit(3000);
            }
        }
        catch
        {
            //Aplication shutdown should continue even if the process cannot be stopped.
        }
        finally
        {
            _startedProcess.Dispose();
            _startedProcess = null;
        }
    }
}