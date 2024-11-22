using System;
using System.Collections.Generic;

namespace _420DA3_A24_Projet.Business.Domain;

public class Fournisseur {
    
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

   
    public string NomContact { get; set; } = string.Empty;

    
    public string PrenomContact { get; set; } = string.Empty;

    
    public string CourrielContact { get; set; } = string.Empty;

   
    public string TelephoneContact { get; set; } = string.Empty;

   
    public DateTime DateCreation { get; set; } = DateTime.Now;

   
    public DateTime? DateModification { get; set; }

    
    public DateTime? DateSuppression { get; set; }

    
    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();

    
    public Fournisseur() { }

    /// <param name="nom">Nom du fournisseur.</param>
    /// <param name="nomContact">Nom du contact principal.</param>
    /// <param name="prenomContact">Prénom du contact principal.</param>
    /// <param name="courrielContact">Courriel du contact principal.</param>
    /// <param name="telephoneContact">Numéro de téléphone du contact principal.</param>
    public Fournisseur(string nom, string nomContact, string prenomContact, string courrielContact, string telephoneContact) {
        Nom = nom;
        NomContact = nomContact;
        PrenomContact = prenomContact;
        CourrielContact = courrielContact;
        TelephoneContact = telephoneContact;
        DateCreation = DateTime.Now;
    }

   
    public override string ToString() {
        return $"{Nom} (Contact: {PrenomContact} {NomContact}, Email: {CourrielContact}, Téléphone: {TelephoneContact})";
    }
}
