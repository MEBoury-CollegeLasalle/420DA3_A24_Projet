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
    public Fournisseur fournisseur { get; set; }
    public int qteStock { get; set; }
    public int qteStockVise { get; set; }
    public float poids { get; set; }

    //Meta données 
    public DateTime? dateModified { get; set; }
    public DateTime? dateDelete { get; set; }
    public DateTime? dateCreated { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    // Propriétés de navigation EF Core
    public virtual List<ShippingOrderProduct> OrgderProducts { get; set; }

    ///<summary>
    ///Constructeur orienté creation manuelle
    /// </summary>
    /// <param name="id">L'id du produit </param>
    /// <param name="nomproduit">Le nom du produit</param>
    /// <param name="descriptionproduit">La description du produit </param>
    /// <param name="codeUpcinternational">Le code Upc International </param>
    /// <param name="proprietaireproduit">L'id du client </param>
    /// <param name="fournisseur">L'id du fournisseur </param>
    /// <param name="qteStock">La quantité des produit en stock </param>
    /// <param name="qteStockVise">La quantite des produit en stock visé </param>
    /// <param name="poids">Le poids de produits </param>
    
    public Produit(int id, string Nomproduit, string Descriptionproduit, string CodeUPCInternational , Fournisseur Frournisseur, int QteStock, int QteStockVise,float Poids) 
        {
        this.Id = id;
        this.nomproduit = Nomproduit;
        this.descriptionproduit = Descriptionproduit;
        this.codeUpcinternational = CodeUPCInternational;
        this.fournisseur = Frournisseur;
        this.qteStock = QteStock;
        this.qteStockVise = QteStockVise;
        this.poids = Poids;

    }

    ///<summary>
    ///Constructeur orienté entity framework
    /// </summary>
    /// <param name="id">L'id du produit </param>
    /// <param name="nomproduit">Le nom du produit</param>
    /// <param name="descriptionproduit">La description du produit </param>
    /// <param name="codeUpcinternational">Le code Upc International </param>
    /// <param name="proprietaireproduit">L'id du client </param>
    /// <param name="fournisseur">L'id du fournisseur </param>
    /// <param name="qteStock">La quantité des produit en stock </param>
    /// <param name="qteStockVise">La quantite des produit en stock visé </param>
    /// <param name="poids">Le poids de produits </param>
    /// <param name="rowVersion">Valeur anti-concurrence de la base de données </param>
    /// 

    protected Produit(
        int id,
        string Nomproduit,
        string Descriptionproduit,
        string CodeUPCInternational,
        Client proprietaireproduit,
        Fournisseur fournisseur,
        int QteStock,
        int QteStockVise,
        float Poids,
        DateTime dateCreated,
        DateTime? datemodified,
        DateTime? dateDelete,
        byte [] rowVersion)
        : this(Nomproduit, Descriptionproduit, CodeUPCInternational, proprietaireproduit, fournisseur, QteStock, QteStockVise, Poids) {

        this.Id = id;
        this.dateCreated = dateCreated;
        this.dateModified = datemodified;
        this.dateDelete = dateDelete;
        this.RowVersion = rowVersion;
    
    }

    public Produit(string nomproduit, string descriptionproduit, string codeUPCInternational, Client proprietaireproduit, Fournisseur fournisseur, int qteStock, int qteStockVise, float poids) {
        this.nomproduit = nomproduit;
        this.descriptionproduit = descriptionproduit;
        this.codeUpcinternational = codeUPCInternational;
        this.proprietaireProduit = proprietaireproduit;
        this.fournisseur = fournisseur;
        this.qteStock = qteStock;
        this.qteStockVise = qteStockVise;
        this.poids = poids;
    }

    ///<summary>
    ///Override de la méthode ToString pour afficher les informations du produit.
    ///</summary>
    /// <returns>Un string représentant le produit.</returns>
    public override string ToString() {

        return $"#{this.Id} - {this.nomproduit} - {this.descriptionproduit} - {this.codeUpcinternational} - {this.proprietaireProduit} - {this.fournisseur} - {this.qteStock} - {this.qteStockVise} - {this.poids}";

    }
   
      
}
