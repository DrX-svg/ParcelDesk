using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms;

public partial class ShipmentDetailsForm : Form
{
    private readonly ParcelDeskApiClient _apiClient;
    private readonly int _shipmentId;

    private Shipment? _shipment;

    public ShipmentDetailsForm(
        ParcelDeskApiClient apiClient,
        int shipmentId)
    {
        InitializeComponent();

        _apiClient = apiClient;
        _shipmentId = shipmentId;

        Load += ShipmentDetailsForm_Load;

        btnSave.Click += btnSave_Click;
        btnChangeStatus.Click += btnChangeStatus_Click;
        btnClose.Click += btnClose_Click;
    }

    private async void ShipmentDetailsForm_Load(object? sender, EventArgs e)
    {
        await LoadShipmentAsync();
    }

    private async Task LoadShipmentAsync()
    {
        try
        {
            _shipment = await _apiClient.GetShipmentAsync(_shipmentId);
            if (_shipment == null)
            {
                MessageBox.Show(
                    "Shipment could not be found.",
                    "ParcelDesk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return;
            }
            lblAwb.Text = $"AWB: {_shipment.Awb}";
            lblCustomer.Text = $"Customer: {_shipment.CustomerName}";
            lblCurrentStatus.Text = $"Status: {_shipment.Status}";
            txtSenderAddress.Text = _shipment.SenderAddress;
            txtDestinationAddress.Text = _shipment.DestinationAddress;
            txtCity.Text = _shipment.City;
            nudWeight.Value = _shipment.Weight;
            txtNotes.Text = _shipment.Notes;
            ConfigureStatusOptions();

            await LoadHistoryAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Could not load shipment.\n\n{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }


private async Task LoadHistoryAsync()
    {
        var history = await _apiClient.GetShipmentHistoryAsync(_shipmentId);

        dgvHistory.DataSource = history;

        if (dgvHistory.Columns.Count > 0)
        {
            dgvHistory.Columns[nameof(
                ShipmentStatusHistory.Id)]
                .Visible = false;

            dgvHistory.Columns[nameof(
                ShipmentStatusHistory.ShipmentId)]
                .Visible = false;

            dgvHistory.Columns[nameof(
                ShipmentStatusHistory.ChangedAtUtc)]
                .HeaderText = "Changed At";
        }
    }

    private void ConfigureStatusOptions()
    {
        cmbNewStatus.Items.Clear();
        if (_shipment is null)
        {
            return;
        }

        switch (_shipment.Status)
        {
            case "Created":
                cmbNewStatus.Items.Add("PickedUp");
                cmbNewStatus.Items.Add("Cancelled");
                break;
            case "PickedUp":
                cmbNewStatus.Items.Add("InTransit");
                cmbNewStatus.Items.Add("Cancelled");
                break;
            case "InTransit":
                cmbNewStatus.Items.Add("Delivered");
                cmbNewStatus.Items.Add("Cancelled");
                break;
        }
        if (cmbNewStatus.Items.Count > 0)
        {
            cmbNewStatus.SelectedIndex = 0;

            cmbNewStatus.Enabled = true;
            btnChangeStatus.Enabled = true;
        }
        else
        {
            cmbNewStatus.Enabled = false;
            btnChangeStatus.Enabled = false;
        }
    }

    private async void btnSave_Click(
        object? sender,
        EventArgs e)
    {
        try
        {
            var request = new UpdateShipmentRequest
            {
                SenderAddress = txtSenderAddress.Text,
                DestinationAddress = txtDestinationAddress.Text,
                City = txtCity.Text,
                Weight = nudWeight.Value,
                Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text
            };

            var updated = await _apiClient.UpdateShipmentAsync(_shipmentId, request);

            if (updated is null)
            {
                return;
            }

            MessageBox.Show(
                "Shipment updated successfully.",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadShipmentAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Shipment could not be updated.\n\n" + $"Status: {ex.StatusCode}\n" + $"{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void btnChangeStatus_Click(
        object? sender,
        EventArgs e)
    {
        if (cmbNewStatus.SelectedItem is null)
        {
            return;
        }
        try
        {
            var newStatus = cmbNewStatus.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                return;
            }
            await _apiClient.ChangeShipmentStatusAsync(_shipmentId, newStatus);
            await LoadShipmentAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Status could not be changed.\n\n" + $"Status: {ex.StatusCode}\n" + $"{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnClose_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }
}