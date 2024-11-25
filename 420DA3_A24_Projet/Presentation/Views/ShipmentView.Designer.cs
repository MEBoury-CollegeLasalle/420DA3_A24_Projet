namespace _420DA3_A24_Projet.Presentation.Views;

partial class ShipmentView {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.topBarPanel = new Panel();
        this.bottomBarPanel = new Panel();
        this.btnAction = new Button();
        this.btnAnnuler = new Button();
        this.centerTblLayoutPanel = new TableLayoutPanel();
        this.centerPanel = new Panel();
        this.valuedateTimePickerDelete = new DateTimePicker();
        this.valuedateTimePickerModified = new DateTimePicker();
        this.valuedateTimePickerCreate = new DateTimePicker();
        this.lblDateDelete = new Label();
        this.lblDateCreate = new Label();
        this.valueTrackingNumber = new TextBox();
        this.valueShippingOrderld = new NumericUpDown();
        this.valueShippingServices = new ComboBox();
        this.label3 = new Label();
        this.lblShippingOrderld = new Label();
        this.lblShippingtServices = new Label();
        this.valueShipmentStatus = new ComboBox();
        this.lblShipmentStatus = new Label();
        this.valueId = new NumericUpDown();
        this.labelId = new Label();
        this.label1 = new Label();
        this.bottomBarPanel.SuspendLayout();
        this.centerTblLayoutPanel.SuspendLayout();
        this.centerPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) this.valueShippingOrderld).BeginInit();
        ((System.ComponentModel.ISupportInitialize) this.valueId).BeginInit();
        this.SuspendLayout();
        // 
        // topBarPanel
        // 
        this.topBarPanel.Dock = DockStyle.Top;
        this.topBarPanel.Location = new Point(0, 0);
        this.topBarPanel.Name = "topBarPanel";
        this.topBarPanel.Size = new Size(1024, 47);
        this.topBarPanel.TabIndex = 1;
        // 
        // bottomBarPanel
        // 
        this.bottomBarPanel.Controls.Add(this.btnAction);
        this.bottomBarPanel.Controls.Add(this.btnAnnuler);
        this.bottomBarPanel.Dock = DockStyle.Bottom;
        this.bottomBarPanel.Location = new Point(0, 562);
        this.bottomBarPanel.Name = "bottomBarPanel";
        this.bottomBarPanel.Size = new Size(1024, 51);
        this.bottomBarPanel.TabIndex = 2;
        // 
        // btnAction
        // 
        this.btnAction.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        this.btnAction.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.btnAction.Location = new Point(664, 3);
        this.btnAction.Name = "btnAction";
        this.btnAction.Size = new Size(172, 45);
        this.btnAction.TabIndex = 1;
        this.btnAction.Text = "Action";
        this.btnAction.UseVisualStyleBackColor = true;
        this.btnAction.Click += this.btnAction_Click;
        // 
        // btnAnnuler
        // 
        this.btnAnnuler.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        this.btnAnnuler.Location = new Point(861, 3);
        this.btnAnnuler.Name = "btnAnnuler";
        this.btnAnnuler.Size = new Size(140, 45);
        this.btnAnnuler.TabIndex = 0;
        this.btnAnnuler.Text = "Annuler";
        this.btnAnnuler.UseVisualStyleBackColor = true;
        this.btnAnnuler.Click += this.btnAnnuler_Click;
        // 
        // centerTblLayoutPanel
        // 
        this.centerTblLayoutPanel.ColumnCount = 3;
        this.centerTblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        this.centerTblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
        this.centerTblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        this.centerTblLayoutPanel.Controls.Add(this.centerPanel, 1, 0);
        this.centerTblLayoutPanel.Dock = DockStyle.Fill;
        this.centerTblLayoutPanel.Location = new Point(0, 47);
        this.centerTblLayoutPanel.Name = "centerTblLayoutPanel";
        this.centerTblLayoutPanel.RowCount = 1;
        this.centerTblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.centerTblLayoutPanel.Size = new Size(1024, 515);
        this.centerTblLayoutPanel.TabIndex = 3;
        // 
        // centerPanel
        // 
        this.centerPanel.Controls.Add(this.label1);
        this.centerPanel.Controls.Add(this.valuedateTimePickerDelete);
        this.centerPanel.Controls.Add(this.valuedateTimePickerModified);
        this.centerPanel.Controls.Add(this.valuedateTimePickerCreate);
        this.centerPanel.Controls.Add(this.lblDateDelete);
        this.centerPanel.Controls.Add(this.lblDateCreate);
        this.centerPanel.Controls.Add(this.valueTrackingNumber);
        this.centerPanel.Controls.Add(this.valueShippingOrderld);
        this.centerPanel.Controls.Add(this.valueShippingServices);
        this.centerPanel.Controls.Add(this.label3);
        this.centerPanel.Controls.Add(this.lblShippingOrderld);
        this.centerPanel.Controls.Add(this.lblShippingtServices);
        this.centerPanel.Controls.Add(this.valueShipmentStatus);
        this.centerPanel.Controls.Add(this.lblShipmentStatus);
        this.centerPanel.Controls.Add(this.valueId);
        this.centerPanel.Controls.Add(this.labelId);
        this.centerPanel.Dock = DockStyle.Fill;
        this.centerPanel.Location = new Point(265, 3);
        this.centerPanel.Name = "centerPanel";
        this.centerPanel.Size = new Size(494, 509);
        this.centerPanel.TabIndex = 0;
        // 
        // valuedateTimePickerDelete
        // 
        this.valuedateTimePickerDelete.Enabled = false;
        this.valuedateTimePickerDelete.Location = new Point(199, 404);
        this.valuedateTimePickerDelete.Name = "valuedateTimePickerDelete";
        this.valuedateTimePickerDelete.Size = new Size(295, 31);
        this.valuedateTimePickerDelete.TabIndex = 30;
        // 
        // valuedateTimePickerModified
        // 
        this.valuedateTimePickerModified.Enabled = false;
        this.valuedateTimePickerModified.Location = new Point(196, 341);
        this.valuedateTimePickerModified.Name = "valuedateTimePickerModified";
        this.valuedateTimePickerModified.Size = new Size(295, 31);
        this.valuedateTimePickerModified.TabIndex = 29;
        // 
        // valuedateTimePickerCreate
        // 
        this.valuedateTimePickerCreate.Enabled = false;
        this.valuedateTimePickerCreate.Location = new Point(196, 276);
        this.valuedateTimePickerCreate.Name = "valuedateTimePickerCreate";
        this.valuedateTimePickerCreate.Size = new Size(298, 31);
        this.valuedateTimePickerCreate.TabIndex = 28;
        // 
        // lblDateDelete
        // 
        this.lblDateDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblDateDelete.Location = new Point(40, 404);
        this.lblDateDelete.Name = "lblDateDelete";
        this.lblDateDelete.Size = new Size(150, 31);
        this.lblDateDelete.TabIndex = 27;
        this.lblDateDelete.Text = "Date Delete:";
        this.lblDateDelete.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblDateCreate
        // 
        this.lblDateCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblDateCreate.Location = new Point(40, 276);
        this.lblDateCreate.Name = "lblDateCreate";
        this.lblDateCreate.Size = new Size(150, 31);
        this.lblDateCreate.TabIndex = 25;
        this.lblDateCreate.Text = "Date Create:";
        this.lblDateCreate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // valueTrackingNumber
        // 
        this.valueTrackingNumber.Location = new Point(196, 226);
        this.valueTrackingNumber.Name = "valueTrackingNumber";
        this.valueTrackingNumber.Size = new Size(294, 31);
        this.valueTrackingNumber.TabIndex = 10;
        // 
        // valueShippingOrderld
        // 
        this.valueShippingOrderld.Location = new Point(196, 168);
        this.valueShippingOrderld.Name = "valueShippingOrderld";
        this.valueShippingOrderld.Size = new Size(295, 31);
        this.valueShippingOrderld.TabIndex = 9;
        // 
        // valueShippingServices
        // 
        this.valueShippingServices.FormattingEnabled = true;
        this.valueShippingServices.Location = new Point(196, 114);
        this.valueShippingServices.Name = "valueShippingServices";
        this.valueShippingServices.Size = new Size(295, 33);
        this.valueShippingServices.TabIndex = 8;
        // 
        // label3
        // 
        this.label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.label3.Location = new Point(3, 228);
        this.label3.Name = "label3";
        this.label3.Size = new Size(187, 31);
        this.label3.TabIndex = 6;
        this.label3.Text = "Tracking Number:";
        this.label3.TextAlign = ContentAlignment.TopRight;
        // 
        // lblShippingOrderld
        // 
        this.lblShippingOrderld.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblShippingOrderld.Location = new Point(3, 170);
        this.lblShippingOrderld.Name = "lblShippingOrderld";
        this.lblShippingOrderld.Size = new Size(187, 31);
        this.lblShippingOrderld.TabIndex = 5;
        this.lblShippingOrderld.Text = "Shipping Order:";
        this.lblShippingOrderld.TextAlign = ContentAlignment.TopRight;
        // 
        // lblShippingtServices
        // 
        this.lblShippingtServices.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblShippingtServices.Location = new Point(3, 117);
        this.lblShippingtServices.Name = "lblShippingtServices";
        this.lblShippingtServices.Size = new Size(187, 31);
        this.lblShippingtServices.TabIndex = 4;
        this.lblShippingtServices.Text = "Shipping Services: ";
        this.lblShippingtServices.TextAlign = ContentAlignment.TopRight;
        // 
        // valueShipmentStatus
        // 
        this.valueShipmentStatus.FormattingEnabled = true;
        this.valueShipmentStatus.Location = new Point(196, 59);
        this.valueShipmentStatus.Name = "valueShipmentStatus";
        this.valueShipmentStatus.Size = new Size(295, 33);
        this.valueShipmentStatus.TabIndex = 3;
        // 
        // lblShipmentStatus
        // 
        this.lblShipmentStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.lblShipmentStatus.Location = new Point(3, 61);
        this.lblShipmentStatus.Name = "lblShipmentStatus";
        this.lblShipmentStatus.Size = new Size(187, 31);
        this.lblShipmentStatus.TabIndex = 2;
        this.lblShipmentStatus.Text = "Status:";
        this.lblShipmentStatus.TextAlign = ContentAlignment.TopRight;
        // 
        // valueId
        // 
        this.valueId.Location = new Point(199, 10);
        this.valueId.Name = "valueId";
        this.valueId.Size = new Size(234, 31);
        this.valueId.TabIndex = 1;
        // 
        // labelId
        // 
        this.labelId.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.labelId.Location = new Point(3, 10);
        this.labelId.Name = "labelId";
        this.labelId.Size = new Size(187, 31);
        this.labelId.TabIndex = 0;
        this.labelId.Text = "ID:";
        this.labelId.TextAlign = ContentAlignment.TopRight;
        // 
        // label1
        // 
        this.label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.label1.Location = new Point(40, 343);
        this.label1.Name = "label1";
        this.label1.Size = new Size(150, 31);
        this.label1.TabIndex = 31;
        this.label1.Text = "Date Modified:";
        this.label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // ShipmentView
        // 
        this.AutoScaleDimensions = new SizeF(10F, 25F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1024, 613);
        this.Controls.Add(this.centerTblLayoutPanel);
        this.Controls.Add(this.bottomBarPanel);
        this.Controls.Add(this.topBarPanel);
        this.Name = "ShipmentView";
        this.Text = "ShipmentView";
        this.bottomBarPanel.ResumeLayout(false);
        this.centerTblLayoutPanel.ResumeLayout(false);
        this.centerPanel.ResumeLayout(false);
        this.centerPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize) this.valueShippingOrderld).EndInit();
        ((System.ComponentModel.ISupportInitialize) this.valueId).EndInit();
        this.ResumeLayout(false);
    }

    #endregion
    private Panel topBarPanel;
    private Panel bottomBarPanel;
    private Button btnAnnuler;
    private Button btnAction;
    private TableLayoutPanel centerTblLayoutPanel;
    private Panel centerPanel;
    private Label labelId;
    private NumericUpDown valueId;
    private Label lblShipmentStatus;
    private ComboBox valueShipmentStatus;
    private Label label4;
    private Label label3;
    private Label lblShippingOrderld;
    private Label lblShippingtServices;
    private ComboBox valueShippingServices;
    private NumericUpDown valueShippingOrderld;
    private TextBox valueTrackingNumber;
    private DateTimePicker valuedateTimePickerDelete;
    private DateTimePicker valuedateTimePickerModified;
    private DateTimePicker valuedateTimePickerCreate;
    private Label lblDateDelete;
    private Label dateModifiedLabel;
    private Label lblDateCreate;
    private Label label1;
}