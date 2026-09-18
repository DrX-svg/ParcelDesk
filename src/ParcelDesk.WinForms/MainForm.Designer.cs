namespace ParcelDesk.WinForms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        sidebarPanel = new Panel();
        navFlowPanel = new FlowLayoutPanel();
        btnDashboard = new Button();
        btnShipments = new Button();
        btnCustomers = new Button();
        contentPanel = new Panel();
        shipmentsPanel = new Panel();
        dgvShipments = new DataGridView();
        shipmentsHeaderPanel = new Panel();
        txtShipmentsSearch = new TextBox();
        cmbShipmentStatus = new ComboBox();
        btnShipmentRefresh = new Button();
        lblShipments = new Label();
        dashboardPanel = new Panel();
        tableLayoutPanel1 = new TableLayoutPanel();
        panelCancelled = new Panel();
        lblCancelledValue = new Label();
        lblCancelled = new Label();
        panelDelivered = new Panel();
        lblDeliveredValue = new Label();
        lblDelivered = new Label();
        panelInTransit = new Panel();
        lblInTransitValue = new Label();
        lblInTransit = new Label();
        panelPickedUp = new Panel();
        lblPickedUpValue = new Label();
        lblPickedUp = new Label();
        panelCreated = new Panel();
        lblCreatedValue = new Label();
        lblCreated = new Label();
        panelTotalShipments = new Panel();
        lblTotalShipmentsValue = new Label();
        lblTotalShipments = new Label();
        dashboardHeaderPanel = new Panel();
        btnRefresh = new Button();
        lblPageTitle = new Label();
        sidebarPanel.SuspendLayout();
        navFlowPanel.SuspendLayout();
        contentPanel.SuspendLayout();
        shipmentsPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvShipments).BeginInit();
        shipmentsHeaderPanel.SuspendLayout();
        dashboardPanel.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        panelCancelled.SuspendLayout();
        panelDelivered.SuspendLayout();
        panelInTransit.SuspendLayout();
        panelPickedUp.SuspendLayout();
        panelCreated.SuspendLayout();
        panelTotalShipments.SuspendLayout();
        dashboardHeaderPanel.SuspendLayout();
        SuspendLayout();
        // 
        // sidebarPanel
        // 
        sidebarPanel.Controls.Add(navFlowPanel);
        sidebarPanel.Dock = DockStyle.Left;
        sidebarPanel.Location = new Point(0, 0);
        sidebarPanel.Name = "sidebarPanel";
        sidebarPanel.Size = new Size(140, 711);
        sidebarPanel.TabIndex = 0;
        // 
        // navFlowPanel
        // 
        navFlowPanel.AutoSize = true;
        navFlowPanel.Controls.Add(btnDashboard);
        navFlowPanel.Controls.Add(btnShipments);
        navFlowPanel.Controls.Add(btnCustomers);
        navFlowPanel.Dock = DockStyle.Top;
        navFlowPanel.FlowDirection = FlowDirection.TopDown;
        navFlowPanel.Location = new Point(0, 0);
        navFlowPanel.Name = "navFlowPanel";
        navFlowPanel.Size = new Size(140, 180);
        navFlowPanel.TabIndex = 11;
        navFlowPanel.WrapContents = false;
        // 
        // btnDashboard
        // 
        btnDashboard.Location = new Point(10, 10);
        btnDashboard.Margin = new Padding(10);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Size = new Size(120, 40);
        btnDashboard.TabIndex = 10;
        btnDashboard.Text = "Dashboard";
        btnDashboard.UseVisualStyleBackColor = true;
        // 
        // btnShipments
        // 
        btnShipments.Location = new Point(10, 70);
        btnShipments.Margin = new Padding(10);
        btnShipments.Name = "btnShipments";
        btnShipments.Size = new Size(120, 40);
        btnShipments.TabIndex = 12;
        btnShipments.Text = "Shipments";
        btnShipments.UseVisualStyleBackColor = true;
        // 
        // btnCustomers
        // 
        btnCustomers.Location = new Point(10, 130);
        btnCustomers.Margin = new Padding(10);
        btnCustomers.Name = "btnCustomers";
        btnCustomers.Size = new Size(120, 40);
        btnCustomers.TabIndex = 11;
        btnCustomers.Text = "Customers";
        btnCustomers.UseVisualStyleBackColor = true;
        // 
        // contentPanel
        // 
        contentPanel.Controls.Add(shipmentsPanel);
        contentPanel.Controls.Add(dashboardPanel);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(140, 0);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(1044, 711);
        contentPanel.TabIndex = 1;
        // 
        // shipmentsPanel
        // 
        shipmentsPanel.Controls.Add(dgvShipments);
        shipmentsPanel.Controls.Add(shipmentsHeaderPanel);
        shipmentsPanel.Dock = DockStyle.Fill;
        shipmentsPanel.Location = new Point(0, 0);
        shipmentsPanel.Name = "shipmentsPanel";
        shipmentsPanel.Size = new Size(1044, 711);
        shipmentsPanel.TabIndex = 3;
        shipmentsPanel.Visible = false;
        // 
        // dgvShipments
        // 
        dgvShipments.AllowUserToAddRows = false;
        dgvShipments.AllowUserToDeleteRows = false;
        dgvShipments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvShipments.Location = new Point(3, 43);
        dgvShipments.MultiSelect = false;
        dgvShipments.Name = "dgvShipments";
        dgvShipments.ReadOnly = true;
        dgvShipments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvShipments.Size = new Size(1038, 665);
        dgvShipments.TabIndex = 4;
        // 
        // shipmentsHeaderPanel
        // 
        shipmentsHeaderPanel.Controls.Add(txtShipmentsSearch);
        shipmentsHeaderPanel.Controls.Add(cmbShipmentStatus);
        shipmentsHeaderPanel.Controls.Add(btnShipmentRefresh);
        shipmentsHeaderPanel.Controls.Add(lblShipments);
        shipmentsHeaderPanel.Dock = DockStyle.Top;
        shipmentsHeaderPanel.Location = new Point(0, 0);
        shipmentsHeaderPanel.Name = "shipmentsHeaderPanel";
        shipmentsHeaderPanel.Size = new Size(1044, 37);
        shipmentsHeaderPanel.TabIndex = 5;
        // 
        // txtShipmentsSearch
        // 
        txtShipmentsSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        txtShipmentsSearch.Location = new Point(184, 10);
        txtShipmentsSearch.Name = "txtShipmentsSearch";
        txtShipmentsSearch.PlaceholderText = "Search shipments...";
        txtShipmentsSearch.Size = new Size(228, 23);
        txtShipmentsSearch.TabIndex = 7;
        // 
        // cmbShipmentStatus
        // 
        cmbShipmentStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        cmbShipmentStatus.Location = new Point(418, 10);
        cmbShipmentStatus.Name = "cmbShipmentStatus";
        cmbShipmentStatus.Size = new Size(132, 23);
        cmbShipmentStatus.TabIndex = 6;
        cmbShipmentStatus.Text = "Combo Box";
        // 
        // btnShipmentRefresh
        // 
        btnShipmentRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        btnShipmentRefresh.Location = new Point(656, 9);
        btnShipmentRefresh.Name = "btnShipmentRefresh";
        btnShipmentRefresh.Size = new Size(75, 23);
        btnShipmentRefresh.TabIndex = 4;
        btnShipmentRefresh.Text = "Refresh";
        btnShipmentRefresh.UseVisualStyleBackColor = true;
        // 
        // lblShipments
        // 
        lblShipments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        lblShipments.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblShipments.Location = new Point(3, 0);
        lblShipments.Name = "lblShipments";
        lblShipments.Size = new Size(172, 47);
        lblShipments.TabIndex = 5;
        lblShipments.Text = "Shipments";
        lblShipments.Click += lblShipments_Click;
        // 
        // dashboardPanel
        // 
        dashboardPanel.Controls.Add(tableLayoutPanel1);
        dashboardPanel.Controls.Add(dashboardHeaderPanel);
        dashboardPanel.Dock = DockStyle.Fill;
        dashboardPanel.Location = new Point(0, 0);
        dashboardPanel.Name = "dashboardPanel";
        dashboardPanel.Size = new Size(1044, 711);
        dashboardPanel.TabIndex = 6;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.Controls.Add(panelCancelled, 2, 1);
        tableLayoutPanel1.Controls.Add(panelDelivered, 1, 1);
        tableLayoutPanel1.Controls.Add(panelInTransit, 0, 1);
        tableLayoutPanel1.Controls.Add(panelPickedUp, 2, 0);
        tableLayoutPanel1.Controls.Add(panelCreated, 1, 0);
        tableLayoutPanel1.Controls.Add(panelTotalShipments, 0, 0);
        tableLayoutPanel1.Location = new Point(0, 47);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.Padding = new Padding(3);
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new Size(1044, 664);
        tableLayoutPanel1.TabIndex = 3;
        // 
        // panelCancelled
        // 
        panelCancelled.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelCancelled.Controls.Add(lblCancelledValue);
        panelCancelled.Controls.Add(lblCancelled);
        panelCancelled.Location = new Point(698, 335);
        panelCancelled.Name = "panelCancelled";
        panelCancelled.Size = new Size(340, 323);
        panelCancelled.TabIndex = 5;
        // 
        // lblCancelledValue
        // 
        lblCancelledValue.AutoSize = true;
        lblCancelledValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblCancelledValue.Location = new Point(142, 136);
        lblCancelledValue.Name = "lblCancelledValue";
        lblCancelledValue.Size = new Size(33, 37);
        lblCancelledValue.TabIndex = 2;
        lblCancelledValue.Text = "0";
        // 
        // lblCancelled
        // 
        lblCancelled.AutoSize = true;
        lblCancelled.Location = new Point(150, 7);
        lblCancelled.Name = "lblCancelled";
        lblCancelled.Size = new Size(59, 15);
        lblCancelled.TabIndex = 0;
        lblCancelled.Text = "Cancelled";
        // 
        // panelDelivered
        // 
        panelDelivered.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelDelivered.Controls.Add(lblDeliveredValue);
        panelDelivered.Controls.Add(lblDelivered);
        panelDelivered.Location = new Point(352, 335);
        panelDelivered.Name = "panelDelivered";
        panelDelivered.Size = new Size(340, 323);
        panelDelivered.TabIndex = 4;
        // 
        // lblDeliveredValue
        // 
        lblDeliveredValue.AutoSize = true;
        lblDeliveredValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblDeliveredValue.Location = new Point(142, 136);
        lblDeliveredValue.Name = "lblDeliveredValue";
        lblDeliveredValue.Size = new Size(33, 37);
        lblDeliveredValue.TabIndex = 2;
        lblDeliveredValue.Text = "0";
        // 
        // lblDelivered
        // 
        lblDelivered.AutoSize = true;
        lblDelivered.Location = new Point(144, 5);
        lblDelivered.Name = "lblDelivered";
        lblDelivered.Size = new Size(56, 15);
        lblDelivered.TabIndex = 0;
        lblDelivered.Text = "Delivered";
        // 
        // panelInTransit
        // 
        panelInTransit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelInTransit.Controls.Add(lblInTransitValue);
        panelInTransit.Controls.Add(lblInTransit);
        panelInTransit.Location = new Point(6, 335);
        panelInTransit.Name = "panelInTransit";
        panelInTransit.Size = new Size(340, 323);
        panelInTransit.TabIndex = 3;
        // 
        // lblInTransitValue
        // 
        lblInTransitValue.AutoSize = true;
        lblInTransitValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblInTransitValue.Location = new Point(142, 136);
        lblInTransitValue.Name = "lblInTransitValue";
        lblInTransitValue.Size = new Size(33, 37);
        lblInTransitValue.TabIndex = 2;
        lblInTransitValue.Text = "0";
        // 
        // lblInTransit
        // 
        lblInTransit.AutoSize = true;
        lblInTransit.Location = new Point(148, 7);
        lblInTransit.Name = "lblInTransit";
        lblInTransit.Size = new Size(55, 15);
        lblInTransit.TabIndex = 0;
        lblInTransit.Text = "In Transit";
        // 
        // panelPickedUp
        // 
        panelPickedUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelPickedUp.Controls.Add(lblPickedUpValue);
        panelPickedUp.Controls.Add(lblPickedUp);
        panelPickedUp.Location = new Point(698, 6);
        panelPickedUp.Name = "panelPickedUp";
        panelPickedUp.Size = new Size(340, 323);
        panelPickedUp.TabIndex = 2;
        // 
        // lblPickedUpValue
        // 
        lblPickedUpValue.AutoSize = true;
        lblPickedUpValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblPickedUpValue.Location = new Point(142, 136);
        lblPickedUpValue.Name = "lblPickedUpValue";
        lblPickedUpValue.Size = new Size(33, 37);
        lblPickedUpValue.TabIndex = 3;
        lblPickedUpValue.Text = "0";
        // 
        // lblPickedUp
        // 
        lblPickedUp.AutoSize = true;
        lblPickedUp.Location = new Point(143, 6);
        lblPickedUp.Name = "lblPickedUp";
        lblPickedUp.Size = new Size(60, 15);
        lblPickedUp.TabIndex = 0;
        lblPickedUp.Text = "Picked Up";
        // 
        // panelCreated
        // 
        panelCreated.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelCreated.Controls.Add(lblCreatedValue);
        panelCreated.Controls.Add(lblCreated);
        panelCreated.Location = new Point(352, 6);
        panelCreated.Name = "panelCreated";
        panelCreated.Size = new Size(340, 323);
        panelCreated.TabIndex = 1;
        // 
        // lblCreatedValue
        // 
        lblCreatedValue.AutoSize = true;
        lblCreatedValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblCreatedValue.Location = new Point(145, 157);
        lblCreatedValue.Name = "lblCreatedValue";
        lblCreatedValue.Size = new Size(33, 37);
        lblCreatedValue.TabIndex = 2;
        lblCreatedValue.Text = "0";
        // 
        // lblCreated
        // 
        lblCreated.AutoSize = true;
        lblCreated.Location = new Point(107, 7);
        lblCreated.Name = "lblCreated";
        lblCreated.Size = new Size(107, 15);
        lblCreated.TabIndex = 1;
        lblCreated.Text = "Created Shipments";
        // 
        // panelTotalShipments
        // 
        panelTotalShipments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelTotalShipments.Controls.Add(lblTotalShipmentsValue);
        panelTotalShipments.Controls.Add(lblTotalShipments);
        panelTotalShipments.Location = new Point(6, 6);
        panelTotalShipments.Name = "panelTotalShipments";
        panelTotalShipments.Size = new Size(340, 323);
        panelTotalShipments.TabIndex = 0;
        // 
        // lblTotalShipmentsValue
        // 
        lblTotalShipmentsValue.AutoSize = true;
        lblTotalShipmentsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTotalShipmentsValue.Location = new Point(148, 150);
        lblTotalShipmentsValue.Name = "lblTotalShipmentsValue";
        lblTotalShipmentsValue.Size = new Size(33, 37);
        lblTotalShipmentsValue.TabIndex = 1;
        lblTotalShipmentsValue.Text = "0";
        // 
        // lblTotalShipments
        // 
        lblTotalShipments.AutoSize = true;
        lblTotalShipments.Location = new Point(116, 2);
        lblTotalShipments.Name = "lblTotalShipments";
        lblTotalShipments.Size = new Size(92, 15);
        lblTotalShipments.TabIndex = 0;
        lblTotalShipments.Text = "Total Shipments";
        // 
        // dashboardHeaderPanel
        // 
        dashboardHeaderPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        dashboardHeaderPanel.Controls.Add(btnRefresh);
        dashboardHeaderPanel.Controls.Add(lblPageTitle);
        dashboardHeaderPanel.Dock = DockStyle.Top;
        dashboardHeaderPanel.Location = new Point(0, 0);
        dashboardHeaderPanel.Name = "dashboardHeaderPanel";
        dashboardHeaderPanel.Size = new Size(1044, 47);
        dashboardHeaderPanel.TabIndex = 6;
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(656, 9);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(75, 23);
        btnRefresh.TabIndex = 7;
        btnRefresh.Text = "Refresh";
        btnRefresh.UseVisualStyleBackColor = true;
        // 
        // lblPageTitle
        // 
        lblPageTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblPageTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblPageTitle.Location = new Point(3, 0);
        lblPageTitle.Name = "lblPageTitle";
        lblPageTitle.Size = new Size(175, 47);
        lblPageTitle.TabIndex = 6;
        lblPageTitle.Text = "Dashboard";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        ClientSize = new Size(1184, 711);
        Controls.Add(contentPanel);
        Controls.Add(sidebarPanel);
        MinimumSize = new Size(1000, 650);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ParcelDesk";
        sidebarPanel.ResumeLayout(false);
        sidebarPanel.PerformLayout();
        navFlowPanel.ResumeLayout(false);
        contentPanel.ResumeLayout(false);
        shipmentsPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvShipments).EndInit();
        shipmentsHeaderPanel.ResumeLayout(false);
        shipmentsHeaderPanel.PerformLayout();
        dashboardPanel.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        panelCancelled.ResumeLayout(false);
        panelCancelled.PerformLayout();
        panelDelivered.ResumeLayout(false);
        panelDelivered.PerformLayout();
        panelInTransit.ResumeLayout(false);
        panelInTransit.PerformLayout();
        panelPickedUp.ResumeLayout(false);
        panelPickedUp.PerformLayout();
        panelCreated.ResumeLayout(false);
        panelCreated.PerformLayout();
        panelTotalShipments.ResumeLayout(false);
        panelTotalShipments.PerformLayout();
        dashboardHeaderPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel sidebarPanel;
    private Panel contentPanel;
    private Panel shipmentsPanel;
    private DataGridView dgvShipments;
    private Panel dashboardPanel;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panelCancelled;
    private Label lblCancelledValue;
    private Label lblCancelled;
    private Panel panelDelivered;
    private Label lblDeliveredValue;
    private Label lblDelivered;
    private Panel panelInTransit;
    private Label lblInTransitValue;
    private Label lblInTransit;
    private Panel panelPickedUp;
    private Label lblPickedUpValue;
    private Label lblPickedUp;
    private Panel panelCreated;
    private Label lblCreatedValue;
    private Label lblCreated;
    private Panel panelTotalShipments;
    private Label lblTotalShipmentsValue;
    private Label lblTotalShipments;
    private Panel shipmentsHeaderPanel;
    private TextBox txtShipmentsSearch;
    private ComboBox cmbShipmentStatus;
    private Label lblShipments;
    private Button btnShipmentRefresh;
    private Panel dashboardHeaderPanel;
    private Button btnRefresh;
    private Label lblPageTitle;
    private FlowLayoutPanel navFlowPanel;
    private Button btnDashboard;
    private Button btnShipments;
    private Button btnCustomers;
}
