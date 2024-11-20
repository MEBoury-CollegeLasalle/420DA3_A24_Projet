using Project_Utilities.Enums;

namespace _420DA3_A24_Projet.Business.Domain;

/// <summary>
/// Classe représentant une expédition dans l'application.
/// </summary>
public class Expedition {
    /// <summary>
    /// Identifiant unique de l'expédition.
    /// </summary>
    public int ExpeditionId { get; set; }

    /// <summary>
    /// Service de livraison utilisé pour l'expédition.
    /// </summary>
    public DeliveryServiceEnum ServiceLivraison { get; set; }

    /// <summary>
    /// Code de suivi associé à l'expédition.
    /// </summary>
    public string CodeSuivi { get; set; } = string.Empty;

    /// <summary>
    /// Identifiant de l'ordre d'expédition associé.
    /// </summary>
    public int OrdreExpeditionId { get; set; }

    /// <summary>
    /// Ordre d'expédition associé.
    /// </summary>
    public virtual ShippingOrder OrdreExpedition { get; set; } = null!;

    /// <summary>
    /// Date de création de l'expédition.
    /// </summary>
    public DateTime DateCreation { get; set; } = DateTime.Now;

    /// <summary>
    /// Date de dernière modification de l'expédition.
    /// </summary>
    public DateTime? DateModification { get; set; }

    /// <summary>
    /// Date de suppression de l'expédition (soft delete).
    /// </summary>
    public DateTime? DateSuppression { get; set; }

    /// <summary>
    /// Numéro de version pour la gestion des conflits dans la base de données.
    /// </summary>
    public byte[] RowVersion { get; set; } = null!;

    /// <summary>
    /// Constructeur orienté création manuelle.
    /// </summary>
    /// <param name="serviceLivraison">Service de livraison utilisé.</param>
    /// <param name="codeSuivi">Code de suivi de l'expédition.</param>
    /// <param name="ordreExpeditionId">Identifiant de l'ordre d'expédition associé.</param>
    public Expedition(DeliveryServiceEnum serviceLivraison, string codeSuivi, int ordreExpeditionId) {
        ServiceLivraison = serviceLivraison;
        CodeSuivi = codeSuivi;
        OrdreExpeditionId = ordreExpeditionId;
    }

    /// <summary>
    /// Retourne une représentation textuelle de l'expédition.
    /// </summary>
    /// <returns>Un string décrivant l'expédition.</returns>
    public override string ToString() {
        return $"{ServiceLivraison} - Code Suivi: {CodeSuivi} - Créé le: {DateCreation}";
    }
}
