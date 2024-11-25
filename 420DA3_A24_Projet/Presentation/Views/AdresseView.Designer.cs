namespace _420DA3_A24_Projet.Presentation.Views;

partial class AdresseView {
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
        this.valueModeFentre = new Label();
        this.modeFenetreLabel = new Label();
        this.bottomBarPanel = new Panel();
        this.BtnAction = new Button();
        this.btnAnnuler = new Button();
        this.centerTblLayoutPanel = new TableLayoutPanel();
        this.centerPanel = new Panel();
        this.valuedateTimePickerDelete = new DateTimePicker();
        this.valuedateTimePickerModified = new DateTimePicker();
        this.valuedateTimePickerCreate = new DateTimePicker();
        this.dateDeleteLabel = new Label();
        this.dateModifiedLabel = new Label();
        this.dateCreateabel = new Label();
        this.valueAdresseTypeCB = new ComboBox();
        this.valuePostalCode = new TextBox();
        this.postalCodeLabel = new Label();
        this.valueCountry = new TextBox();
        this.valueState = new TextBox();
        this.valueCity = new TextBox();
        this.countryLabel = new Label();
        this.stateLabel = new Label();
        this.cityLabel = new Label();
        this.valueStreet = new TextBox();
        this.streetLabel = new Label();
        this.valueCivicNumber = new TextBox();
        this.civicNumberLabel = new Label();
        this.valueAdresss = new TextBox();
        this.adresseLabel = new Label();
        this.adresseTypeLabel = new Label();
        this.idValue = new NumericUpDown();
        this.idLabel = new Label();
        this.topBarPanel.SuspendLayout();
        this.bottomBarPanel.SuspendLayout();
        this.centerTblLayoutPanel.SuspendLayout();
        this.centerPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) this.idValue).BeginInit();
        this.SuspendLayout();
        // 
        // topBarPanel
        // 
        this.topBarPanel.Controls.Add(this.valueModeFentre);
        this.topBarPanel.Controls.Add(this.modeFenetreLabel);
        this.topBarPanel.Dock = DockStyle.Top;
        this.topBarPanel.Location = new Point(0, 0);
        this.topBarPanel.Name = "topBarPanel";
        this.topBarPanel.Size = new Size(1212, 50);
        this.topBarPanel.TabIndex = 0;
        // 
        // valueModeFentre
        // 
        this.valueModeFentre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.valueModeFentre.Location = new Point(178, 9);
        this.valueModeFentre.Name = "valueModeFentre";
        this.valueModeFentre.Size = new Size(254, 32);
        this.valueModeFentre.TabIndex = 2;
        this.valueModeFentre.Text = "PLACEHORDER";
        this.valueModeFentre.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // modeFenetreLabel
        // 
        this.modeFenetreLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.modeFenetreLabel.Location = new Point(12, 9);
        this.modeFenetreLabel.Name = "modeFenetreLabel";
        this.modeFenetreLabel.Size = new Size(150, 38);
        this.modeFenetreLabel.TabIndex = 1;
        this.modeFenetreLabel.Text = "Model Fenetre";
        this.modeFenetreLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // bottomBarPanel
        // 
        this.bottomBarPanel.Controls.Add(this.BtnAction);
        this.bottomBarPanel.Controls.Add(this.btnAnnuler);
        this.bottomBarPanel.Dock = DockStyle.Bottom;
        this.bottomBarPanel.Location = new Point(0, 670);
        this.bottomBarPanel.Name = "bottomBarPanel";
        this.bottomBarPanel.Size = new Size(1212, 50);
        this.bottomBarPanel.TabIndex = 1;
        // 
        // BtnAction
        // 
        this.BtnAction.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        this.BtnAction.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.BtnAction.Location = new Point(809, 6);
        this.BtnAction.Name = "BtnAction";
        this.BtnAction.Size = new Size(193, 41);
        this.BtnAction.TabIndex = 1;
        this.BtnAction.Text = "Action";
        this.BtnAction.UseVisualStyleBackColor = true;
        this.BtnAction.Click += this.BtnAction_Click;
        // 
        // btnAnnuler
        // 
        this.btnAnnuler.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        this.btnAnnuler.Location = new Point(1029, 6);
        this.btnAnnuler.Name = "btnAnnuler";
        this.btnAnnuler.Size = new Size(148, 41);
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
        this.centerTblLayoutPanel.Location = new Point(0, 50);
        this.centerTblLayoutPanel.Name = "centerTblLayoutPanel";
        this.centerTblLayoutPanel.RowCount = 1;
        this.centerTblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        this.centerTblLayoutPanel.Size = new Size(1212, 620);
        this.centerTblLayoutPanel.TabIndex = 2;
        // 
        // centerPanel
        // 
        this.centerPanel.Controls.Add(this.valuedateTimePickerDelete);
        this.centerPanel.Controls.Add(this.valuedateTimePickerModified);
        this.centerPanel.Controls.Add(this.valuedateTimePickerCreate);
        this.centerPanel.Controls.Add(this.dateDeleteLabel);
        this.centerPanel.Controls.Add(this.dateModifiedLabel);
        this.centerPanel.Controls.Add(this.dateCreateabel);
        this.centerPanel.Controls.Add(this.valueAdresseTypeCB);
        this.centerPanel.Controls.Add(this.valuePostalCode);
        this.centerPanel.Controls.Add(this.postalCodeLabel);
        this.centerPanel.Controls.Add(this.valueCountry);
        this.centerPanel.Controls.Add(this.valueState);
        this.centerPanel.Controls.Add(this.valueCity);
        this.centerPanel.Controls.Add(this.countryLabel);
        this.centerPanel.Controls.Add(this.stateLabel);
        this.centerPanel.Controls.Add(this.cityLabel);
        this.centerPanel.Controls.Add(this.valueStreet);
        this.centerPanel.Controls.Add(this.streetLabel);
        this.centerPanel.Controls.Add(this.valueCivicNumber);
        this.centerPanel.Controls.Add(this.civicNumberLabel);
        this.centerPanel.Controls.Add(this.valueAdresss);
        this.centerPanel.Controls.Add(this.adresseLabel);
        this.centerPanel.Controls.Add(this.adresseTypeLabel);
        this.centerPanel.Controls.Add(this.idValue);
        this.centerPanel.Controls.Add(this.idLabel);
        this.centerPanel.Dock = DockStyle.Fill;
        this.centerPanel.Location = new Point(359, 3);
        this.centerPanel.Name = "centerPanel";
        this.centerPanel.Size = new Size(494, 614);
        this.centerPanel.TabIndex = 0;
        // 
        // valuedateTimePickerDelete
        // 
        this.valuedateTimePickerDelete.Enabled = false;
        this.valuedateTimePickerDelete.Location = new Point(196, 548);
        this.valuedateTimePickerDelete.Name = "valuedateTimePickerDelete";
        this.valuedateTimePickerDelete.Size = new Size(295, 31);
        this.valuedateTimePickerDelete.TabIndex = 24;
        // 
        // valuedateTimePickerModified
        // 
        this.valuedateTimePickerModified.Enabled = false;
        this.valuedateTimePickerModified.Location = new Point(196, 496);
        this.valuedateTimePickerModified.Name = "valuedateTimePickerModified";
        this.valuedateTimePickerModified.Size = new Size(295, 31);
        this.valuedateTimePickerModified.TabIndex = 23;
        // 
        // valuedateTimePickerCreate
        // 
        this.valuedateTimePickerCreate.Enabled = false;
        this.valuedateTimePickerCreate.Location = new Point(196, 444);
        this.valuedateTimePickerCreate.Name = "valuedateTimePickerCreate";
        this.valuedateTimePickerCreate.Size = new Size(295, 31);
        this.valuedateTimePickerCreate.TabIndex = 22;
        // 
        // dateDeleteLabel
        // 
        this.dateDeleteLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.dateDeleteLabel.Location = new Point(13, 550);
        this.dateDeleteLabel.Name = "dateDeleteLabel";
        this.dateDeleteLabel.Size = new Size(150, 31);
        this.dateDeleteLabel.TabIndex = 21;
        this.dateDeleteLabel.Text = "Date Delete:";
        this.dateDeleteLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dateModifiedLabel
        // 
        this.dateModifiedLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.dateModifiedLabel.Location = new Point(13, 496);
        this.dateModifiedLabel.Name = "dateModifiedLabel";
        this.dateModifiedLabel.Size = new Size(150, 31);
        this.dateModifiedLabel.TabIndex = 20;
        this.dateModifiedLabel.Text = "Date Modified:";
        this.dateModifiedLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dateCreateabel
        // 
        this.dateCreateabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.dateCreateabel.Location = new Point(13, 446);
        this.dateCreateabel.Name = "dateCreateabel";
        this.dateCreateabel.Size = new Size(150, 31);
        this.dateCreateabel.TabIndex = 19;
        this.dateCreateabel.Text = "Date Create:";
        this.dateCreateabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // valueAdresseTypeCB
        // 
        this.valueAdresseTypeCB.FormattingEnabled = true;
        this.valueAdresseTypeCB.Location = new Point(198, 49);
        this.valueAdresseTypeCB.Name = "valueAdresseTypeCB";
        this.valueAdresseTypeCB.Size = new Size(293, 33);
        this.valueAdresseTypeCB.TabIndex = 18;
        // 
        // valuePostalCode
        // 
        this.valuePostalCode.Location = new Point(196, 386);
        this.valuePostalCode.Name = "valuePostalCode";
        this.valuePostalCode.Size = new Size(295, 31);
        this.valuePostalCode.TabIndex = 17;
        // 
        // postalCodeLabel
        // 
        this.postalCodeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.postalCodeLabel.Location = new Point(13, 386);
        this.postalCodeLabel.Name = "postalCodeLabel";
        this.postalCodeLabel.Size = new Size(150, 31);
        this.postalCodeLabel.TabIndex = 16;
        this.postalCodeLabel.Text = "Postal Code:";
        this.postalCodeLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // valueCountry
        // 
        this.valueCountry.Location = new Point(196, 341);
        this.valueCountry.Name = "valueCountry";
        this.valueCountry.Size = new Size(295, 31);
        this.valueCountry.TabIndex = 15;
        // 
        // valueState
        // 
        this.valueState.Location = new Point(198, 298);
        this.valueState.Name = "valueState";
        this.valueState.Size = new Size(293, 31);
        this.valueState.TabIndex = 14;
        // 
        // valueCity
        // 
        this.valueCity.Location = new Point(198, 248);
        this.valueCity.Name = "valueCity";
        this.valueCity.Size = new Size(293, 31);
        this.valueCity.TabIndex = 13;
        // 
        // countryLabel
        // 
        this.countryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.countryLabel.Location = new Point(13, 341);
        this.countryLabel.Name = "countryLabel";
        this.countryLabel.Size = new Size(150, 31);
        this.countryLabel.TabIndex = 12;
        this.countryLabel.Text = "Country:";
        this.countryLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // stateLabel
        // 
        this.stateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.stateLabel.Location = new Point(13, 298);
        this.stateLabel.Name = "stateLabel";
        this.stateLabel.Size = new Size(150, 31);
        this.stateLabel.TabIndex = 11;
        this.stateLabel.Text = "State:";
        this.stateLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // cityLabel
        // 
        this.cityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.cityLabel.Location = new Point(13, 248);
        this.cityLabel.Name = "cityLabel";
        this.cityLabel.Size = new Size(150, 31);
        this.cityLabel.TabIndex = 10;
        this.cityLabel.Text = "City:";
        this.cityLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // valueStreet
        // 
        this.valueStreet.Location = new Point(198, 193);
        this.valueStreet.Name = "valueStreet";
        this.valueStreet.Size = new Size(293, 31);
        this.valueStreet.TabIndex = 9;
        // 
        // streetLabel
        // 
        this.streetLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.streetLabel.Location = new Point(13, 193);
        this.streetLabel.Name = "streetLabel";
        this.streetLabel.Size = new Size(150, 31);
        this.streetLabel.TabIndex = 8;
        this.streetLabel.Text = "Street:";
        this.streetLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // valueCivicNumber
        // 
        this.valueCivicNumber.Location = new Point(198, 141);
        this.valueCivicNumber.Name = "valueCivicNumber";
        this.valueCivicNumber.Size = new Size(293, 31);
        this.valueCivicNumber.TabIndex = 7;
        // 
        // civicNumberLabel
        // 
        this.civicNumberLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.civicNumberLabel.Location = new Point(13, 141);
        this.civicNumberLabel.Name = "civicNumberLabel";
        this.civicNumberLabel.Size = new Size(150, 31);
        this.civicNumberLabel.TabIndex = 6;
        this.civicNumberLabel.Text = "Civic Number :\r\n";
        this.civicNumberLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // valueAdresss
        // 
        this.valueAdresss.Location = new Point(198, 96);
        this.valueAdresss.Name = "valueAdresss";
        this.valueAdresss.Size = new Size(293, 31);
        this.valueAdresss.TabIndex = 5;
        // 
        // adresseLabel
        // 
        this.adresseLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.adresseLabel.Location = new Point(13, 96);
        this.adresseLabel.Name = "adresseLabel";
        this.adresseLabel.Size = new Size(150, 31);
        this.adresseLabel.TabIndex = 4;
        this.adresseLabel.Text = "Adresse:\r\n";
        this.adresseLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // adresseTypeLabel
        // 
        this.adresseTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.adresseTypeLabel.Location = new Point(13, 52);
        this.adresseTypeLabel.Name = "adresseTypeLabel";
        this.adresseTypeLabel.Size = new Size(150, 31);
        this.adresseTypeLabel.TabIndex = 2;
        this.adresseTypeLabel.Text = "AdresseType:\r\n";
        this.adresseTypeLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // idValue
        // 
        this.idValue.Enabled = false;
        this.idValue.Location = new Point(198, 12);
        this.idValue.Maximum = new decimal(new int[] { -1539607552, 11, 0, 0 });
        this.idValue.Name = "idValue";
        this.idValue.Size = new Size(230, 31);
        this.idValue.TabIndex = 1;
        // 
        // idLabel
        // 
        this.idLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        this.idLabel.Location = new Point(13, 15);
        this.idLabel.Name = "idLabel";
        this.idLabel.Size = new Size(150, 25);
        this.idLabel.TabIndex = 0;
        this.idLabel.Text = "ID:\r\n";
        this.idLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // AdresseView
        // 
        this.AutoScaleDimensions = new SizeF(10F, 25F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1212, 720);
        this.Controls.Add(this.centerTblLayoutPanel);
        this.Controls.Add(this.bottomBarPanel);
        this.Controls.Add(this.topBarPanel);
        this.MinimumSize = new Size(500, 0);
        this.Name = "AdresseView";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Gestion des Adresses";
        this.topBarPanel.ResumeLayout(false);
        this.bottomBarPanel.ResumeLayout(false);
        this.centerTblLayoutPanel.ResumeLayout(false);
        this.centerPanel.ResumeLayout(false);
        this.centerPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize) this.idValue).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private Panel topBarPanel;
    private Panel bottomBarPanel;
    private TableLayoutPanel centerTblLayoutPanel;
    private Button BtnAction;
    private Button btnAnnuler;
    private Panel centerPanel;
    private Label idLabel;
    private NumericUpDown idValue;
    private Label adresseTypeLabel;
    private Label adresseLabel;
    private TextBox valueAdresss;
    private Label civicNumberLabel;
    private Label streetLabel;
    private TextBox valueCivicNumber;
    private TextBox valueStreet;
    private Label countryLabel;
    private Label stateLabel;
    private Label cityLabel;
    private TextBox valueCountry;
    private TextBox valueState;
    private TextBox valueCity;
    private TextBox valuePostalCode;
    private Label postalCodeLabel;
    private ComboBox valueAdresseTypeCB;
    private Label dateDeleteLabel;
    private Label dateModifiedLabel;
    private Label dateCreateabel;
    private DateTimePicker valuedateTimePickerDelete;
    private DateTimePicker valuedateTimePickerModified;
    private DateTimePicker valuedateTimePickerCreate;
    private Label valueModeFentre;
    private Label modeFenetreLabel;
}