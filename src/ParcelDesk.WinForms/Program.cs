using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Configuration;

namespace ParcelDesk.WinForms;
static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var settings = ClientSettingsStore.LoadOrCreate();

        if(!settings.IsConfigured)
        {
            using var setupForm = new FirstRunSetupForm(settings);
            var result = setupForm.ShowDialog();
            if(result != DialogResult.OK)
            {
                return;
            }

            settings = ClientSettingsStore.LoadOrCreate();
        }

        ParcelDeskApiClient apiClient;

        try
        {
            apiClient = new ParcelDeskApiClient(settings.ApiBaseUrl);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                $"ParcelDesk configuration is invalid.\n\n"+
                $"{ex.Message}",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
        }
        Application.Run(
            new MainForm(
                apiClient, 
                settings));
    }    
}