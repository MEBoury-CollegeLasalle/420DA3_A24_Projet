using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain.Pivots;
public class ShippingOrderProduct {

    private int quantity;


    public int ShippingOderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { 
        get { return this.quantity; } 
        set { if (!ValidateQuantity(value)) { 
                throw new ArgumentOutOfRangeException("Quantity", "Quantity must be greater than or equal to 1.");
            }
            this.quantity = value;
        } 
    }
    public byte[] RowVersion { get; set; } = null!;


    public virtual ShippingOrder ShippingOrder { get; set; } = null!;
    //public virtual Product Product { get; set; } = null!;

    public ShippingOrderProduct(int shippingOrderId, int productId, int quantity = 0) {
        this.ShippingOderId = shippingOrderId;
        this.ProductId = productId;
        this.Quantity = quantity;
    }

    protected ShippingOrderProduct(int shippingOrderId, int productId, int quantity, byte[] rowVersion)
        : this(shippingOrderId, productId, quantity) {
        this.RowVersion = rowVersion;
    }

    public static bool ValidateQuantity(int quantity) {
        return quantity >= 1;
    }

}
