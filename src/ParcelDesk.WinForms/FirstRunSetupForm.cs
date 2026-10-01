using ParcelDesk.WinForms.Configuration;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms;

public partial class FirstRunSetupForm : Form
{
    private readonly ClientSettings _settings;
    public FirstRunSetupForm(ClientSettings settings)
    {
        InitializeComponent();

        _settings = settings;

        rdoLocalStandalone.Checked = true;
        UpdateDatabasePanels();

        rdoLocalStandalone.CheckedChanged += DatabaseMode_CheckedChanged;

        rdoExistingMySql.CheckedChanged += DatabaseMode_CheckedChanged;

        btnContinue.Click += btnContinue_Click;

        btnCancelSetup.Click += btnCancelSetup_Click;
    }

    private void DatabaseMode_CheckedChanged(object? sender, EventArgs e)
    {
        UpdateDatabasePanels();
    }

    private void UpdateDatabasePanels()
    {
        pnlLocalStandalone.Visible = rdoLocalStandalone.Checked;
        pnlMySql.Visible = rdoExistingMySql.Checked;
    }

    private void btnContinue_Click(object? sender, EventArgs e)
    {
        if(rdoLocalStandalone.Checked)
        {
            ConfigureLocalStandalone();

            return;
        }

        ConfigureExistingMySql();
    }

    private void ConfigureLocalStandalone()
    {
        var dataDirectory = Path.Combine(Environment.GetFolderPath(
                                                                Environment.SpecialFolder.LocalApplicationData),
                                                                "ParcelDesk",
                                                                "Data");

        Directory.CreateDirectory(dataDirectory);

        var databasePath = Path.Combine(dataDirectory, "parceldesk.db");

        _settings.DatabaseProvider = "Sqlite";

        _settings.SqliteDatabasePath = databasePath;

        _settings.MySqlServer = null;

        _settings.MySqlDatabase = null;

        _settings.MySqlUsername = null;

        _settings.IsConfigured = true;

        ClientSettingsStore.Save(_settings);

        DialogResult = DialogResult.OK;

        Close();
    }

    private void ConfigureExistingMySql()
    {
        if(string.IsNullOrWhiteSpace(txtMySqlServer.Text))
        {
            ShowValidation("MySQL server is required.");
            return;
        }

        if(string.IsNullOrWhiteSpace(txtMySqlDatabase.Text))
        {
            ShowValidation("Database name is required.");
            return;
        }

        if(string.IsNullOrWhiteSpace(txtMySqlUsername.Text))
        {
            ShowValidation("Username is required.");
            return;
        }

        if(string.IsNullOrWhiteSpace(txtMySqlPassword.Text))
        {
            ShowValidation("Password is required.");
            return;
        }

        MessageBox.Show(
            "MySQL setup will be enabled in the next configuration step.",
            "ParcelDesk",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private static void ShowValidation(string message)
    {
        MessageBox.Show(
            message,
            "ParcelDesk Setup",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    private void btnCancelSetup_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;

        Close();
    }
}
