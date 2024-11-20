using _420DA3_A24_Projet.Business;

namespace _420DA3_A24_Projet.Presentation.Views;
internal partial class UserView : Form {

    private WsysApplication app;

    public UserView(WsysApplication application) {
        this.app = application;
        this.InitializeComponent();
    }
}
