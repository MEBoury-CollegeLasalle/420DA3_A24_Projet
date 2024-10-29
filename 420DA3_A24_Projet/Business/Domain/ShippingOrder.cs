using _420DA3_A24_Projet.Business.Domain.Pivots;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class ShippingOrder {

    public int Id { get; set; }
    public ShippingOrderStatusEnum Status { get; set; }
    public int SourceClientId { get; set; }
    public int CreatorEmployeeId { get; set; }
    public int DestinationAddressId { get; set; }
    public int? FulfillerEmployeeId { get; set; }
    public DateTime? ShippingDate { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public byte[] RowVersion { get; set; } = null!;


    // public virtual Client SourceClient { get; set; } = null!;
    public virtual User CreatorEmployee { get; set; } = null!;
    //public virtual Address DestinationAddress { get; set; } = null!;
    public virtual User? FulfillerEmployee { get; set; }
    //public virtual Shipment? Shipment { get; set; }
    public virtual List<ShippingOrderProduct> Products { get; set; } = new List<ShippingOrderProduct>();

    public ShippingOrder(int sourceClientId, int creatorEmployeeId, int destinationAddressId) {
        this.SourceClientId = sourceClientId;
        this.CreatorEmployeeId = creatorEmployeeId;
        this.DestinationAddressId = destinationAddressId;
        this.Status = ShippingOrderStatusEnum.New;
    }

    protected ShippingOrder(int id, 
        ShippingOrderStatusEnum status, 
        int sourceClientId, 
        int creatorEmployeeId, 
        int destinationAddressId, 
        int? fulfillerEmployeeId,
        DateTime dateCreated,
        DateTime? dateModified,
        DateTime? dateDeleted,
        byte[] rowVersion)
        : this(sourceClientId, creatorEmployeeId, destinationAddressId) {

        this.Id = id;
        this.Status = status;
        this.FulfillerEmployeeId = fulfillerEmployeeId;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
        this.DateDeleted = dateDeleted;
        this.RowVersion = rowVersion;
    }


    public void AssignToWarehouseEmployee(User warehouseEmployee) {
        if (this.Status != ShippingOrderStatusEnum.Unassigned) {
            throw new InvalidOperationException("Shipping order must be in Unassigned status to be assigned to a warehouse employee.");
        }
        this.FulfillerEmployee = warehouseEmployee;
        this.Status = ShippingOrderStatusEnum.Processing;
    }

    public void MarkAsPackaged(Shipment shipment) {
        if (this.Status != ShippingOrderStatusEnum.Processing) {
            throw new InvalidOperationException("Shipping order must be in Processing status to be marked as Packaged.");
        }
        this.Shipment = shipment;
        this.Status = ShippingOrderStatusEnum.PAckaged;
    }

    public void MarkAsShipped() {
        if (this.Status != ShippingOrderStatusEnum.PAckaged) {
            throw new InvalidOperationException("Shipping order must be in Packaged status to be marked as Shipped.");
        }
        this.ShippingDate = DateTime.Now;
        this.Status = ShippingOrderStatusEnum.Shipped;
    }
}
