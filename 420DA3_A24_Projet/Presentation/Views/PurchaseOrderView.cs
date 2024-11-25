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
internal partial class PurchaseOrderView : Form {

    private readonly ProjectApplication application;
    private ViewActionsEnum currentAction;
    private PurchaseOrder? currentInstance;
    public PurchaseOrderView(ProjectApplication app) {
        this.application = app;
        this.currentAction = ViewActionsEnum.Visualization;
        this.InitializeComponent();
        //this.copyrightLabel.Text = this.application.GetCopyrightNotice();
    }

    public PurchaseOrder? GetCurrentinstance() {
        return this.currentInstance;
    }

    public DialogResult OpenFor(ViewActionsEnum currentAction, PurchaseOrder? purchaseOrder = null) {
        this.currentAction = currentAction;
        this.LoadInstanceInControls(purchaseOrder);
        switch (currentAction) {
            case ViewActionsEnum.Creation:
                //labels && buttons
                this.EnableEditableControls();
                break;
            case ViewActionsEnum.Visualization:
                if(purchaseOrder is null) {
                    throw new ArgumentException($"PArameter [purchaseOrder] cannot be null for view action [{currentAction}].");
                }
                //labels && buttons
                this.DisableEditableControls();
                break;
            case ViewActionsEnum.Edition:
                if (purchaseOrder is null) {
                    throw new ArgumentException($"PArameter [purchaseOrder] cannot be null for view action [{currentAction}].");
                }
                //labels && buttons
                this.EnableEditableControls();
                break;
            case ViewActionsEnum.Deletion:
                if (purchaseOrder is null) {
                    throw new ArgumentException($"PArameter [purchaseOrder] cannot be null for view action [{currentAction}].");
                }
                //labels && buttons
                this.DisableEditableControls();
                break;
            default:
                throw new NotImplementedException($"View action [{currentAction}] is not implemented.");
        }
        return this.ShowDialog();
    }

    public void LoadInstanceInControls(PurchaseOrder? purchaseOrder) {
        if(purchaseOrder is null) {
            //affectations
        } else {
            //affectations
        }
        this.currentInstance = purchaseOrder;
    }


    private void EnableEditableControls() {
        //enables
    }
    private void DisableEditableControls() {
        //disables
    }

    //CancelButton when Clicked

    //ActionButton when Clicked

    private void ProccessAction() {
        this.ValidateContolsForAction();
        switch (this.currentAction) {
            case ViewActionsEnum.Creation:
                PurchaseOrder newPurchaseOrder = new PurchaseOrder(
                    //trims
                );
                this.currentInstance = this.application.PurchaseOrderService.Create(newPurchaseOrder);
                break;
            case ViewActionsEnum.Visualization:
                //nothing
                break;
            case ViewActionsEnum.Edition:
                if(this.currentInstance == null) {
                    throw new Exception("No current instance of [PurchaseOrder] loaded.");
                }
                //affections of trims
                break;
            case ViewActionsEnum.Deletion:
                if (this.currentInstance == null) {
                    throw new Exception("No current instance of [PurchaseOrder] loaded.");
                }
                this.application.PurchaseOrderService.Delete(this.currentInstance);
                break;
            default:
                throw new NotImplementedException($"View action [{this.currentAction}] is not implemented.");

        }
    }


    
}
