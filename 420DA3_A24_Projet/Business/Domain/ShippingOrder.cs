using _420DA3_A24_Projet.Business.Domain.Pivots;
using Project_Utilities.Enums;
using System.Text;

namespace _420DA3_A24_Projet.Business.Domain;

/// <summary>
/// Classe représentant un ordre d'expédition.
/// </summary>
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


    /// <summary>
    /// Le client de qui provient l'ordre d'expédition.
    /// </summary>
    public virtual Client SourceClient { get; set; } = null!;
    /// <summary>
    /// L'employé créateur de l'ordre d'expédition.
    /// </summary>
    public virtual User CreatorEmployee { get; set; } = null!;
    /// <summary>
    /// L'adresse de destination finale de l'ordre d'expédition.
    /// </summary>
    public virtual Address DestinationAddress { get; set; } = null!;
    /// <summary>
    /// L'employé d'entrepôt assigné à la complétion de l'ordre d'expédition.
    /// </summary>
    public virtual User? FulfillerEmployee { get; set; }
    /// <summary>
    /// L'expédition associée à l'ordre d'expédition.
    /// </summary>
    public virtual Shipment? Shipment { get; set; }
    /// <summary>
    /// La liste des produits associés à l'ordre d'expédition.
    /// </summary>
    public virtual List<ShippingOrderProduct> ShippingOrderProducts { get; set; } = new List<ShippingOrderProduct>();


    /// <summary>
    /// Constructeur orienté création manuelle.
    /// Note: statut par défaut: "New".
    /// </summary>
    /// <param name="sourceClientId">L'identifiant du client source de l'ordre d'expédition.</param>
    /// <param name="creatorEmployeeId">L'identifiant de l'employé créateur de l'ordre d'expédition.</param>
    /// <param name="destinationAddressId">L'identifiant de l'adresse de destination finale de l'ordre d'expédition.</param>
    public ShippingOrder(int sourceClientId, int creatorEmployeeId, int destinationAddressId) {
        this.SourceClientId = sourceClientId;
        this.CreatorEmployeeId = creatorEmployeeId;
        this.DestinationAddressId = destinationAddressId;
        this.Status = ShippingOrderStatusEnum.New;
    }


    /// <summary>
    /// Constructeur orienté entity framework.
    /// </summary>
    /// <param name="id">L'identifiant de l'ordre d'expédition.</param>
    /// <param name="status">Le statut de l'ordre d'expédition.</param>
    /// <param name="sourceClientId">L'identifiant du client source de l'ordre d'expédition.</param>
    /// <param name="creatorEmployeeId">L'identifiant de l'employé créateur de l'ordre d'expédition.</param>
    /// <param name="destinationAddressId">L'identifiant de l'adresse de destination finale de l'ordre d'expédition.</param>
    /// <param name="fulfillerEmployeeId">L'identifiant de l'employé compléteur de l'ordre d'expédition.</param>
    /// <param name="dateCreated">La date de création de l'ordre d'expédition.</param>
    /// <param name="dateModified">La date de dernière modification de l'ordre d'expédition.</param>
    /// <param name="dateDeleted">La date de suppression de l'ordre d'expédition.</param>
    /// <param name="rowVersion">Le numéro de version anti-concurrence de l'entrée dans la base de donnée.</param>
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

    /// <summary>
    /// Assigne l'enployé d'entrepôt reçu à l'ordre d'expédition et change le statut de celle-ci à "Processing".
    /// </summary>
    /// <param name="warehouseEmployee">L'employé d'entrepôt à assigner.</param>
    /// <exception cref="InvalidOperationException">Si le statut de l'ordre d'expédition n'est pas "Unassigned".</exception>
    /// <exception cref="ArgumentException">Si l'utilisateur reçu n'est pas un employé d'entrepôt.</exception>
    public void AssignToWarehouseEmployee(User warehouseEmployee) {
        if (this.Status != ShippingOrderStatusEnum.Unassigned) {
            throw new InvalidOperationException("Shipping order must be in Unassigned status to be assigned to a warehouse employee.");
        }
        if (!warehouseEmployee.IsWarehouseEmployee()) {
            throw new ArgumentException("User must be a warehouse employee to be assigned to a shipping order.", nameof(warehouseEmployee));
        }
        this.FulfillerEmployee = warehouseEmployee;
        this.Status = ShippingOrderStatusEnum.Processing;
    }

    /// <summary>
    /// Marque l'ordre d'expédition comme "Packaged" et assigne l'expédition reçue à l'ordre d'expédition.
    /// </summary>
    /// <param name="shipment">L'expédition à assigner.</param>
    /// <exception cref="InvalidOperationException">Si le statut de l'ordre d'expédition n'est pas "Processing".</exception>
    /// <exception cref="ArgumentException">Si le statut de l'expédition reçue n'est pas "New".</exception>
    public void MarkAsPackaged(Shipment shipment) {
        if (this.Status != ShippingOrderStatusEnum.Processing) {
            throw new InvalidOperationException("Shipping order must be in Processing status to be marked as Packaged.");
        }
        if (shipment.Status != ShipmentStatusEnum.New) {
            throw new ArgumentException("Shipment must be in New status to be assigned to a shipping order.");
        }
        this.Shipment = shipment;
        this.Status = ShippingOrderStatusEnum.Packaged;
    }

    /// <summary>
    /// Marque l'ordre d'expédition comme "Shipped", assigne la date actuelle à la date d'expédition et
    /// marque l'expédition de l'ordre d'expédition comme "PickedUp".
    /// </summary>
    /// <exception cref="InvalidOperationException">Si le statut de l'ordre d'expédition n'est pas "Packaged", 
    /// si l'ordre d'expédition n'a pas d'expédition assignée 
    /// ou si le statut de l'expédition assignée n'est pas "New".
    /// </exception>
    public void MarkAsShipped() {
        if (this.Status != ShippingOrderStatusEnum.Packaged) {
            throw new InvalidOperationException("Shipping order must be in Packaged status to be marked as Shipped.");
        }
        if (this.Shipment == null) {
            throw new InvalidOperationException("Shipping order must have a shipment to be marked as Shipped.");
        }
        if (this.Shipment.Status != ShipmentStatusEnum.New) {
            throw new InvalidOperationException("Shipping order shipment must be in New status for the shipping order to be marked as Shipped.");
        }
        this.ShippingDate = DateTime.Now;
        this.Status = ShippingOrderStatusEnum.Shipped;
        this.Shipment.Status = ShipmentStatusEnum.PickedUp;
    }

    /// <summary>
    /// Override de la méthode <see cref="object.ToString"/> pour affichage des ordres d'expédition
    /// dans des ListBox ou ComboBox.
    /// </summary>
    /// <returns>Un string décrivant l'ordre d'expédition.</returns>
    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        switch (this.Status) {
            case ShippingOrderStatusEnum.Processing:
                _ = sb.Append($"#{this.Id} ({this.Status} by {this.FulfillerEmployee?.Username}) - Client: #{this.SourceClient.Id} {this.SourceClient.ClientName}");
                break;
            case ShippingOrderStatusEnum.Packaged:
            case ShippingOrderStatusEnum.Shipped:
                _ = sb.Append($"#{this.Id} ({this.Status} - Shipment: {this.Shipment?.TrackingNumber}) - Client: #{this.SourceClient.Id} {this.SourceClient.ClientName}");
                break;
            case ShippingOrderStatusEnum.New:
            case ShippingOrderStatusEnum.Unassigned:
            default:
                _ = sb.Append($"#{this.Id} ({this.Status}) - Client: #{this.SourceClient.Id} {this.SourceClient.ClientName}");
                break;

        }
        return sb.ToString();
    }
}
