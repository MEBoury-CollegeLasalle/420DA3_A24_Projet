using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Product {
    public const int PRODUCT_NAME_MAX_LENGTH = 128;
    public const int PRODUCT_NAME_MIN_LENGTH = 1;
    public const int DESCRIPTION_MAX_LENGTH = 256;
    public const int DESCRIPTION_MIN_LENGTH = 10;
    public const double MAX_WEIGHT = 100.0; // Exemple de poids maximal
    public const double MIN_WEIGHT = 0.1;   // Exemple de poids minimal

    private int id;
    private string productName = null!;
    private string description = null!;
    private double weight;

    #region Proprietes de donnees
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    public int Id {
        get { return this.id; }
        set {
            if (value < 0) {
                throw new ArgumentOutOfRangeException(nameof(Id), "Id must be greater than or equal to 0.");
            }
            this.id = value;
        }
    }

    public string ProductName {
        get { return this.productName; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < PRODUCT_NAME_MIN_LENGTH || value.Length > PRODUCT_NAME_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(ProductName), $"ProductName length must be between {PRODUCT_NAME_MIN_LENGTH} and {PRODUCT_NAME_MAX_LENGTH} characters.");
            }
            this.productName = value;
        }
    }

    public string Description {
        get { return this.description; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < DESCRIPTION_MIN_LENGTH || value.Length > DESCRIPTION_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(Description), $"Description length must be between {DESCRIPTION_MIN_LENGTH} and {DESCRIPTION_MAX_LENGTH} characters.");
            }
            this.description = value;
        }
    }

    public double Weight {
        get { return this.weight; }
        set {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT) {
                throw new ArgumentOutOfRangeException(nameof(Weight), $"Weight must be between {MIN_WEIGHT} and {MAX_WEIGHT} kg.");
            }
            this.weight = value;
        }
    }

    public int QuantityInStock { get; set; }
    public int TargetQuantity { get; set; }
    public string? UpcCode { get; set; } // Optional Universal Product Code (nullable)

    #endregion

    #region Propriétés de navigation
    public virtual Customer Owner { get; set; } = null!; // Client propriétaire du produit
    public virtual Supplier Supplier { get; set; } = null!; // Fournisseur du produit  
    #endregion

    /// <summary>
    /// Constructeur pour création de produit
    /// </summary>
    public Product(string productName, string description, double weight, int quantityInStock, int targetQuantity, string? upcCode, Customer owner, Supplier supplier) {
        this.ProductName = productName;
        this.Description = description;
        this.Weight = weight;
        this.QuantityInStock = quantityInStock;
        this.TargetQuantity = targetQuantity;
        this.UpcCode = upcCode;
        this.Owner = owner;
        this.Supplier = supplier;
        this.DateCreated = DateTime.Now;
    }

    /// <summary>
    /// Constructeur pour Entity Framework
    /// </summary>
    protected Product(int id, string productName, string description, double weight, int quantityInStock, int targetQuantity, string? upcCode, Customer owner, Supplier supplier, DateTime dateCreated, DateTime? dateModified, DateTime? dateDeleted, byte[] rowVersion)
        : this(productName, description, weight, quantityInStock, targetQuantity, upcCode, owner, supplier) {
        this.Id = id;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
        this.DateDeleted = dateDeleted;
        this.RowVersion = rowVersion;
    }
}

