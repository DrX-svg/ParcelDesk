using System.Diagnostics;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms.Infrastructure;

public static class LocalApiProcessManager
{
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
}