using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.DataAccess.DAOs;
internal class SupplierDAO {
    private readonly WsysDbContext context;

    public SupplierDAO(WsysDbContext context) {
        this.context = context;
    }

    /// <summary>
    /// la methode GetAll
    /// </summary>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<Supplier> GetAll(bool includeDeleted = false) {
        return this.context.Suppliers.Where(supplier => supplier.DateDeleted == null).ToList();
    }

    /// <summary>
    /// la methode GetById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Supplier? GetById(int id, bool includeDeleted = false) {
        return this.context.Suppliers
               .Where(supplier => supplier.Id == id && (includeDeleted || supplier.DateDeleted == null))
               .Include(supplier => supplier.Products)
               .SingleOrDefault();
    }

    /// <summary>
    /// la methode GetBySupplierName
    /// </summary>
    /// <param name="username"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Supplier? GetBySupplierName(string supplierName, bool includeDeleted = false) {
        return this.context.Suppliers
            .Where(supplier => supplier.SupplierName == supplierName && (includeDeleted || supplier.DateDeleted == null))
            .Include(supplier => supplier.Products)
            .SingleOrDefault();
    }

    ///<summary>
    ///la methode Search
    /// </summary>
    /// <param name="criterion"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public List<Supplier> Search(string criterion , bool includeDeleted = false) {
        return this.context.Suppliers
            .Where(supplier => (
                    supplier.Id.ToString().Contains(criterion)
                    || supplier.SupplierName.ToLower().Contains(criterion.ToLower())
                  ) && (includeDeleted || supplier.DateDeleted == null))
            .Include(supplier => supplier.Products)
            .ToList();
    }



    /// <summary>
    /// methode de cration de fournisseur
    /// </summary>
    /// <param name="supplier"></param>
    /// <retuens></retuens>

    public Supplier Create(Supplier supplier) {
        _ = this.context.Suppliers.Add(supplier);
        _ = this.context.SaveChanges();
        return supplier;
    }

    /// <summary>
    /// methode de l'insertion de fournisseur 
    /// diff entre insert && create :
    /// Insert : pour inserer derectement l'entite (no checks)
    /// Create : pour cree des verifs ou des conditions avant d'ajouter l'entite
    /// </summary>
    /// <param name="supplier"></param>
    /// <retuens></retuens>

    public Supplier Insert(Supplier supplier) {
        _ = this.context.Suppliers.Add(supplier);
        _ = this.context.SaveChanges();
        return supplier;
    }

    /// <summary>
    /// methode de mise a jour de fournisseur
    /// </summary>
    /// <param name="supplier"></param>
    /// <retuens></retuens>
    public Supplier Update(Supplier supplier) {
        supplier.DateModified = DateTime.Now;
        _ = this.context.Suppliers.Update(supplier);
        _ = this.context.SaveChanges();
        return supplier;
    }

    /// <summary>
    /// methode de suppression de fournisseur
    /// </summary>
    /// <param name="supplier"></param>
    /// <param name="softDeletes"></param>
    /// <retuens></retuens>
    public Supplier Delete(Supplier supplier , bool softDeletes = true) {
        if (softDeletes) {
            supplier.DateDeleted = DateTime.Now;
            _ = this.context.Suppliers.Update(supplier);
        } else {
            _ = this.context.Suppliers.Remove(supplier);
        }
        _ = this.context.SaveChanges();
        return supplier;
    }

}

