using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms;

public partial class NewShipmentForm : Form
{
    private readonly ParcelDeskApiClient _apiClient;

    public NewShipmentForm(
        ParcelDeskApiClient apiClient)
    {
        InitializeComponent();

        _apiClient = apiClient;

        Load += NewShipmentForm_Load;

        btnCreateShipment.Click += btnCreateShipment_Click;

        btnCancelShipment.Click += btnCancelShipment_Click;

        btnAutoCompleteSenderAddress.Click += btnAutoCompleteSenderAddress_Click;
    }

    private async void NewShipmentForm_Load(
        object? sender,
        EventArgs e)
    {
        await LoadCustomersAsync();
    }

    private async Task LoadCustomersAsync()
    {
        try
        {
            var customers =
                await _apiClient.GetCustomersAsync();

            if (customers.Count == 0)
            {
                MessageBox.Show(
                    "No customers exist yet. Create a customer first.",
                    "ParcelDesk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnCreateShipment.Enabled = false;

                return;
            }

            cmbCustomer.DataSource = customers;

            cmbCustomer.DisplayMember =
                nameof(Customer.Name);

            cmbCustomer.ValueMember =
                nameof(Customer.Id);
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Could not load customers.\n\n" +
                $"Status: {ex.StatusCode}\n" +
                $"{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            btnCreateShipment.Enabled = false;
        }
    }

    private async void btnCreateShipment_Click(
        object? sender,
        EventArgs e)
    {
        if (cmbCustomer.SelectedItem is not Customer customer)
        {
            MessageBox.Show(
                "Select a customer.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(
            txtSenderAddress.Text))
        {
            MessageBox.Show(
                "Sender address is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(
            txtDestinationAddress.Text))
        {
            MessageBox.Show(
                "Destination address is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(
            txtCity.Text))
        {
            MessageBox.Show(
                "City is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            btnCreateShipment.Enabled = false;

            var request =
                new CreateShipmentRequest
                {
                    CustomerId =
                        customer.Id,

                    SenderAddress =
                        txtSenderAddress.Text.Trim(),

                    DestinationAddress =
                        txtDestinationAddress.Text.Trim(),

                    City =
                        txtCity.Text.Trim(),

                    Weight =
                        nudWeight.Value,

                    Notes =
                        string.IsNullOrWhiteSpace(
                            txtNotes.Text)
                            ? null
                            : txtNotes.Text.Trim()
                };

            var shipment =
                await _apiClient.CreateShipmentAsync(
                    request);

            if (shipment is null)
            {
                return;
            }

            MessageBox.Show(
                $"Shipment created.\n\nAWB: {shipment.Awb}",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;

            Close();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Shipment could not be created.\n\n" +
                $"Status: {ex.StatusCode}\n" +
                $"{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            btnCreateShipment.Enabled = true;
        }
    }

    private void btnCancelShipment_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;

        Close();
    }

    private void btnAutoCompleteSenderAddress_Click(
    object? sender,
    EventArgs e)
    {
        if (cmbCustomer.SelectedItem is not Customer customer)
        {
            MessageBox.Show(
                "Select a customer first.",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(customer.Address))
        {
            MessageBox.Show(
                "The selected customer does not have an address.",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        txtSenderAddress.Text = customer.Address;
    }
}