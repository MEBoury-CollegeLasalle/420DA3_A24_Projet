using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class PurchaseOrder {
    public int Id { get; set; }
    public PurchaseOrderStatusEnum Status { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
    public DateTime? CompletionDate { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public byte[] RowVersion { get; set; } = null!;


    //public virtual Product Product { get; set; } = null!;
    //public virtual Warehouse Warehouse { get; set; } = null!;


    public PurchaseOrder(int productId, int warehouseId, int quantity) { 
        this.Status = PurchaseOrderStatusEnum.New;
        this.ProductId = productId;
        this.WarehouseId = warehouseId;
        this.Quantity = quantity;
    }

    protected PurchaseOrder(int id,
        PurchaseOrderStatusEnum status,
        int productId,
        int warehouseId,
        int quantity,
        DateTime? completionDate,
        DateTime dateCreated,
        DateTime? dateModified,
        DateTime? dateDeleted,
        byte[] rowVersion)
        : this(productId, warehouseId, quantity) {

        this.Id = id;
        this.Status = status;
        this.CompletionDate = completionDate;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
        this.DateDeleted = dateDeleted;
        this.RowVersion = rowVersion;
    }


    public void Complete() {
        this.Status = PurchaseOrderStatusEnum.Completed;
        this.CompletionDate = DateTime.Now;
    }

}
