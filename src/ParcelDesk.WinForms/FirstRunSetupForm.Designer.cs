namespace ParcelDesk.WinForms
{
    partial class FirstRunSetupForm
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
            lblWelcome = new Label();
            lblDescription = new Label();
            rdoLocalStandalone = new RadioButton();
            rdoExistingMySql = new RadioButton();
            pnlLocalStandalone = new Panel();
            lblLocalDescription = new Label();
            pnlMySql = new Panel();
            txtMySqlPassword = new TextBox();
            txtMySqlUsername = new TextBox();
            txtMySqlDatabase = new TextBox();
            nudMySqlPort = new NumericUpDown();
            txtMySqlServer = new TextBox();
            btnContinue = new Button();
            btnCancelSetup = new Button();
            pnlLocalStandalone.SuspendLayout();
            pnlMySql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMySqlPort).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(12, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(278, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to ParcelDesk wizard configuration setup:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(15, 70);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(276, 15);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "ParcelDesk is a shipment management application.";
            // 
            // rdoLocalStandalone
            // 
            rdoLocalStandalone.AutoSize = true;
            rdoLocalStandalone.Location = new Point(12, 130);
            rdoLocalStandalone.Name = "rdoLocalStandalone";
            rdoLocalStandalone.Size = new Size(133, 19);
            rdoLocalStandalone.TabIndex = 2;
            rdoLocalStandalone.TabStop = true;
            rdoLocalStandalone.Text = "Local Standalone DB";
            rdoLocalStandalone.UseVisualStyleBackColor = true;
            // 
            // rdoExistingMySql
            // 
            rdoExistingMySql.AutoSize = true;
            rdoExistingMySql.Location = new Point(12, 229);
            rdoExistingMySql.Name = "rdoExistingMySql";
            rdoExistingMySql.Size = new Size(106, 19);
            rdoExistingMySql.TabIndex = 3;
            rdoExistingMySql.TabStop = true;
            rdoExistingMySql.Text = "Existing MySQL";
            rdoExistingMySql.UseVisualStyleBackColor = true;
            // 
            // pnlLocalStandalone
            // 
            pnlLocalStandalone.Controls.Add(lblLocalDescription);
            pnlLocalStandalone.Location = new Point(12, 155);
            pnlLocalStandalone.Name = "pnlLocalStandalone";
            pnlLocalStandalone.Size = new Size(307, 52);
            pnlLocalStandalone.TabIndex = 4;
            // 
            // lblLocalDescription
            // 
            lblLocalDescription.AutoSize = true;
            lblLocalDescription.Dock = DockStyle.Fill;
            lblLocalDescription.Location = new Point(0, 0);
            lblLocalDescription.Name = "lblLocalDescription";
            lblLocalDescription.Size = new Size(302, 45);
            lblLocalDescription.TabIndex = 0;
            lblLocalDescription.Text = "Stores all ParcelDesk data locally on this computer.\nNo database server is required.\nRecommended for individual use and local installations.";
            // 
            // pnlMySql
            // 
            pnlMySql.Controls.Add(txtMySqlPassword);
            pnlMySql.Controls.Add(txtMySqlUsername);
            pnlMySql.Controls.Add(txtMySqlDatabase);
            pnlMySql.Controls.Add(nudMySqlPort);
            pnlMySql.Controls.Add(txtMySqlServer);
            pnlMySql.Location = new Point(12, 254);
            pnlMySql.Name = "pnlMySql";
            pnlMySql.Size = new Size(427, 184);
            pnlMySql.TabIndex = 5;
            // 
            // txtMySqlPassword
            // 
            txtMySqlPassword.Location = new Point(3, 158);
            txtMySqlPassword.Name = "txtMySqlPassword";
            txtMySqlPassword.PlaceholderText = "Password";
            txtMySqlPassword.Size = new Size(100, 23);
            txtMySqlPassword.TabIndex = 4;
            txtMySqlPassword.UseSystemPasswordChar = true;
            // 
            // txtMySqlUsername
            // 
            txtMySqlUsername.Location = new Point(3, 105);
            txtMySqlUsername.Name = "txtMySqlUsername";
            txtMySqlUsername.PlaceholderText = "Username";
            txtMySqlUsername.Size = new Size(100, 23);
            txtMySqlUsername.TabIndex = 3;
            // 
            // txtMySqlDatabase
            // 
            txtMySqlDatabase.Location = new Point(3, 32);
            txtMySqlDatabase.Name = "txtMySqlDatabase";
            txtMySqlDatabase.PlaceholderText = "Database";
            txtMySqlDatabase.Size = new Size(100, 23);
            txtMySqlDatabase.TabIndex = 2;
            // 
            // nudMySqlPort
            // 
            nudMySqlPort.Location = new Point(134, 3);
            nudMySqlPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudMySqlPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMySqlPort.Name = "nudMySqlPort";
            nudMySqlPort.Size = new Size(120, 23);
            nudMySqlPort.TabIndex = 1;
            nudMySqlPort.Value = new decimal(new int[] { 3306, 0, 0, 0 });
            // 
            // txtMySqlServer
            // 
            txtMySqlServer.Location = new Point(3, 3);
            txtMySqlServer.Name = "txtMySqlServer";
            txtMySqlServer.PlaceholderText = "Server";
            txtMySqlServer.Size = new Size(100, 23);
            txtMySqlServer.TabIndex = 0;
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(701, 415);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(87, 23);
            btnContinue.TabIndex = 6;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnCancelSetup
            // 
            btnCancelSetup.Location = new Point(701, 12);
            btnCancelSetup.Name = "btnCancelSetup";
            btnCancelSetup.Size = new Size(87, 23);
            btnCancelSetup.TabIndex = 7;
            btnCancelSetup.Text = "Cancel Setup";
            btnCancelSetup.UseVisualStyleBackColor = true;
            // 
            // FirstRunSetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelSetup);
            Controls.Add(btnContinue);
            Controls.Add(pnlMySql);
            Controls.Add(pnlLocalStandalone);
            Controls.Add(rdoExistingMySql);
            Controls.Add(rdoLocalStandalone);
            Controls.Add(lblDescription);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FirstRunSetupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ParcelDesk Setup";
            pnlLocalStandalone.ResumeLayout(false);
            pnlLocalStandalone.PerformLayout();
            pnlMySql.ResumeLayout(false);
            pnlMySql.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMySqlPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblDescription;
        private RadioButton rdoLocalStandalone;
        private RadioButton rdoExistingMySql;
        private Panel pnlLocalStandalone;
        private Label lblLocalDescription;
        private Panel pnlMySql;
        private Button btnContinue;
        private Button btnCancelSetup;
        private TextBox txtMySqlPassword;
        private TextBox txtMySqlUsername;
        private TextBox txtMySqlDatabase;
        private NumericUpDown nudMySqlPort;
        private TextBox txtMySqlServer;
    }
}