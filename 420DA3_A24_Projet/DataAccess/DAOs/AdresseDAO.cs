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
        _= this.context.Adresses.Add(adresse);
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
        _= this.context.Adresses.Update(adresse);
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


}
