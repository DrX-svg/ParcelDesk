namespace ParcelDesk.WinForms
{
    partial class NewCustomerForm
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
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            btnCreate = new Button();
            btnCancel = new Button();
            lblNewCustomer = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(30, 79);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(405, 23);
            txtName.TabIndex = 0;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(30, 139);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone";
            txtPhone.Size = new Size(405, 23);
            txtPhone.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(30, 199);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(405, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(30, 259);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(405, 46);
            txtAddress.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(657, 150);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(131, 23);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create Customer";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(713, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblNewCustomer
            // 
            lblNewCustomer.AutoSize = true;
            lblNewCustomer.Location = new Point(30, 31);
            lblNewCustomer.Name = "lblNewCustomer";
            lblNewCustomer.Size = new Size(131, 15);
            lblNewCustomer.TabIndex = 6;
            lblNewCustomer.Text = "Create a new customer:";
            // 
            // NewCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNewCustomer);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(txtName);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Name = "NewCustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Button btnCreate;
        private Button btnCancel;
        private Label lblNewCustomer;
    }
}