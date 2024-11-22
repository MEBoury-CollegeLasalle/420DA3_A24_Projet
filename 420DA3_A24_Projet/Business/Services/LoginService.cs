using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.Presentation;
using Project_Utilities.Exceptions;

namespace _420DA3_A24_Projet.Business.Services;
internal class LoginService {
    private WsysApplication parentApp;
    private LoginWindow loginWindow;
    private RoleSelectionWindow roleSelectionWindow;

    public User? LoggedInUser { get; private set; }
    public Role? LoggedInUserRole { get; private set; }

    public LoginService(WsysApplication parentApp) {
        this.parentApp = parentApp;
        this.loginWindow = new LoginWindow(parentApp);
        this.roleSelectionWindow = new RoleSelectionWindow(parentApp);
    }


    public void RequireLoggedInUser() {
        if (this.LoggedInUser == null) {
            DialogResult loginResult = this.loginWindow.ShowLoginWindow();
            if (loginResult != DialogResult.OK) {
                Application.Exit();
            }
        }
    }

    public void TryLogin(string username, string password) {
        User? user = this.parentApp.UserService.GetUserByUsername(username) ?? throw new UserNotFoundException($"Nom d'utilisateur [{username}] invalide.");
        if (!this.parentApp.PasswordService.ValidatePassword(password, user.PasswordHash)) {
            throw new InvalidPasswordException("Mot de passe invalide.");
        }
        if (user.Roles.Count <= 0) {
            // Utilisateur n'a pas de rôle
            throw new Exception("Aucun rôle associé à cet utilisateur.");

        } else if (user.Roles.Count > 1) {
            // Utilisateur a plusieurs rôles
            DialogResult result = this.roleSelectionWindow.OpenForUser(user);
            this.LoggedInUserRole = result != DialogResult.OK
                ? throw new Exception("Impossible de continuer, processus de sélection de rôle interrompu anormalement.")
                : this.roleSelectionWindow.SelectedRole;

        } else {
            // Utilisateur a un seul rôle
            this.LoggedInUserRole = user.Roles[0];

        }
        this.LoggedInUser = user;
    }

    public void Logout() {
        this.LoggedInUser = null;
        this.LoggedInUserRole = null;
    }
}
