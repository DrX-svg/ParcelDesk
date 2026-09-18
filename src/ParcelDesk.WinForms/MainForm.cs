using ParcelDesk.WinForms.Api;

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
}
