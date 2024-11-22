using _420DA3_A24_Projet.Business.Domain.Enums;
using Project_Utilities.Enums;
using System;

namespace _420DA3_A24_Projet.Business.Domain;

/// <summary>
/// Classe représentant une adresse utilisée pour des livraisons ou des correspondances.
/// </summary>
public class Adresse {
    /// <summary>
    /// Identifiant unique de l'adresse.
    /// </summary>
    public int AdresseId { get; set; }

    /// <summary>
    /// Type de l'adresse 
    /// </summary>
    public AddressTypeEnum TypeAdresse { get; set; }

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
    /// Ville associée à l'adresse.
    /// </summary>
    public string Ville { get; set; } = string.Empty;

    /// <summary>
    /// Province ou région associée à l'adresse.
    /// </summary>
    public string Province { get; set; } = string.Empty;

    /// <summary>
    /// Pays de l'adresse.
    /// </summary>
    public string Pays { get; set; } = string.Empty;

    /// <summary>
    /// Code postal associé à l'adresse.
    /// </summary>
    public string CodePostal { get; set; } = string.Empty;

    /// <summary>
    /// Date de création de l'adresse.
    /// </summary>
    public DateTime DateCreation { get; set; } = DateTime.Now;

    /// <summary>
    /// Date de dernière modification de l'adresse.
    /// </summary>
    public DateTime? DateModification { get; set; }

    /// <summary>
    /// Date de suppression de l'adresse
    /// </summary>
    public DateTime? DateSuppression { get; set; }

    /// <summary>
    /// Met à jour les informations principales de l'adresse.
    /// </summary>
    /// <param name="rue">Nouvelle rue.</param>
    /// <param name="ville">Nouvelle ville.</param>
    /// <param name="province">Nouvelle province.</param>
    /// <param name="pays">Nouveau pays.</param>
    /// <param name="codePostal">Nouveau code postal.</param>
    public void MettreAJourAdresse(string rue, string ville, string province, string pays, string codePostal) {
        Rue = rue;
        Ville = ville;
        Province = province;
        Pays = pays;
        CodePostal = codePostal;
        DateModification = DateTime.Now;
    }

    /// <summary>
    /// Valide les propriétés obligatoires de l'adresse.
    /// </summary>
    public void ValiderAdresse() {
        if (string.IsNullOrWhiteSpace(Destinataire)) {
            throw new ArgumentException("Le destinataire est obligatoire.");
        }
        if (string.IsNullOrWhiteSpace(Rue) || string.IsNullOrWhiteSpace(Ville)) {
            throw new ArgumentException("La rue et la ville sont obligatoires.");
        }
        if (string.IsNullOrWhiteSpace(CodePostal)) {
            throw new ArgumentException("Le code postal est obligatoire.");
        }
    }
}
