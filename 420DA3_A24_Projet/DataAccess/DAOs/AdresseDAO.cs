using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.DataAccess.DAOs;
internal class AdresseDAO {


    private readonly WsysDbContext context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public AdresseDAO(WsysDbContext context) {

        this.context = context;
    }


    /// <summary>
    /// Methode GetById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Adresse? GetById(int id, bool includeDeleted = false) {

        return this.context.Adresses
            .Where(adresse => adresse.Id == id && (includeDeleted || adresse.DateDelete == null))
            .Include(adresse => adresse.OwnerShipOrder)
            .Include(adresse => adresse.OwnerWarehouse)
            .SingleOrDefault();
    }

    /// <summary>
    /// Methode  GetByAdresseType
    /// </summary>
    /// <param name="adresseType"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Adresse? GetByAdresseType(AddressTypesEnum adresseType, bool includeDeleted = false) {
        return this.context.Adresses
            .Where(adresse => adresse.AdressTypes == adresseType && (includeDeleted || adresse.DateDelete == null))
            .Include(adresse => adresse.OwnerShipOrder)
            .Include(adresse => adresse.OwnerWarehouse)
            .SingleOrDefault();
    }

    /// <summary>
    /// Methode Create
    /// </summary>
    /// <param name="adresse"></param>
    /// <returns></returns>
    public Adresse Create(Adresse adresse) {
        _ = this.context.Adresses.Add(adresse);
        _ = this.context.SaveChanges();
        return adresse;
    }


    /// <summary>
    /// Methode Update
    /// </summary>
    /// <param name="adresse"></param>
    /// <returns></returns>

    public Adresse Update(Adresse adresse) {
        adresse.DateModified = DateTime.Now;
        _ = this.context.Adresses.Update(adresse);
        _ = this.context.SaveChanges();
        return adresse;
    }


    /// <summary>
    /// Methode Delete
    /// </summary>
    /// <param name="adresse"></param>
    /// <param name="softDeletes"></param>
    /// <returns></returns>
    public Adresse Delete(Adresse adresse, bool softDeletes = true) {

        if (softDeletes) {
            adresse.DateDelete = DateTime.Now;
            _ = this.context.Adresses.Update(adresse);
        } else {
            _ = this.context.Adresses.Remove(adresse);
        }
        _ = this.context.SaveChanges();
        return adresse;
    }


    /// <summary>
    /// Methode de recherche pour l'adresse
    /// </summary>
    /// <param name="criterion"></param>
    /// <param name="includeDeteded"></param>
    /// <returns></returns>
    public List<Adresse> Search(string criterion, bool includeDeteded = false) {

        return this.context.Adresses
            .Where(adresse => (
               adresse.Id.ToString().Contains(criterion)
               || adresse.AdressTypes.ToString().Contains(criterion)
            ) && (includeDeteded || adresse.DateDelete == null))
            .Include(shipment => shipment.OwnerShipOrder)
            .Include(shipment => shipment.OwnerWarehouse)
            .ToList();
    }


    /// <summary>
    /// le get by Warehouse
    /// </summary>
    /// <param name="OwnerWarehouse"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Adresse? GetByWarehouse(Warehouse OwnerWarehouse, bool includeDeleted = false) {
        return this.context.Adresses
            .Where(ownerWarehouse => ownerWarehouse.OwnerWarehouse == OwnerWarehouse && (includeDeleted || ownerWarehouse.DateDelete == null))
            .SingleOrDefault();
    }


    /// <summary>
    /// le get by ShipOrder
    /// </summary>
    /// <param name="OwnerShipOrder"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Adresse? GetByShipOrder(ShippingOrder OwnerShipOrder, bool includeDeleted = false) {
       return this.context.Adresses
            .Where(ownerShipOrder => ownerShipOrder.OwnerShipOrder == OwnerShipOrder && (includeDeleted || ownerShipOrder.DateDelete == null))
            .SingleOrDefault();
    }
}
