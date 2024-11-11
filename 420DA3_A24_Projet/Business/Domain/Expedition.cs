using _420DA3_A24_Projet.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Expedition {
    public int ExpeditionId { get; set; }
    public string ServiceLivraison { get; set; }
    public string CodeSuivi { get; set; }
    public int OrdreExpeditionId { get; set; }
    public virtual ShippingOrder OrdreExpedition { get; set; } = null!;
    public DateTime DateCreation { get; set; } = DateTime.Now;
    public DateTime? DateModification { get; set; }
    public DateTime? DateSuppression { get; set; }

    
}
