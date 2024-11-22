using _420DA3_A24_Projet.Business.Domain.Enums;
using System;

namespace _420DA3_A24_Projet.Business.Domain;

/// <summary>
/// Classe représentant une expédition liée à un ordre d'expédition.
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
    /// Code de suivi unique de l'expédition.
    /// </summary>
    public string CodeSuivi { get; set; } = string.Empty;

    /// <summary>
    /// Identifiant de l'ordre d'expédition associé.
    /// </summary>
    public int OrdreExpeditionId { get; set; }

    /// <summary>
    /// Ordre d'expédition associé à cette expédition.
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
    /// Date de suppression de l'expédition 
    /// </summary>
    public DateTime? DateSuppression { get; set; }

   
    public Expedition() { }

    /// <summary>
    /// Constructeur orienté création d'expédition.
    /// </summary>
    /// <param name="serviceLivraison">Service de livraison.</param>
    /// <param name="codeSuivi">Code de suivi.</param>
    /// <param name="ordreExpeditionId">Identifiant de l'ordre d'expédition associé.</param>
    public Expedition(DeliveryServiceEnum serviceLivraison, string codeSuivi, int ordreExpeditionId) {
        ServiceLivraison = serviceLivraison;
        CodeSuivi = codeSuivi;
        OrdreExpeditionId = ordreExpeditionId;
    }

    /// <summary>
    /// Valide les propriétés obligatoires de l'expédition.
    /// </summary>
    public void ValiderExpedition() {
        if (string.IsNullOrWhiteSpace(CodeSuivi) || CodeSuivi.Length < 6) {
            throw new ArgumentException("Le code de suivi doit contenir au moins 6 caractères.");
        }
    }
}
