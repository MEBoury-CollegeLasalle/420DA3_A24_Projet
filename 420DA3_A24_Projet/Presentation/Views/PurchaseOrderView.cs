using _420DA3_A24_Projet.Business;

namespace _420DA3_A24_Projet.Presentation.Views;
internal partial class PurchaseOrderView : Form {

    private WsysApplication app;

    public PurchaseOrderView(WsysApplication application) {
        this.app = application;
        this.InitializeComponent();
    }
}
