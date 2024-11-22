using _420DA3_A24_Projet.Business;

namespace _420DA3_A24_Projet.Presentation;
internal partial class AdminMainMenu : Form {

    private WsysApplication parentApp;

    public AdminMainMenu(WsysApplication application) {
        this.parentApp = application;
        this.InitializeComponent();
    }

    public DialogResult ShowAdminMainMenu() {
        return this.ShowDialog();
    }
}
