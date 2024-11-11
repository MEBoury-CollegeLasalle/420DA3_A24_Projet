using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.DataAccess.DAOs;
internal class PurchaseOrderDAO {
    private readonly WsysDbContext context;

    public PurchaseOrderDAO(WsysDbContext context) {
        this.context = context;
    }

    /// <summary>
    /// la methode GetAll
    /// </summary>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<PurchaseOrder> GetAll(bool includeDeleted = false) {
        return this.context.PurchaseOrders.Where(purchaseOrder => purchaseOrder.DateDeleted == null).ToList();
    }

    /// <summary>
    /// la methode GetById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public PurchaseOrder? GetById(int id, bool includeDeleted = false) {
        return this.context.PurchaseOrders
               .Where(purchaseOrder => purchaseOrder.Id == id && (includeDeleted || purchaseOrder.DateDeleted == null))
               .Include(purchaseOrder => purchaseOrder.ProductId)
               .Include(purchaseOrder => purchaseOrder.WarehouseId)
               .Include(purchaseOrder => purchaseOrder.OrderedProduct)
               .Include(purchaseOrder => purchaseOrder.Warehouse)
               .SingleOrDefault();
    }


    ///<summary>
    ///la methode Search
    /// </summary>
    /// <param name="criterion"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<PurchaseOrder> Search(string criterion, bool includeDeleted = false) {
        return this.context.PurchaseOrders
            .Where(purchaseOrder => (
                    purchaseOrder.Id.ToString().Contains(criterion)
                    || purchaseOrder.SupplierName.ToLower().Contains(criterion.ToLower())
                  ) && (includeDeleted || purchaseOrder.DateDeleted == null))
            .Include(purchaseOrder => purchaseOrder.Products)
            .ToList();
    }



    /// <summary>
    /// methode de cration d'ordre de restockage
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <retuens></retuens>

    public PurchaseOrder Create(PurchaseOrder purchaseOrder) {
        _ = this.context.PurchaseOrders.Add(purchaseOrder);
        _ = this.context.SaveChanges();
        return purchaseOrder;
    }

    /// <summary>
    /// methode de l'insertion d'ordre de restockage
    /// diff entre insert && create :
    /// Insert : pour inserer derectement l'entite (no checks)
    /// Create : pour cree des verifs ou des conditions avant d'ajouter l'entite
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <retuens></retuens>

    public PurchaseOrder Insert(PurchaseOrder purchaseOrder) {
        _ = this.context.PurchaseOrders.Add(purchaseOrder);
        _ = this.context.SaveChanges();
        return purchaseOrder;
    }

    /// <summary>
    /// methode de mise a jour d'ordre de restockage
    /// </summary>
    /// <param name="supplier"></param>
    /// <retuens></retuens>
    public PurchaseOrder Update(PurchaseOrder purchaseOrder) {
        purchaseOrder.DateModified = DateTime.Now;
        _ = this.context.PurchaseOrders.Update(purchaseOrder);
        _ = this.context.SaveChanges();
        return purchaseOrder;
    }

    /// <summary>
    /// methode de suppression d'ordre de restockage
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <param name="softDeletes"></param>
    /// <retuens></retuens>
    public PurchaseOrder Delete(PurchaseOrder purchaseOrder, bool softDeletes = true) {
        if (softDeletes) {
            purchaseOrder.DateDeleted = DateTime.Now;
            _ = this.context.PurchaseOrders.Update(purchaseOrder);
        } else {
            _ = this.context.PurchaseOrders.Remove(purchaseOrder);
        }
        _ = this.context.SaveChanges();
        return purchaseOrder;
    }





}
