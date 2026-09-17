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
        buttonDashboard = new Button();
        buttonShipments = new Button();
        buttonCustomers = new Button();
        contentPanel = new Panel();
        labelPageTitle = new Label();
        buttonRefresh = new Button();
        tableLayoutPanel1 = new TableLayoutPanel();
        panelTotalShipments = new Panel();
        panelCreated = new Panel();
        panelPickedUp = new Panel();
        panelInTransit = new Panel();
        panelDelivered = new Panel();
        panelCancelled = new Panel();
        labelTotalShipments = new Label();
        labelCreated = new Label();
        labelPickedUp = new Label();
        labelInTransit = new Label();
        labelDelivered = new Label();
        labelCancelled = new Label();
        labelTotalShipmentsValue = new Label();
        labelCreatedValue = new Label();
        labelPickedUpValue = new Label();
        labelInTransitValue = new Label();
        labelDeliveredValue = new Label();
        labelCancelledValue = new Label();
        sidebarPanel.SuspendLayout();
        contentPanel.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        panelTotalShipments.SuspendLayout();
        panelCreated.SuspendLayout();
        panelPickedUp.SuspendLayout();
        panelInTransit.SuspendLayout();
        panelDelivered.SuspendLayout();
        panelCancelled.SuspendLayout();
        SuspendLayout();
        // 
        // sidebarPanel
        // 
        sidebarPanel.Controls.Add(buttonCustomers);
        sidebarPanel.Controls.Add(buttonShipments);
        sidebarPanel.Controls.Add(buttonDashboard);
        sidebarPanel.Dock = DockStyle.Left;
        sidebarPanel.Location = new Point(0, 0);
        sidebarPanel.Name = "sidebarPanel";
        sidebarPanel.Size = new Size(200, 711);
        sidebarPanel.TabIndex = 0;
        // 
        // buttonDashboard
        // 
        buttonDashboard.Location = new Point(64, 40);
        buttonDashboard.Name = "buttonDashboard";
        buttonDashboard.Size = new Size(117, 25);
        buttonDashboard.TabIndex = 0;
        buttonDashboard.Text = "buttonDashboard";
        buttonDashboard.UseVisualStyleBackColor = true;
        // 
        // buttonShipments
        // 
        buttonShipments.Location = new Point(64, 85);
        buttonShipments.Name = "buttonShipments";
        buttonShipments.Size = new Size(117, 25);
        buttonShipments.TabIndex = 1;
        buttonShipments.Text = "buttonShipments";
        buttonShipments.UseVisualStyleBackColor = true;
        // 
        // buttonCustomers
        // 
        buttonCustomers.Location = new Point(64, 383);
        buttonCustomers.Name = "buttonCustomers";
        buttonCustomers.Size = new Size(117, 25);
        buttonCustomers.TabIndex = 2;
        buttonCustomers.Text = "buttonCustomers";
        buttonCustomers.UseVisualStyleBackColor = true;
        // 
        // contentPanel
        // 
        contentPanel.Controls.Add(tableLayoutPanel1);
        contentPanel.Controls.Add(buttonRefresh);
        contentPanel.Controls.Add(labelPageTitle);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(200, 0);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(984, 711);
        contentPanel.TabIndex = 1;
        // 
        // labelPageTitle
        // 
        labelPageTitle.AutoSize = true;
        labelPageTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelPageTitle.Location = new Point(413, 0);
        labelPageTitle.Name = "labelPageTitle";
        labelPageTitle.Size = new Size(157, 37);
        labelPageTitle.TabIndex = 0;
        labelPageTitle.Text = "Dashboard";
        // 
        // buttonRefresh
        // 
        buttonRefresh.Location = new Point(897, 676);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(75, 23);
        buttonRefresh.TabIndex = 1;
        buttonRefresh.Text = "Refresh";
        buttonRefresh.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel1
        // 
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
        tableLayoutPanel1.Location = new Point(6, 40);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new Size(966, 630);
        tableLayoutPanel1.TabIndex = 2;
        // 
        // panelTotalShipments
        // 
        panelTotalShipments.Controls.Add(labelTotalShipmentsValue);
        panelTotalShipments.Controls.Add(labelTotalShipments);
        panelTotalShipments.Location = new Point(3, 3);
        panelTotalShipments.Name = "panelTotalShipments";
        panelTotalShipments.Size = new Size(316, 309);
        panelTotalShipments.TabIndex = 0;
        // 
        // panelCreated
        // 
        panelCreated.Controls.Add(labelCreatedValue);
        panelCreated.Controls.Add(labelCreated);
        panelCreated.Location = new Point(325, 3);
        panelCreated.Name = "panelCreated";
        panelCreated.Size = new Size(316, 309);
        panelCreated.TabIndex = 1;
        // 
        // panelPickedUp
        // 
        panelPickedUp.Controls.Add(labelPickedUpValue);
        panelPickedUp.Controls.Add(labelPickedUp);
        panelPickedUp.Location = new Point(647, 3);
        panelPickedUp.Name = "panelPickedUp";
        panelPickedUp.Size = new Size(316, 309);
        panelPickedUp.TabIndex = 2;
        // 
        // panelInTransit
        // 
        panelInTransit.Controls.Add(labelInTransitValue);
        panelInTransit.Controls.Add(labelInTransit);
        panelInTransit.Location = new Point(3, 318);
        panelInTransit.Name = "panelInTransit";
        panelInTransit.Size = new Size(316, 309);
        panelInTransit.TabIndex = 3;
        // 
        // panelDelivered
        // 
        panelDelivered.Controls.Add(labelDeliveredValue);
        panelDelivered.Controls.Add(labelDelivered);
        panelDelivered.Location = new Point(325, 318);
        panelDelivered.Name = "panelDelivered";
        panelDelivered.Size = new Size(316, 309);
        panelDelivered.TabIndex = 4;
        // 
        // panelCancelled
        // 
        panelCancelled.Controls.Add(labelCancelledValue);
        panelCancelled.Controls.Add(labelCancelled);
        panelCancelled.Location = new Point(647, 318);
        panelCancelled.Name = "panelCancelled";
        panelCancelled.Size = new Size(316, 309);
        panelCancelled.TabIndex = 5;
        // 
        // labelTotalShipments
        // 
        labelTotalShipments.AutoSize = true;
        labelTotalShipments.Location = new Point(116, 2);
        labelTotalShipments.Name = "labelTotalShipments";
        labelTotalShipments.Size = new Size(92, 15);
        labelTotalShipments.TabIndex = 0;
        labelTotalShipments.Text = "Total Shipments";
        // 
        // labelCreated
        // 
        labelCreated.AutoSize = true;
        labelCreated.Location = new Point(107, 7);
        labelCreated.Name = "labelCreated";
        labelCreated.Size = new Size(107, 15);
        labelCreated.TabIndex = 1;
        labelCreated.Text = "Created Shipments";
        // 
        // labelPickedUp
        // 
        labelPickedUp.AutoSize = true;
        labelPickedUp.Location = new Point(143, 6);
        labelPickedUp.Name = "labelPickedUp";
        labelPickedUp.Size = new Size(60, 15);
        labelPickedUp.TabIndex = 0;
        labelPickedUp.Text = "Picked Up";
        // 
        // labelInTransit
        // 
        labelInTransit.AutoSize = true;
        labelInTransit.Location = new Point(148, 7);
        labelInTransit.Name = "labelInTransit";
        labelInTransit.Size = new Size(55, 15);
        labelInTransit.TabIndex = 0;
        labelInTransit.Text = "In Transit";
        // 
        // labelDelivered
        // 
        labelDelivered.AutoSize = true;
        labelDelivered.Location = new Point(144, 5);
        labelDelivered.Name = "labelDelivered";
        labelDelivered.Size = new Size(56, 15);
        labelDelivered.TabIndex = 0;
        labelDelivered.Text = "Delivered";
        // 
        // labelCancelled
        // 
        labelCancelled.AutoSize = true;
        labelCancelled.Location = new Point(150, 7);
        labelCancelled.Name = "labelCancelled";
        labelCancelled.Size = new Size(59, 15);
        labelCancelled.TabIndex = 0;
        labelCancelled.Text = "Cancelled";
        // 
        // labelTotalShipmentsValue
        // 
        labelTotalShipmentsValue.AutoSize = true;
        labelTotalShipmentsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelTotalShipmentsValue.Location = new Point(148, 150);
        labelTotalShipmentsValue.Name = "labelTotalShipmentsValue";
        labelTotalShipmentsValue.Size = new Size(33, 37);
        labelTotalShipmentsValue.TabIndex = 1;
        labelTotalShipmentsValue.Text = "0";
        // 
        // labelCreatedValue
        // 
        labelCreatedValue.AutoSize = true;
        labelCreatedValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelCreatedValue.Location = new Point(145, 157);
        labelCreatedValue.Name = "labelCreatedValue";
        labelCreatedValue.Size = new Size(33, 37);
        labelCreatedValue.TabIndex = 2;
        labelCreatedValue.Text = "0";
        // 
        // labelPickedUpValue
        // 
        labelPickedUpValue.AutoSize = true;
        labelPickedUpValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelPickedUpValue.Location = new Point(142, 136);
        labelPickedUpValue.Name = "labelPickedUpValue";
        labelPickedUpValue.Size = new Size(33, 37);
        labelPickedUpValue.TabIndex = 3;
        labelPickedUpValue.Text = "0";
        // 
        // labelInTransitValue
        // 
        labelInTransitValue.AutoSize = true;
        labelInTransitValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelInTransitValue.Location = new Point(142, 136);
        labelInTransitValue.Name = "labelInTransitValue";
        labelInTransitValue.Size = new Size(33, 37);
        labelInTransitValue.TabIndex = 2;
        labelInTransitValue.Text = "0";
        // 
        // labelDeliveredValue
        // 
        labelDeliveredValue.AutoSize = true;
        labelDeliveredValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelDeliveredValue.Location = new Point(142, 136);
        labelDeliveredValue.Name = "labelDeliveredValue";
        labelDeliveredValue.Size = new Size(33, 37);
        labelDeliveredValue.TabIndex = 2;
        labelDeliveredValue.Text = "0";
        // 
        // labelCancelledValue
        // 
        labelCancelledValue.AutoSize = true;
        labelCancelledValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        labelCancelledValue.Location = new Point(142, 136);
        labelCancelledValue.Name = "labelCancelledValue";
        labelCancelledValue.Size = new Size(33, 37);
        labelCancelledValue.TabIndex = 2;
        labelCancelledValue.Text = "0";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1184, 711);
        Controls.Add(contentPanel);
        Controls.Add(sidebarPanel);
        MinimumSize = new Size(1000, 650);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ParcelDesk";
        sidebarPanel.ResumeLayout(false);
        contentPanel.ResumeLayout(false);
        contentPanel.PerformLayout();
        tableLayoutPanel1.ResumeLayout(false);
        panelTotalShipments.ResumeLayout(false);
        panelTotalShipments.PerformLayout();
        panelCreated.ResumeLayout(false);
        panelCreated.PerformLayout();
        panelPickedUp.ResumeLayout(false);
        panelPickedUp.PerformLayout();
        panelInTransit.ResumeLayout(false);
        panelInTransit.PerformLayout();
        panelDelivered.ResumeLayout(false);
        panelDelivered.PerformLayout();
        panelCancelled.ResumeLayout(false);
        panelCancelled.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel sidebarPanel;
    private Button buttonCustomers;
    private Button buttonShipments;
    private Button buttonDashboard;
    private Panel contentPanel;
    private TableLayoutPanel tableLayoutPanel1;
    private Button buttonRefresh;
    private Label labelPageTitle;
    private Panel panelCancelled;
    private Panel panelDelivered;
    private Panel panelInTransit;
    private Panel panelPickedUp;
    private Panel panelCreated;
    private Label labelCreated;
    private Panel panelTotalShipments;
    private Label labelTotalShipments;
    private Label labelPickedUp;
    private Label labelCancelledValue;
    private Label labelCancelled;
    private Label labelDeliveredValue;
    private Label labelDelivered;
    private Label labelInTransitValue;
    private Label labelInTransit;
    private Label labelPickedUpValue;
    private Label labelCreatedValue;
    private Label labelTotalShipmentsValue;
}
