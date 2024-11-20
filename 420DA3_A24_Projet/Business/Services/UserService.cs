using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.DataAccess.DAOs;
using _420DA3_A24_Projet.Presentation.Views;

namespace _420DA3_A24_Projet.Business.Services;
internal class UserService {

    private WsysApplication parentApp;
    private UserDAO userDAO;
    private UserView userWindow;

    public UserService(WsysApplication parentApp, WsysDbContext context) {
        this.parentApp = parentApp;
        this.userDAO = new UserDAO(context);
        this.userWindow = new UserView(parentApp);
    }

}
