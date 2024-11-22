using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.Business.Services;
using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.Presentation;
using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.Business;

/// <summary>
/// TODO: Doc
/// </summary>
internal class WsysApplication {

    private WsysDbContext context;
    private AdminMainMenu adminMainMenu;
    private OfficeEmpMainMenu officeEmployeeMainMenu;
    private WhEmpMainMenu warehouseEmployeeMainMenu;
    private bool isMessageLoopStarted = false;

    public PasswordService PasswordService { get; private set; }
    public LoginService LoginService { get; private set; }
    public UserService UserService { get; private set; }
    public RoleService RoleService { get; private set; }
    public ShippingOrderService ShippingOrderService { get; private set; }
    public PurchaseOrderService PurchaseOrderService { get; private set; }
    public AdresseService AdresseService { get; private set; }
    public ExpeditionService ExpeditionService { get; private set; }


    // TODO: @ÉQUIPE ajoutez des propriétés pour vos services ici





    /// <summary>
    /// TODO: Doc
    /// </summary>
    public WsysApplication() {
        this.context = new WsysDbContext();
        this.UserService = new UserService(this, this.context);
        this.RoleService = new RoleService(this, this.context);
        this.ShippingOrderService = new ShippingOrderService(this, this.context);
        this.PurchaseOrderService = new PurchaseOrderService(this, this.context);
        this.AdresseService = new AdresseService(this, this.context);
        this.ExpeditionService = new ExpeditionService(this, this.context);

        // TODO: @ÉQUIPE ajoutez la création de vos services ici


        this.PasswordService = PasswordService.GetInstance();
        this.LoginService = new LoginService(this);
        this.adminMainMenu = new AdminMainMenu(this);
        this.officeEmployeeMainMenu = new OfficeEmpMainMenu();
        this.warehouseEmployeeMainMenu = new WhEmpMainMenu();
    }



    public void Start() {
        Application.Run(); // UI event loop without a form.
        while (true) {
            this.LoginService.RequireLoggedInUser();
            if (this.LoginService.LoggedInUserRole is null) {
                throw new Exception("Login system failure: no logged in user role loaded after login process.");
            }
            try {
                DialogResult mainMenuDialogResult;
                if (this.LoginService.LoggedInUserRole.IsAdministratorRole()) {
                    mainMenuDialogResult = this.adminMainMenu.ShowAdminMainMenu();

                } else if (this.LoginService.LoggedInUserRole.IsOfficeEmployeeRole()) {
                    mainMenuDialogResult = this.officeEmployeeMainMenu.ShowOfficeEmpMainMenu();

                } else if (this.LoginService.LoggedInUserRole.IsWarehouseEmployeeRole()) {
                    mainMenuDialogResult = this.warehouseEmployeeMainMenu.ShowWhEmpMainMenu();

                } else {
                    throw new Exception($"Role unrecognized: no main menu exists for role [{this.LoginService.LoggedInUserRole.Name}].");
                }

                if (mainMenuDialogResult == DialogResult.OK) {
                    this.LoginService.Logout();
                }

            } catch (Exception ex) {
                this.HandleException(ex);
            }
        }
    }



    public void HandleException(Exception ex) {
        string? stack = ex.StackTrace;
        StringBuilder messageBuilder = new StringBuilder();
        Console.Error.WriteLine(ex.Message);
        Debug.WriteLine(ex.Message);
        _ = messageBuilder.Append(ex.Message);
        while (ex.InnerException != null) {
            ex = ex.InnerException;
            Console.Error.WriteLine(ex.Message);
            Debug.WriteLine(ex.Message);
            _ = messageBuilder.Append(Environment.NewLine + "Caused By: " + ex.Message);
        }
        Console.Error.WriteLine("Stack trace:");
        Console.Error.WriteLine(stack);
        Debug.WriteLine("Stack trace:");
        Debug.WriteLine(stack);
        _ = MessageBox.Show(messageBuilder.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

    }

}
