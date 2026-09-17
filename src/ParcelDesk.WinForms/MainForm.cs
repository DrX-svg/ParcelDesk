using ParcelDesk.WinForms.Api;

namespace ParcelDesk.WinForms;

public partial class MainForm : Form
{
    private readonly ParcelDeskApiClient _apiClient;

    public MainForm()
    {
        InitializeComponent();
        _apiClient = new ParcelDeskApiClient();
        Load += MainForm_Load;
        buttonRefresh.Click += buttonRefresh_Click;
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
            buttonRefresh.Enabled = false;

            var summary = await _apiClient.GetDashboardSummaryAsync();

            if(summary is null)
            {
                MessageBox.Show(
                    "Dashboard data could not be loaded.",
                    "ParcelDesk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            labelTotalShipmentsValue.Text = summary.TotalShipments.ToString();

            labelCreatedValue.Text = summary.Created.ToString();

            labelPickedUpValue.Text = summary.PickedUp.ToString();

            labelInTransitValue.Text = summary.InTransit.ToString();

            labelDeliveredValue.Text = summary.Delivered.ToString();

            labelCancelledValue.Text = summary.Cancelled.ToString();
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
            buttonRefresh.Enabled = true;
        }
    }
}
