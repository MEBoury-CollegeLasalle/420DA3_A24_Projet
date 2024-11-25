using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Services;
internal class ShipmentServices {
    private readonly ShipmentDAO dao;

    public ShipmentServices(ProjectApplication parentApp, WsysDbContext context) { 
        this.dao = new ShipmentDAO(context);
        //this.view = new ShipmentView(parentApp);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="inclutedDeleted"></param>
    /// <returns></returns>
     public Shipment? GetById(int id, bool inclutedDeleted = false) {
        return dao.GetById(id, inclutedDeleted);
     }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="trackingNumber"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Shipment? GetByTrackinkNumberShipment(string trackingNumber, bool includeDeleted = false) {
        return dao.GetByTrackingNumber(trackingNumber, includeDeleted);
    }

    public Shipment? 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="shipment"></param>
    /// <returns></returns>
 
    public Shipment CreateShipment(Shipment shipment) { 
        return dao.Create(shipment);
    }
  



}
