using System;
using System.Collections.Generic;

namespace _420DA3_A24_Projet.Business.Domain;


public class Client {
   
    public int Id { get; set; }

  
    public string NomCompagnie { get; set; } = string.Empty;

   
    public string NomContact { get; set; } = string.Empty;

    
    public string PrenomContact { get; set; } = string.Empty;

    
    public string CourrielContact { get; set; } = string.Empty;

    public string TelephoneContact { get; set; } = string.Empty;

   
    public DateTime DateCreation { get; set; } = DateTime.Now;

    
    public DateTime? DateModification { get; set; }

    
    public DateTime? DateSuppression { get; set; }

    public int EntrepotId { get; set; }

    
    public virtual Entrepot Entrepot { get; set; } = null!;

   
    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();

    
    public Client() { }

   
    /// <param name="nomCompagnie">Nom de la compagnie cliente.</param>
    /// <param name="nomContact">Nom du contact principal.</param>
    /// <param name="prenomContact">Prénom du contact principal.</param>
    /// <param name="courrielContact">Email du contact principal.</param>
    /// <param name="telephoneContact">Téléphone du contact principal.</param>
    /// <param name="entrepotId">Identifiant de l'entrepôt associé.</param>
    public Client(string nomCompagnie, string nomContact, string prenomContact, string courrielContact, string telephoneContact, int entrepotId) {
        NomCompagnie = nomCompagnie;
        NomContact = nomContact;
        PrenomContact = prenomContact;
        CourrielContact = courrielContact;
        TelephoneContact = telephoneContact;
        EntrepotId = entrepotId;
        DateCreation = DateTime.Now;
    }

   
    public override string ToString() {
        return $"{NomCompagnie} (Contact: {PrenomContact} {NomContact}, Email: {CourrielContact}, Téléphone: {TelephoneContact})";
    }
}
