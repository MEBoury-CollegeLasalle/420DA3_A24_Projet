using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
internal class ShippingOrderProduct {
    private int quantite;
    public int Quantity {
        get {
            return quantite;
        } set {
            if (quantite <= 0) {
                throw new ArgumentOutOfRangeException("Quantity", "Quantity must  be greater than 0");
            }
            quantite = value;
        }
    }
    public int ShippingOrderId { get; set; }
    public int ProductId { get; set; }

    public virtual Product Product { get; set; }
    public virtual ShippingOrder ShippingOrder { get; set; }


    public ShippingOrderProduct(int ShippingOrderId,int ProductId,int Quantity){
        this.ShippingOrderId = ShippingOrderId;
        this.ProductId = ProductId;
        this.Quantity = Quantity;
    }
    
}
