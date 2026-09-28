namespace ParcelDesk.WinForms
{
    partial class CustomerDetailsForm
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
            lblCustomerId = new Label();
            txtCustomerName = new TextBox();
            txtCustomerPhone = new TextBox();
            txtCustomerEmail = new TextBox();
            txtCustomerAddress = new TextBox();
            btnSaveCustomer = new Button();
            btnCloseCustomer = new Button();
            dgvCustomerShipments = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerShipments).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(12, 9);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(38, 15);
            lblCustomerId.TabIndex = 0;
            lblCustomerId.Text = "label1";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(12, 30);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(534, 23);
            txtCustomerName.TabIndex = 1;
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(12, 70);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(534, 23);
            txtCustomerPhone.TabIndex = 2;
            // 
            // txtCustomerEmail
            // 
            txtCustomerEmail.Location = new Point(12, 110);
            txtCustomerEmail.Name = "txtCustomerEmail";
            txtCustomerEmail.Size = new Size(534, 23);
            txtCustomerEmail.TabIndex = 3;
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.Location = new Point(12, 150);
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.Size = new Size(534, 23);
            txtCustomerAddress.TabIndex = 4;
            // 
            // btnSaveCustomer
            // 
            btnSaveCustomer.Location = new Point(657, 150);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.Size = new Size(131, 23);
            btnSaveCustomer.TabIndex = 5;
            btnSaveCustomer.Text = "Save details";
            btnSaveCustomer.UseVisualStyleBackColor = true;
            // 
            // btnCloseCustomer
            // 
            btnCloseCustomer.Location = new Point(713, 12);
            btnCloseCustomer.Name = "btnCloseCustomer";
            btnCloseCustomer.Size = new Size(75, 23);
            btnCloseCustomer.TabIndex = 6;
            btnCloseCustomer.Text = "Cancel";
            btnCloseCustomer.UseVisualStyleBackColor = true;
            // 
            // dgvCustomerShipments
            // 
            dgvCustomerShipments.AllowUserToAddRows = false;
            dgvCustomerShipments.AllowUserToDeleteRows = false;
            dgvCustomerShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerShipments.Location = new Point(12, 179);
            dgvCustomerShipments.MultiSelect = false;
            dgvCustomerShipments.Name = "dgvCustomerShipments";
            dgvCustomerShipments.ReadOnly = true;
            dgvCustomerShipments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerShipments.Size = new Size(776, 259);
            dgvCustomerShipments.TabIndex = 7;
            // 
            // CustomerDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCustomerShipments);
            Controls.Add(btnCloseCustomer);
            Controls.Add(btnSaveCustomer);
            Controls.Add(txtCustomerAddress);
            Controls.Add(txtCustomerEmail);
            Controls.Add(txtCustomerPhone);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerId);
            Name = "CustomerDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Details";
            ((System.ComponentModel.ISupportInitialize)dgvCustomerShipments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerId;
        private TextBox txtCustomerName;
        private TextBox txtCustomerPhone;
        private TextBox txtCustomerEmail;
        private TextBox txtCustomerAddress;
        private Button btnSaveCustomer;
        private Button btnCloseCustomer;
        private DataGridView dgvCustomerShipments;
    }
}