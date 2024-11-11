using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Adresse {
    public int AdresseId { get; set; }
    public string TypeAdresse { get; set; }
    public string Destinataire { get; set; }
    public string NumeroCivique { get; set; }
    public string Rue { get; set; }
    public string Ville { get; set; }
    public string Province { get; set; }
    public string Pays { get; set; }
    public string CodePostal { get; set; }
    public DateTime DateCreation { get; set; } = DateTime.Now;
    public DateTime? DateModification { get; set; }
    public DateTime? DateSuppression { get; set; }

    public void MettreAJourAdresse(string rue, string ville, string province, string pays, string codePostal) {
        Rue = rue;
        Ville = ville;
        Province = province;
        Pays = pays;
        CodePostal = codePostal;
        DateModification = DateTime.Now;
    }
}
