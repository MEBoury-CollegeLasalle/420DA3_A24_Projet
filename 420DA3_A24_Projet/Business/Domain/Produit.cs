using _420DA3_A24_Projet.Business.Domain.Pivots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Produit {
    //Identifiant
    public int Id { get; set; }

    //Données du Produit
    public string nomproduit { get; set; }
    public string descriptionproduit { get; set; }
    public string codeUpcinternational { get; set; }
    public Client proprietaireProduit { get; set; }
    public fournisseur fournisseur { get; set; }
    public int QteStock { get; set; }
    public int QteStockVise { get; set; }
    public float poids { get; set; }

    //Meta données 
    public DateTime? dateModified { get; set; }
    public DateTime? dateDelete { get; set; }
    public DateTime? dateCReated { get; set; }
    public virtual List<ShippingOrderProduct> OrgderProducts { get; set; }


    //Proprietés de navigation EF Core


    ///<summary>
    ///L'utilisateur est associé a cet entrepot
    ///</summary>
    public virtual User User { get; set; } = null!;

    ///<summary>
    ///Le produit est associé a cet entrepot
    /// </summary>
    
    public virtual 




        
}
