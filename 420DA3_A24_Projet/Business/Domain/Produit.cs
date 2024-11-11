using _420DA3_A24_Projet.Business.Domain.Pivots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Produit {

    public int Id { get; set; }
    public String nom_produit { get; set; }
    private String description_produit;
    private String Code_UPC_International;
    private Client proprietaireProduit;
    private fournisseur fournisseur;
    private int QtéStock;
    private int QtéStockVisé;
    private float poids;
    private DateTime dateModified;
    private DateTime dateDelete;
    private DateTime dateCReated;
    public virtual List<ShippingOrderProduct> OrgderProducts { get; set; }

        //Constructeur

        public produit() { }
}
