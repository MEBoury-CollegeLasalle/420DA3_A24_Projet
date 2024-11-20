using _420DA3_A24_Projet.Business.Services;
using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.Presentation;

namespace _420DA3_A24_Projet.Business;

/// <summary>
/// TODO: Doc
/// </summary>
internal class WsysApplication {

    private WsysDbContext context;
    private AdminMainMenu adminMainMenu;
    private OfficeEmpMainMenu officeEmployeeMainMenu;
    private WhEmpMainMenu warehouseEmployeeMainMenu;

    public UserService UserService { get; private set; }
    public RoleService RoleService { get; private set; }
    public ShippingOrderService ShippingOrderService { get; private set; }
    public PurchaseOrderService PurchaseOrderService { get; private set; }

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

        // TODO: @ÉQUIPE ajoutez la création de vos services ici



        this.adminMainMenu = new AdminMainMenu();
        this.officeEmployeeMainMenu = new OfficeEmpMainMenu();
        this.warehouseEmployeeMainMenu = new WhEmpMainMenu();
    }

}
