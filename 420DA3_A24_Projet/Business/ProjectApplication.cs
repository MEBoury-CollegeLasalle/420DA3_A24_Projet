using _420DA3_A24_Projet.Business.Services;
using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business;
internal class ProjectApplication {
    private readonly WsysDbContext dbContext;
    private readonly MainMenu mainMenu;

    public SupplierService SupplierService { get; private set; }
    public PurchaseOrderService PurchaseOrderService { get; private set; }

    public AdresseServices AdresseServices { get; private set; }
    public ShipmentServices ShipmentServices { get; private set; }
    public TrackingNumberFactory TrackingNumberFactory { get; private set; }

    public ProjectApplication() {
        ApplicationConfiguration.Initialize();
        this.dbContext = new WsysDbContext();
        this.SupplierService = new SupplierService(this, this.dbContext);
        this.PurchaseOrderService = new PurchaseOrderService(this, this.dbContext);
        this.AdresseServices = new AdresseServices(this,this.dbContext);
        this.ShipmentServices = new ShipmentServices(this,this.dbContext);
        this.mainMenu = new MainMenu(this);
    }

    public void HandleException(Exception ex) {
        string? stack = ex.StackTrace;
        StringBuilder messageBuilder = new StringBuilder();
        Console.Error.WriteLine(ex.Message);
        _ = messageBuilder.Append(ex.Message);
        while (ex.InnerException != null) {
            ex = ex.InnerException;
            Console.Error.WriteLine(ex.Message);
            _ = messageBuilder.Append(Environment.NewLine + "Caused By: " + ex.Message);
        }
        Console.Error.WriteLine("Stack trace:");
        Console.Error.WriteLine(stack);
        _ = MessageBox.Show(messageBuilder.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public string GetCopyrightNotice() {
        return $"(c) {DateTime.Now.Year} Marc-Eric Boury - All rights reserved.";
    }

    public void Start() {
        Application.Run(this.mainMenu);
    }
    public void Shutdown() {
        Application.Exit();
    }
}
