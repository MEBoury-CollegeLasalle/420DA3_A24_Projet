using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Fournisseur {
    public int Id { get; set; }
    public string Nom { get; set; }
    public string NomContact { get; set; }
    public string PrenomContact { get; set; }
    public string CourrielContact { get; set; }
    public string TelephoneContact { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateModification { get; set; }
    public DateTime? DateSuppression { get; set; }

    
    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();

    
    public Fournisseur() { }

    
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