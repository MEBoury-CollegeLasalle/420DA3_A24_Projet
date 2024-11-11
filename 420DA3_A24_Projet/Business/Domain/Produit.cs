using _420DA3_A24_Projet.Business.Domain.Pivots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Produit {

    public int Id { get; set; }
    public string nomProduit { get; set; }
    public string descriptionProduit { get; set; }
    public string CodeUpcInternational { get; set; }
    public Client proprietaireProduit { get; set; }
    public fournisseur fournisseur { get; set; }
    public int QteStock { get; set; }
    public int QteStockVise { get; set; }
    public float poids { get; set; }
    public DateTime? dateModified { get; set; }
    public DateTime? dateDelete { get; set; }
    public DateTime? dateCReated { get; set; }
    public virtual List<ShippingOrderProduct> OrgderProducts { get; set; }

        
}
