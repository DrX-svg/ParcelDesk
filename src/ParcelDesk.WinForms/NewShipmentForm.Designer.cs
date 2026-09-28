namespace ParcelDesk.WinForms
{
    partial class NewShipmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbCustomer = new ComboBox();
            txtSenderAddress = new TextBox();
            txtDestinationAddress = new TextBox();
            txtCity = new TextBox();
            nudWeight = new NumericUpDown();
            txtNotes = new TextBox();
            btnCreateShipment = new Button();
            btnCancelShipment = new Button();
            lblNewShipment = new Label();
            btnAutoCompleteSenderAddress = new Button();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(12, 31);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(250, 23);
            cmbCustomer.TabIndex = 0;
            // 
            // txtSenderAddress
            // 
            txtSenderAddress.Location = new Point(12, 75);
            txtSenderAddress.Name = "txtSenderAddress";
            txtSenderAddress.PlaceholderText = "Sender Address";
            txtSenderAddress.Size = new Size(500, 23);
            txtSenderAddress.TabIndex = 1;
            // 
            // txtDestinationAddress
            // 
            txtDestinationAddress.Location = new Point(12, 166);
            txtDestinationAddress.Name = "txtDestinationAddress";
            txtDestinationAddress.PlaceholderText = "Destination Address";
            txtDestinationAddress.Size = new Size(500, 23);
            txtDestinationAddress.TabIndex = 2;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(12, 195);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "City";
            txtCity.Size = new Size(250, 23);
            txtCity.TabIndex = 3;
            // 
            // nudWeight
            // 
            nudWeight.DecimalPlaces = 2;
            nudWeight.Location = new Point(12, 119);
            nudWeight.Maximum = new decimal(new int[] { 15099, 0, 0, 131072 });
            nudWeight.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new Size(120, 23);
            nudWeight.TabIndex = 4;
            nudWeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(12, 244);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Notes";
            txtNotes.Size = new Size(776, 194);
            txtNotes.TabIndex = 5;
            // 
            // btnCreateShipment
            // 
            btnCreateShipment.Location = new Point(638, 195);
            btnCreateShipment.Name = "btnCreateShipment";
            btnCreateShipment.Size = new Size(150, 23);
            btnCreateShipment.TabIndex = 6;
            btnCreateShipment.Text = "Create Shipment";
            btnCreateShipment.UseVisualStyleBackColor = true;
            // 
            // btnCancelShipment
            // 
            btnCancelShipment.Location = new Point(713, 12);
            btnCancelShipment.Name = "btnCancelShipment";
            btnCancelShipment.Size = new Size(75, 23);
            btnCancelShipment.TabIndex = 7;
            btnCancelShipment.Text = "Cancel";
            btnCancelShipment.UseVisualStyleBackColor = true;
            // 
            // lblNewShipment
            // 
            lblNewShipment.AutoSize = true;
            lblNewShipment.Location = new Point(12, 9);
            lblNewShipment.Name = "lblNewShipment";
            lblNewShipment.Size = new Size(132, 15);
            lblNewShipment.TabIndex = 8;
            lblNewShipment.Text = "Create a new Shipment:";
            // 
            // btnAutoCompleteSenderAddress
            // 
            btnAutoCompleteSenderAddress.Location = new Point(518, 75);
            btnAutoCompleteSenderAddress.Name = "btnAutoCompleteSenderAddress";
            btnAutoCompleteSenderAddress.Size = new Size(121, 23);
            btnAutoCompleteSenderAddress.TabIndex = 9;
            btnAutoCompleteSenderAddress.Text = "Customer Address";
            btnAutoCompleteSenderAddress.UseVisualStyleBackColor = true;
            // 
            // NewShipmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNewShipment);
            Controls.Add(btnCancelShipment);
            Controls.Add(btnAutoCompleteSenderAddress);
            Controls.Add(btnCreateShipment);
            Controls.Add(nudWeight);
            Controls.Add(txtCity);
            Controls.Add(txtNotes);
            Controls.Add(txtDestinationAddress);
            Controls.Add(txtSenderAddress);
            Controls.Add(cmbCustomer);
            Name = "NewShipmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Shipment";
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCustomer;
        private TextBox txtSenderAddress;
        private TextBox txtDestinationAddress;
        private TextBox txtCity;
        private NumericUpDown nudWeight;
        private TextBox txtNotes;
        private Button btnCreateShipment;
        private Button btnCancelShipment;
        private Label lblNewShipment;
        private Button btnAutoCompleteSenderAddress;
    }
}