using System.Text.Json;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms.Configuration;

public static class ClientSettingsStore
{
    private static readonly string SettingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"ParcelDesk");

    private static readonly string SettingsPath = Path.Combine(SettingsDirectory, "client-settings.json");

    public static ClientSettings LoadOrCreate()
    {
        Directory.CreateDirectory(SettingsDirectory);
        if(!File.Exists(SettingsPath))
        {
            var defaultSettings = new ClientSettings();
            Save(defaultSettings);
            return defaultSettings;
        }
        try
        {
            var json = File.ReadAllText(SettingsPath);
            var settings = JsonSerializer.Deserialize<ClientSettings>(json);
            if(settings is null || string.IsNullOrWhiteSpace(settings.ApiBaseUrl))
            {
                return CreateDefaultSettings();
            }
            return settings;
        }
        catch (JsonException)
        {
            return CreateDefaultSettings();
        }
        catch (IOException)
        {
            return CreateDefaultSettings();
        }
    }

    public static void Save(ClientSettings settings)
    {
        Directory.CreateDirectory(SettingsDirectory);
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(SettingsPath, json);
    }

    private static ClientSettings CreateDefaultSettings()
    {
        var settings = new ClientSettings();
        Save(settings);
        return settings;
    }
}