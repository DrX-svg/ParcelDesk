using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Models;
using System.Text.Json;

namespace ParcelDesk.WinForms;

public partial class MainForm : Form
{
    private readonly ParcelDeskApiClient _apiClient;

    public MainForm()
    {
        InitializeComponent();

        cmbShipmentStatus.Items.AddRange(
            [
                "All",
                "Created",
                "PickedUp",
                "InTransit",
                "Delivered",
                "Cancelled"
            ]);

        cmbShipmentStatus.SelectedIndex = 0;

        _apiClient = new ParcelDeskApiClient();
        Load += MainForm_Load;
        btnRefresh.Click += buttonRefresh_Click;
        btnDashboard.Click += btnDashboard_Click;
        btnShipments.Click += btnShipments_Click;

        btnShipmentRefresh.Click += btnShipmentRefresh_Click;

        txtShipmentsSearch.KeyDown += ShipmentFilters_KeyDown;
        cmbShipmentStatus.KeyDown += ShipmentFilters_KeyDown;

        FormClosing += MainForm_FormClosing;
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        SaveShipmentGridSettings();
    }

    private void ShipmentFilters_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;
        e.SuppressKeyPress = true;
        btnShipmentRefresh.PerformClick();
    }

    private async void btnDashboard_Click(object? sender, EventArgs e)
    {
        shipmentsPanel.Visible = false;
        dashboardPanel.Visible = true;

        await LoadDashboardAsync();
    }

    private async void btnShipments_Click(object? sender, EventArgs e)
    {
        dashboardPanel.Visible = false;
        shipmentsPanel.Visible = true;
        await LoadShipmentsAsync();
    }

    private async void btnShipmentRefresh_Click(object? sender, EventArgs e)
    {
        await LoadShipmentsAsync();
    }

    private async Task LoadShipmentsAsync()
    {
        try
        {
            btnShipmentRefresh.Enabled = false;

            var search = txtShipmentsSearch.Text;

            var selectedStatus = cmbShipmentStatus.SelectedItem?.ToString();

            var status = selectedStatus == "All" ? null : selectedStatus;

            var shipments = await _apiClient.GetShipmentsAsync(search, status);

            dgvShipments.DataSource = shipments;

            ConfigureShipmentsGrid();

        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"API request failed.\n\nStatus: {ex.StatusCode}\n{ex.Message}",
                "API Connection Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnShipmentRefresh.Enabled = true;
        }
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        await LoadDashboardAsync();
    }

    private async void buttonRefresh_Click(object? sender, EventArgs e)
    {
        await LoadDashboardAsync();
    }

    private async Task LoadDashboardAsync()
    {
        try
        {
            btnRefresh.Enabled = false;

            var summary = await _apiClient.GetDashboardSummaryAsync();

            if (summary is null)
            {
                MessageBox.Show(
                    "Dashboard data could not be loaded.",
                    "ParcelDesk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            lblTotalShipmentsValue.Text = summary.TotalShipments.ToString();

            lblCreatedValue.Text = summary.Created.ToString();

            lblPickedUpValue.Text = summary.PickedUp.ToString();

            lblInTransitValue.Text = summary.InTransit.ToString();

            lblDeliveredValue.Text = summary.Delivered.ToString();

            lblCancelledValue.Text = summary.Cancelled.ToString();
        }
        catch (HttpRequestException)
        {
            MessageBox.Show(
                "The ParcelDesk API is unavailable.",
                "Connection Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnRefresh.Enabled = true;
        }
    }

    private void lblShipments_Click(object sender, EventArgs e)
    {

    }

    private void ConfigureShipmentsGrid()
    {
        ////dgvShipments.Columns[nameof(Shipment.CustomerId)].Visible = false;
        //dgvShipments.Columns[nameof(Shipment.SenderAddress)].Visible = false;
        //dgvShipments.Columns[nameof(Shipment.UpdatedAtUtc)].Visible = false;
        ////dgvShipments.Columns[nameof(Shipment.Notes)].Visible = false;

        dgvShipments.Columns[nameof(Shipment.Awb)].HeaderText = "AWB";
        dgvShipments.Columns[nameof(Shipment.CustomerName)].HeaderText = "Customer";
        //dgvShipments.Columns[nameof(Shipment.CustomerId)].HeaderText = "Customer ID";
        dgvShipments.Columns[nameof(Shipment.DestinationAddress)].HeaderText = "Destination";
        dgvShipments.Columns[nameof(Shipment.CreatedAtUtc)].HeaderText = "Created At";
        dgvShipments.Columns[nameof(Shipment.Notes)].HeaderText = "Notes";
        //dgvShipments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

        var settingsLoaded = LoadShipmentGridSettings();

        if(!settingsLoaded)
        {
            dgvShipments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }

    private readonly string _shipmentGridSettingsPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ParcelDesk",
            "shipment-grid-colums.json");

    private void SaveShipmentGridSettings()
    {
        var widths = new Dictionary<string, int>();

        foreach (DataGridViewColumn column in dgvShipments.Columns)
        {
            var key = string.IsNullOrWhiteSpace(column.DataPropertyName)
                ? column.Name
                : column.DataPropertyName;
            widths[key] = column.Width;
        }

        var directory = Path.GetDirectoryName(_shipmentGridSettingsPath);

        if (directory is not null)
        {
            Directory.CreateDirectory(directory);
        }

        var json = JsonSerializer.Serialize(
            widths,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(
            _shipmentGridSettingsPath,
            json);
    }

    private bool LoadShipmentGridSettings()
    {
        if (!File.Exists(_shipmentGridSettingsPath))
        {
            return false;
        }

        try
        {
            var json = File.ReadAllText(_shipmentGridSettingsPath);

            var widths = JsonSerializer.Deserialize<Dictionary<string, int>>(json);

            if (widths is null)
            {
                return false;
            }

            foreach (DataGridViewColumn column in dgvShipments.Columns)
            {
                var key = string.IsNullOrWhiteSpace(column.DataPropertyName)
                    ? column.Name
                    : column.DataPropertyName;


                if (widths.TryGetValue(key, out var width))
                {
                    column.Width = width;
                }
            }
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
        catch (IOException)
        {
            return false;
        }
    }
}
