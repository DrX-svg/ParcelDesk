using ParcelDesk.WinForms.Api;
using ParcelDesk.WinForms.Models;

namespace ParcelDesk.WinForms;

public partial class NewCustomerForm : Form
{
    private readonly ParcelDeskApiClient _apiClient;

    public NewCustomerForm(
        ParcelDeskApiClient apiClient)
    {
        InitializeComponent();

        _apiClient = apiClient;

        btnCreate.Click += btnCreate_Click;
        btnCancel.Click += btnCancel_Click;
    }

    private async void btnCreate_Click(
        object? sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show(
                "Name is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(txtPhone.Text))
        {
            MessageBox.Show(
                "Phone is required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (string.IsNullOrWhiteSpace(txtAddress.Text))
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
            var request = new CreateCustomerRequest
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),

                Email =
                    string.IsNullOrWhiteSpace(txtEmail.Text)
                        ? null
                        : txtEmail.Text.Trim(),

                Address =
                    txtAddress.Text.Trim()
            };

            var customer =
                await _apiClient.CreateCustomerAsync(
                    request);

            if (customer is null)
            {
                return;
            }

            MessageBox.Show(
                $"Customer '{customer.Name}' created.",
                "ParcelDesk",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;

            Close();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(
                $"Customer could not be created.\n\n" +
                $"Status: {ex.StatusCode}\n" +
                $"{ex.Message}",
                "API Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult = DialogResult.Cancel;

        Close();
    }
}