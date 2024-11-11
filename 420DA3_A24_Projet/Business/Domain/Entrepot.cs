using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
internal class Entrepot {
    public int Id { get; set; }
    public string nomEntrepot { get; set; }
    public string adresse { get; set; }
    public DateTime? dateCreated { get; set; }
    public DateTime? dateModified { get; set; }
    public DateTime? dateDeleted { get; set; }

}
