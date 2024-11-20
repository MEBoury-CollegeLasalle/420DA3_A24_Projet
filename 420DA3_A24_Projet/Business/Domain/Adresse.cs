using Project_Utilities.Enums;
namespace _420DA3_A24_Projet.Business.Domain;

/// <summary>
/// Classe représentant une adresse dans l'application.
/// </summary>
public class Adresse {
    /// <summary>
    /// Identifiant unique de l'adresse.
    /// </summary>
    public int AdresseId { get; set; }

    /// <summary>
    /// Type de l'adresse 
    /// </summary>
    public AddressStatusEnum Status  { get; set; }

    /// <summary>
    /// Nom ou désignation du destinataire.
    /// </summary>
    public string Destinataire { get; set; } = string.Empty;

    /// <summary>
    /// Numéro civique de l'adresse.
    /// </summary>
    public string NumeroCivique { get; set; } = string.Empty;

    /// <summary>
    /// Rue associée à l'adresse.
    /// </summary>
    public string Rue { get; set; } = string.Empty;

    /// <summary>
    /// Ville où se situe l'adresse.
    /// </summary>
    public string Ville { get; set; } = string.Empty;

    /// <summary>
    /// Province ou région de l'adresse.
    /// </summary>
    public string Province { get; set; } = string.Empty;

    /// <summary>
    /// Pays associé à l'adresse.
    /// </summary>
    public string Pays { get; set; } = string.Empty;

    /// <summary>
    /// Code postal de l'adresse.
    /// </summary>
    public string CodePostal { get; set; } = string.Empty;

    /// <summary>
    /// Date de création de l'entrée d'adresse.
    /// </summary>
    public DateTime DateCreation { get; set; } = DateTime.Now;

    /// <summary>
    /// Date de dernière modification de l'adresse.
    /// </summary>
    public DateTime? DateModification { get; set; }

    /// <summary>
    /// Date de suppression de l'adresse (soft delete).
    /// </summary>
    public DateTime? DateSuppression { get; set; }

    /// <summary>
    /// Numéro de version pour la gestion des conflits dans la base de données.
    /// </summary>
    public byte[] RowVersion { get; set; } = null!;

    /// <summary>
    /// Liste des ordres d'expédition associés à l'adresse.
    /// </summary>
    public virtual List<ShippingOrder> ShippingOrders { get; set; } = new List<ShippingOrder>();

    /// <summary>
    /// Méthode pour mettre à jour les informations principales de l'adresse.
    /// </summary>
    /// <param name="rue">Rue.</param>
    /// <param name="ville">Ville.</param>
    /// <param name="province">Province ou région.</param>
    /// <param name="pays">Pays.</param>
    /// <param name="codePostal">Code postal.</param>
    public void MettreAJourAdresse(string rue, string ville, string province, string pays, string codePostal) {
        Rue = rue;
        Ville = ville;
        Province = province;
        Pays = pays;
        CodePostal = codePostal;
        DateModification = DateTime.Now;
    }

    /// <summary>
    /// Retourne une représentation textuelle de l'adresse.
    /// </summary>
    /// <returns>Un string décrivant l'adresse.</returns>
    public override string ToString() {
        return $"{NumeroCivique} {Rue}, {Ville}, {Province}, {Pays} - {CodePostal}";
    }
}
