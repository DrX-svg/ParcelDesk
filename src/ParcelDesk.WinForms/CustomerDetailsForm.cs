using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms;

public partial class CustomerDetailsForm : Form
{
    private readonly ParcelDeskApiClient _apiClient;
    private readonly int _customerId;
    private Customer? _customer;

    public CustomerDetailsForm(
        ParcelDeskApiClient apiClient,
        int customerId)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _customerId = customerId;

        Load += CustomerDetailsForm_Load;

        btnSaveCustomer.Click += btnSaveCustomer_Click;
        btnCloseCustomer.Click += btnCloseCustomer_Click;

        dgvCustomerShipments.CellDoubleClick += dgvCustomerShipments_CellDoubleClick;
    }

    private async void CustomerDetailsForm_Load(object? sender, EventArgs e)
    {
        await LoadCustomerAsync();
    }

    private async Task LoadCustomerAsync()
    {
        try
        {
            _customer = await _apiClient.GetCustomerAsync(_customerId);

            if (_customer is null)
            {
                MessageBox.Show(
                    "Customer could not be found.",
                    "ParcelDesk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            lblCustomerId.Text = $"Customer ID: {_customerId}";
            txtCustomerName.Text = _customer.Name;
            txtCustomerPhone.Text = _customer.Phone;
            txtCustomerEmail.Text = _customer.Email ?? string.Empty;
            txtCustomerAddress.Text = _customer.Address;

            await LoadCustomerShipmentsAsync();
        }
        catch(HttpRequestException ex)
        {
            MessageBox.Show(
                            $"Could not load customer.\n\n" +
                            $"Status: {ex.StatusCode}\n" +
                            $"{ex.Message}",
                            "API Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
    private async Task LoadCustomerShipmentsAsync()
    {
        var shipments =
            await _apiClient.GetShipmentsAsync(
                customerId: _customerId);

        dgvCustomerShipments.DataSource = shipments;

        if (dgvCustomerShipments.Columns.Count == 0)
        {
            return;
        }

        var idColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.Id)];

        var customerIdColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.CustomerId)];

        var customerNameColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.CustomerName)];

        var senderColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.SenderAddress)];

        var updatedColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.UpdatedAtUtc)];

        var notesColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.Notes)];

        if (idColumn is not null)
        {
            idColumn.Visible = false;
        }

        if (customerIdColumn is not null)
        {
            customerIdColumn.Visible = false;
        }

        if (customerNameColumn is not null)
        {
            customerNameColumn.Visible = false;
        }

        if (senderColumn is not null)
        {
            senderColumn.Visible = false;
        }

        if (updatedColumn is not null)
        {
            updatedColumn.Visible = false;
        }

        if (notesColumn is not null)
        {
            notesColumn.Visible = false;
        }

        var awbColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.Awb)];

        var destinationColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.DestinationAddress)];

        var createdColumn =
            dgvCustomerShipments.Columns[
                nameof(Shipment.CreatedAtUtc)];

        if (awbColumn is not null)
        {
            awbColumn.HeaderText = "AWB";
        }

        if (destinationColumn is not null)
        {
            destinationColumn.HeaderText = "Destination";
        }

        if (createdColumn is not null)
        {
            createdColumn.HeaderText = "Created";
        }

        dgvCustomerShipments.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
    }

    private async void btnSaveCustomer_Click(
        object? sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtCustomerName.Text))
        {
            MessageBox.Show(
                "Customer name is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(
            txtCustomerPhone.Text))
        {
            MessageBox.Show(
                "Phone number is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(
            txtCustomerAddress.Text))
        {
            MessageBox.Show(
                "Address is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            var request = new UpdateCustomerRequest
            {
                Name =
                    txtCustomerName.Text.Trim(),

                Phone =
                    txtCustomerPhone.Text.Trim(),

                Email =
                    string.IsNullOrWhiteSpace(
                        txtCustomerEmail.Text)
                        ? null
                        : txtCustomerEmail.Text.Trim(),

                Address =
                    txtCustomerAddress.Text.Trim()
            };

            var updated =
                await _apiClient.UpdateCustomerAsync(
                    _customerId,
                    request);

            if (updated is null)
            {
                return;
            }

            MessageBox.Show(
                "Customer updated successfully.",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadCustomerAsync();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Customer could not be updated.\n\n" +
                $"Status: {ex.StatusCode}\n" +
                $"{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnCloseCustomer_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }

    private void dgvCustomerShipments_CellDoubleClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        var row =
            dgvCustomerShipments.Rows[e.RowIndex];

        if (row.DataBoundItem is not Shipment shipment)
        {
            return;
        }

        using var detailsForm =
            new ShipmentDetailsForm(
                _apiClient,
                shipment.Id);

        detailsForm.ShowDialog(this);
    }
}
