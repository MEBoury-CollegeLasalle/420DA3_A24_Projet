using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.DataAccess.DAOs;
internal class ShipmentDAO {


    private readonly WsysDbContext context;

    public ShipmentDAO(WsysDbContext context) {
        this.context = context;
    }

    /// <summary>
    /// Methode GetById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="inclutedDeleted"></param>
    /// <returns></returns>
     public Shipment? GetById(int id, bool inclutedDeleted = false) {

        return this.context.Shipments
            .Where(shipment => shipment.Id == id && (inclutedDeleted || shipment.DateDelete == null))
            .Include(shipment => shipment.ShippingOrder)
            .Include(shipment => shipment.Status)
            .Include(shipment => shipment.ShippingService)
            .SingleOrDefault();
     }

    /// <summary>
    /// Methode  pour retourner Le TrackingNumber
    /// </summary>
    /// <param name="trackingNumber"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public Shipment? GetByTrackingNumber(string trackingNumber, bool includeDeleted = false) {

        return this.context.Shipments
            .Where(shipment => shipment.TrackingNumber == trackingNumber && (includeDeleted || shipment.DateDelete == null))
            .Include(shipment => shipment.ShippingOrder)
            .Include(shipment => shipment.Status)
            .Include(shipment => shipment.ShippingService)
            .SingleOrDefault();
    }

    /// <summary>
    /// Methode Search
    /// </summary>
    /// <param name="criterion"></param>
    /// <param name="includeDeteded"></param>
    /// <returns></returns>
    public  List<Shipment> Search(string criterion, bool includeDeteded = false) {

        return this.context.Shipments
            .Where(shipment => (
               shipment.Id.ToString().Contains(criterion)
               || shipment.Status.ToString().Contains(criterion)
            ) && (includeDeteded || shipment.DateDelete == null))
            .Include(shipment => shipment.ShippingOrder)
            .Include(shipment => shipment.Status)
            .Include(shipment => shipment.ShippingService)
            .ToList();
    }


    /// <summary>
    /// Methode Create
    /// </summary>
    /// <param name="shipment"></param>
    /// <returns></returns>
    public Shipment Create(Shipment shipment) { 
    
        _= this.context.Shipments.Add(shipment);
        _ = this.context.SaveChanges();
        return shipment;
    }
  
}
