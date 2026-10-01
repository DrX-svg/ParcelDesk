using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Configuration;
using ParcelDesk.WinForms.Infrastructure;
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

        btnTestMySqlConnection.Click += btnTestMySqlConnection_Click;
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

    private async void btnContinue_Click(object? sender, EventArgs e)
    {
        if(rdoLocalStandalone.Checked)
        {
            ConfigureLocalStandalone();

            return;
        }

        await ConfigureExistingMySqlAsync();
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

        MySqlSecretStore.DeletePassword();

        ClientSettingsStore.Save(_settings);

        DialogResult = DialogResult.OK;

        Close();
    }

    private async Task ConfigureExistingMySqlAsync()
    {
        if(!TryGetMySqlInput(
            out var server,
            out var port,
            out var database,
            out var username,
            out var password))
        {
            return;
        }
        var connectionWorks = await TestMySqlConnectionAsync(showSuccessMessage: false);
        if(!connectionWorks)
        {
            return;
        }
        try
        {
            MySqlSecretStore.SavePassword(password);
            _settings.DatabaseProvider = "MySql";
            _settings.SqliteDatabasePath = null;
            _settings.MySqlServer = server;
            _settings.MySqlPort = port;
            _settings.MySqlDatabase = database;
            _settings.MySqlUsername = username;
            _settings.IsConfigured = true;
            ClientSettingsStore.Save(_settings);
            DialogResult = DialogResult.OK;

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"MySQL configuration could not be saved.\n\n" +
                $"{ex.Message}",
                "ParcelDesk Setup",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
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

    private bool TryGetMySqlInput(
        out string server,
        out int port,
        out string database,
        out string username,
        out string password)
    {
        server = txtMySqlServer.Text.Trim();
        port = (int)nudMySqlPort.Value;
        database = txtMySqlDatabase.Text.Trim();
        username = txtMySqlUsername.Text.Trim();
        password = txtMySqlPassword.Text;

        if(string.IsNullOrWhiteSpace(server))
        {
            ShowValidation(
                "MySQL server is required.");
            return false;
        }

        if(string.IsNullOrWhiteSpace(database))
        {
            ShowValidation(
                "Database name is required.");
            return false;
        }

        if(string.IsNullOrWhiteSpace(username))
        {
            ShowValidation(
                "Username is required.");
            return false;
        }

        if(string.IsNullOrWhiteSpace(password))
        {
            ShowValidation(
                "Password is required.");
            return false;
        }
        return true;
    }

    private static int GetAvailablePort()
    {
        var listener = new TcpListener(
            IPAddress.Loopback,
            0);

        listener.Start();

        var port = ((IPEndPoint)
            listener.LocalEndpoint).Port;

        listener.Stop();
        return port;
    }

    private async void btnTestMySqlConnection_Click(object? sender, EventArgs e)
    {
        await TestMySqlConnectionAsync(
            showSuccessMessage: true);
    }

    private async Task<bool>
        TestMySqlConnectionAsync(
        bool showSuccessMessage)
    {
        if(!TryGetMySqlInput(
            out var server,
            out var port,
            out var database,
            out var username,
            out var password))
        {
            return false;
        }

        btnTestMySqlConnection.Enabled = false;

        btnContinue.Enabled = false;

        Process? testProcess = null;

        try
        {
            var connectionString = MySqlConnectionStringFactory.Build(
                server,
                port,
                database,
                username,
                password);
            var testPort = GetAvailablePort();

            var testApiBaseUrl = $"http://127.0.0.1:{testPort}/";

            var started = LocalApiProcessManager
                .TryStartForDatabaseTest(
                    _settings,
                    testApiBaseUrl,
                    "MySql",
                    connectionString,
                    out testProcess,
                    out var startError);

            if(!started)
            {
                MessageBox.Show(
                    $"The database test could not start.\n\n" +
                    $"{startError}",
                    "ParcelDesk Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            var testClient = new ParcelDeskApiClient(
                testApiBaseUrl);

            var apiStarted = await testClient
                .WaitUntilHealthyAsync(
                TimeSpan.FromSeconds(8));

            if(!apiStarted)
            {
                MessageBox.Show(
                    "The temporary ParcelDesk API could not be started.",
                    "ParcelDesk Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var databaseHealthy = await testClient
                .IsDatabaseHealthyAsync(
                TimeSpan.FromSeconds(8));

            if(!databaseHealthy)
            {
                MessageBox.Show(
                    "Could not connect to the MySQL database.\n\nCheck the server, port, database, username and password.",
                    "ParcelDesk Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if(showSuccessMessage)
            {
                MessageBox.Show(
                    "Connection successful.",
                    "ParcelDesk Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            return true;
        }
        finally
        {
            LocalApiProcessManager
                .StopProcess(
                testProcess);

            btnTestMySqlConnection.Enabled = true;
            btnContinue.Enabled = true;
        }
    }
}
