namespace ParcelDesk.WinForms
{
    partial class ShipmentDetailsForm
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
            lblAwb = new Label();
            lblCustomer = new Label();
            lblCurrentStatus = new Label();
            txtCity = new TextBox();
            txtDestinationAddress = new TextBox();
            txtSenderAddress = new TextBox();
            nudWeight = new NumericUpDown();
            txtNotes = new TextBox();
            btnSave = new Button();
            cmbNewStatus = new ComboBox();
            btnChangeStatus = new Button();
            dgvHistory = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // lblAwb
            // 
            lblAwb.AutoSize = true;
            lblAwb.Location = new Point(27, 9);
            lblAwb.Name = "lblAwb";
            lblAwb.Size = new Size(44, 15);
            lblAwb.TabIndex = 0;
            lblAwb.Text = "lblAwb";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(283, 9);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(72, 15);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "lblCustomer";
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Location = new Point(615, 9);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(92, 15);
            lblCurrentStatus.TabIndex = 2;
            lblCurrentStatus.Text = "lblCurrentStatus";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(539, 74);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "City";
            txtCity.Size = new Size(200, 23);
            txtCity.TabIndex = 3;
            // 
            // txtDestinationAddress
            // 
            txtDestinationAddress.Location = new Point(283, 74);
            txtDestinationAddress.Name = "txtDestinationAddress";
            txtDestinationAddress.PlaceholderText = "Destination Address";
            txtDestinationAddress.Size = new Size(250, 23);
            txtDestinationAddress.TabIndex = 4;
            // 
            // txtSenderAddress
            // 
            txtSenderAddress.Location = new Point(27, 74);
            txtSenderAddress.Name = "txtSenderAddress";
            txtSenderAddress.PlaceholderText = "Sender Address";
            txtSenderAddress.Size = new Size(250, 23);
            txtSenderAddress.TabIndex = 5;
            // 
            // nudWeight
            // 
            nudWeight.DecimalPlaces = 2;
            nudWeight.Location = new Point(667, 104);
            nudWeight.Maximum = new decimal(new int[] { 15099, 0, 0, 131072 });
            nudWeight.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new Size(120, 23);
            nudWeight.TabIndex = 6;
            nudWeight.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(27, 103);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Notes";
            txtNotes.Size = new Size(634, 145);
            txtNotes.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(713, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // cmbNewStatus
            // 
            cmbNewStatus.FormattingEnabled = true;
            cmbNewStatus.Location = new Point(667, 196);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(121, 23);
            cmbNewStatus.TabIndex = 9;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(697, 225);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(91, 23);
            btnChangeStatus.TabIndex = 10;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(27, 254);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.Size = new Size(761, 155);
            dgvHistory.TabIndex = 11;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ShipmentDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(dgvHistory);
            Controls.Add(btnChangeStatus);
            Controls.Add(cmbNewStatus);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(nudWeight);
            Controls.Add(txtSenderAddress);
            Controls.Add(txtDestinationAddress);
            Controls.Add(txtCity);
            Controls.Add(lblAwb);
            Controls.Add(lblCustomer);
            Controls.Add(lblCurrentStatus);
            Name = "ShipmentDetailsForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAwb;
        private Label lblCustomer;
        private Label lblCurrentStatus;
        private TextBox txtCity;
        private TextBox txtDestinationAddress;
        private TextBox txtSenderAddress;
        private NumericUpDown nudWeight;
        private TextBox txtNotes;
        private Button btnSave;
        private ComboBox cmbNewStatus;
        private Button btnChangeStatus;
        private DataGridView dgvHistory;
        private Button btnClose;
    }
}