using _420DA3_A24_Projet.Business.Services;
using _420DA3_A24_Projet.DataAccess.Contexts;

namespace _420DA3_A24_Projet.Business;

/// <summary>
/// TODO: Doc
/// </summary>
internal class WsysApplication {

    private WsysDbContext context;

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
        this.UserService = new UserService();
        this.RoleService = new RoleService();
        this.ShippingOrderService = new ShippingOrderService();
        this.PurchaseOrderService = new PurchaseOrderService();

        // TODO: @ÉQUIPE ajoutez la création de vos services ici

    }

}
