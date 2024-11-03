using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain.Pivots;

/// <summary>
/// Classe représentant les associations entre <see cref="ShippingOrder"/> et <see cref="Product"/>."/>.
/// Utilisé pour représenter les produits d'un ordre d'expédition et leur quantité.
/// </summary>
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

    /// <summary>
    /// L'ordre d'expédition associé.
    /// </summary>
    public virtual ShippingOrder ShippingOrder { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;

    /// <summary>
    /// Constructeur orienté création manuelle
    /// </summary>
    /// <param name="shippingOrderId">L'identifiant de l'ordre d'expédition.</param>
    /// <param name="productId">L'identifiant du produit.</param>
    /// <param name="quantity">La quantité du produit associé à cet ordre d'expédition.</param>
    public ShippingOrderProduct(int shippingOrderId, int productId, int quantity = 0) {
        this.ShippingOderId = shippingOrderId;
        this.ProductId = productId;
        this.Quantity = quantity;
    }

    /// <summary>
    /// Constructeur orienté entity framework.
    /// </summary>
    /// <param name="shippingOrderId">L'identifiant de l'ordre d'expédition.</param>
    /// <param name="productId">L'identifiant du produit.</param>
    /// <param name="quantity">La quantité du produit associé à cet ordre d'expédition.</param>
    /// <param name="rowVersion">Le numéro de version anti-concurrence de l'entrée dans la base de donnée.</param>
    protected ShippingOrderProduct(int shippingOrderId, int productId, int quantity, byte[] rowVersion)
        : this(shippingOrderId, productId, quantity) {
        this.RowVersion = rowVersion;
    }

    /// <summary>
    /// Méthode de validation de la quantité du produit.
    /// La quantité doit être supérieure ou égale à 1.
    /// </summary>
    /// <param name="quantity">La quantité du produit.</param>
    /// <returns><see langword="true"/> si valide, <see langword="false"/> sinon.</returns>
    public static bool ValidateQuantity(int quantity) {
        return quantity >= 1;
    }


    /// <summary>
    /// Override de la méthode <see cref="object.ToString"/> pour affichage des associations
    /// produit-ordre d'expédition dans des ListBox ou ComboBox.
    /// </summary>
    /// <returns>Un string décrivant l'association produit-ordre d'expédition.</returns>
    public override string ToString() {
        return $"{this.Product.Name} (Qty: {this.Quantity})";
    }

}
