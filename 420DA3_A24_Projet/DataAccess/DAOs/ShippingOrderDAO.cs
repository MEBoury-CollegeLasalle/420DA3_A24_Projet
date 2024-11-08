using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Project_Utilities.Enums;

namespace _420DA3_A24_Projet.DataAccess.DAOs;

/// <summary>
/// TODO @PROF: documenter
/// </summary>
internal class ShippingOrderDAO {

    private readonly WsysDbContext context;

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="context"></param>
    public ShippingOrderDAO(WsysDbContext context) {
        this.context = context;
    }


    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="warehouse"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<ShippingOrder> GetUnassignedByWarehouse(Warehouse warehouse, bool includeDeleted = false) {
        return this.context.ShippingOrders
            .Include(so => so.SourceClient)
                .ThenInclude(client => client.AssignedWarehouse)
            .Include(so => so.CreatorEmployee)
            .Include(so => so.DestinationAddress)
            .Include(so => so.ShippingOrderProducts)
                .ThenInclude(sop => sop.Product)
            .Where(so => so.Status == ShippingOrderStatusEnum.Unassigned
                && so.SourceClient.AssignedWarehouse.Id == warehouse.Id
                && (includeDeleted || so.DateDeleted == null)
            )
            .ToList();
    }


    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="employee"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<ShippingOrder> GetProcessingByEmployee(User employee, bool includeDeleted = false) {
        return this.context.ShippingOrders
            .Include(so => so.SourceClient)
                .ThenInclude(client => client.AssignedWarehouse)
            .Include(so => so.CreatorEmployee)
            .Include(so => so.DestinationAddress)
            .Include(so => so.FulfillerEmployee)
            .Include(so => so.ShippingOrderProducts)
                .ThenInclude(sop => sop.Product)
            .Where(so => so.Status == ShippingOrderStatusEnum.Processing
                && so.FulfillerEmployee.Id == employee.Id
                && (includeDeleted || so.DateDeleted == null)
            )
            .ToList();
    }

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="warehouse"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<ShippingOrder> GetPackagedByWarehouse(Warehouse warehouse, bool includeDeleted = false) {
        return this.context.ShippingOrders
            .Include(so => so.SourceClient)
                .ThenInclude(client => client.AssignedWarehouse)
            .Include(so => so.CreatorEmployee)
            .Include(so => so.DestinationAddress)
            .Include(so => so.Shipment)
            .Include(so => so.ShippingOrderProducts)
                .ThenInclude(sop => sop.Product)
            .Where(so => so.Status == ShippingOrderStatusEnum.Packaged
                && so.SourceClient.AssignedWarehouse.Id == warehouse.Id
                && (includeDeleted || so.DateDeleted == null)
            )
            .ToList();
    }

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public ShippingOrder? GetById(int id, bool includeDeleted = false) {
        return this.context.ShippingOrders
            .Include(so => so.SourceClient)
                .ThenInclude(client => client.AssignedWarehouse)
            .Include(so => so.CreatorEmployee)
            .Include(so => so.DestinationAddress)
            .Include(so => so.Shipment)
            .Include(so => so.FulfillerEmployee)
            .Include(so => so.ShippingOrderProducts)
                .ThenInclude(sop => sop.Product)
            .Where(so => so.Id == id
                && (includeDeleted || so.DateDeleted == null)
            )
            .SingleOrDefault();
    }

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="criterion"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<ShippingOrder> Search(string criterion, bool includeDeleted = false) {
        return this.context.ShippingOrders
            .Include(so => so.SourceClient)
                .ThenInclude(client => client.AssignedWarehouse)
            .Include(so => so.CreatorEmployee)
            .Include(so => so.DestinationAddress)
            .Include(so => so.Shipment)
            .Include(so => so.ShippingOrderProducts)
                .ThenInclude(sop => sop.Product)
            .Where(so =>
                    so.Id.ToString().Contains(criterion)
                    || so.Status.ToString().ToLower().Contains(criterion.ToLower())
                    || so.SourceClient.Name.ToLower().Contains(criterion.ToLower())
                    || so.DestinationAddress.Addressee.ToLower().Contains(criterion.ToLower())
                    || so.ShippingOrderProducts.Any(sop => sop.Product.Id.ToString().Contains(criterion))
                    || so.ShippingOrderProducts.Any(sop => sop.Product.Name.ToLower().Contains(criterion.ToLower()))
                    || ((so.Shipment == null || so.Shipment.TrackingNumber.ToLower().Contains(criterion.ToLower()))
                && (includeDeleted || so.DateDeleted == null))
            )
            .ToList();
    }

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="shippingOrder"></param>
    /// <returns></returns>
    public ShippingOrder Create(ShippingOrder shippingOrder) {
        _ = this.context.ShippingOrders.Add(shippingOrder);
        _ = this.context.SaveChanges();
        return shippingOrder;
    }

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="shippingOrder"></param>
    /// <returns></returns>
    public ShippingOrder Update(ShippingOrder shippingOrder) {
        shippingOrder.DateModified = DateTime.Now;
        _ = this.context.ShippingOrders.Update(shippingOrder);
        _ = this.context.SaveChanges();
        return shippingOrder;
    }

    /// <summary>
    /// TODO @PROF: documenter
    /// </summary>
    /// <param name="shippingOrder"></param>
    /// <param name="softDeletes"></param>
    /// <returns></returns>
    public ShippingOrder Delete(ShippingOrder shippingOrder, bool softDeletes = true) {
        if (softDeletes) {
            shippingOrder.DateDeleted = DateTime.Now;
            _ = this.context.ShippingOrders.Update(shippingOrder);
        } else {
            _ = this.context.ShippingOrders.Remove(shippingOrder);
        }
        _ = this.context.SaveChanges();
        return shippingOrder;
    }

}
