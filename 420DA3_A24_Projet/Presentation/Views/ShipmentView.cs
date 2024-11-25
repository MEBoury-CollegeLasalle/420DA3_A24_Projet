using _420DA3_A24_Projet.Business;
using _420DA3_A24_Projet.Business.Domain;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _420DA3_A24_Projet.Presentation.Views;
internal partial class ShipmentView : Form {
    private readonly ProjectApplication parentApp;

    public Shipment CurrentInstance { get; private set; }
    public ViewActionsEnum CurrentAction { get; private set; }

    public ShipmentView(ProjectApplication parentApp) {
        this.parentApp = parentApp;
        this.InitializeComponent();
    }



   

    public DialogResult GetCurrentInstance() {

    }

    public DialogResult OpenForViewAction(ViewActionsEnum action, Shipment? = null) {
    

    }

    private void LoadInstanceInControls(Shipment? shipment) {

    }

    private void EnableEditableControls() {
        this.valueShipmentStatus.Enabled = true;
        this.valueShippingServices.Enabled = true;
        this.valueTrackingNumber.Enabled = true;

    }
    private void DisnableEditableControls() {
        this.valueShipmentStatus.Enabled = false;
        this.valueShippingServices.Enabled = false;
        this.valueTrackingNumber.Enabled = false;
    }
    private void ProcessAction() {

    }

    private void ValidateControlsForAction(Shipment? shipment) {

    }

    private void btnAction_Click(object sender, EventArgs e) {
        try {
            this.ProcessAction();
            this.DialogResult = DialogResult.OK;
        } catch (Exception ex) {
            //TODO @maguette afficher erreur
        }

    }

    private void btnAnnuler_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
    }

}
