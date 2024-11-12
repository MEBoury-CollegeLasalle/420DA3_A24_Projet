using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Client {
    public int Id { get; set; }
    public string NomCompagnie { get; set; }
    public string NomContact { get; set; }
    public string PrenomContact { get; set; }
    public string CourrielContact { get; set; }
    public string TelephoneContact { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateModification { get; set; }
    public DateTime? DateSuppression { get; set; }
    public int EntrepotId { get; set; }

    public virtual Entrepot Entrepot { get; set; } = null!;
    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();

   
    public Client() { }

   
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