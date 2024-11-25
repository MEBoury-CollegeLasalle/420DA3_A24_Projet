using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.DataAccess.DAOs;
using _420DA3_A24_Projet.Presentation.Views;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Services;
internal class AdresseServices {
    private readonly AdresseDAO dao;
    private readonly AdresseView view;

    public AdresseServices(ProjectApplication parentApp, WsysDbContext context) {
        this.dao = new AdresseDAO(context);
        this.view = new AdresseView(parentApp);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Adresse? GetById(int id, bool includeDeleted = false) {
        return this.dao.GetById(id, includeDeleted);
    }

 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="adresseType"></param>
    /// <param name="includeDelete"></param>
    /// <returns></returns>
    public Adresse? GetAdresseType(AddressTypesEnum adresseType, bool includeDelete = false) {
        return this.dao.GetByAdresseType(adresseType, includeDelete);
    }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="adresse"></param>
   /// <returns></returns>
    public Adresse UpdateAdresse(Adresse adresse) {
        return this.dao.Create(adresse);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adresse"></param>
    /// <param name="softDelete"></param>
    /// <returns></returns>
    public Adresse DeleteAdresse(Adresse adresse, bool softDeleted) {
        return this.dao.Delete(adresse,softDeleted);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="adresse"></param>
    /// <returns></returns>
    public Adresse CreateAdresse(Adresse adresse) {
        return this.dao.Create(adresse);
    }
    

}
