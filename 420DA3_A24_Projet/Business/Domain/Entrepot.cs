using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
internal class Entrepot {

    //Identifiant
    public int id { get; set; }

    //Données entrepot
    public string nomEntrepot { get; set; }
    public string adresse { get; set; }

    //Meta données
    public DateTime? dateCreated { get; set; }
    public DateTime? dateModified { get; set; }
    public DateTime? dateDeleted { get; set; }
    public byte[] rowVersion { get; set; } = null!;

    //Proprietés de navigation EF Core


    ///<summary>
    ///L'utilisateur est associé a cet entrepot
    ///</summary>
    public virtual User User { get; set; } = null!;

    ///<summary>
    ///Le produit est associé a cet entrepot
    /// </summary>

    public virtual Produit Produit { get; set; } = null!;


    ///<summary>
    ///constructeur orienté vers créeation manuelle. 
    ///</summary>
    ///<param name="nomEntrepot">Le nom de l'entrepot</param>
    ///<param name="UserId">L'identifiant de de l'utilisateur</param>
    ///<param name="ProduitId">L'identifiant du produit</param>
    
    public Entrepot(int Id , string NomEntrepot, string Adresse ) {
        this.id = Id;
        this.nomEntrepot = NomEntrepot;
        this.adresse = Adresse;
    }

    /// <summary>
    /// constructeur orienté création par Entity Framework.
    /// </summary>
    /// <param name="id">L'identifiant de l'entrepot</param>
    /// <param name="nomEntrepot">Le nom de l'entrepot</param>
    /// <param name="adresse">L'adresse de l'entrepot</param>
    /// <param name="dateCreated">La date de la creation de l'entrepot</param>
    /// <param name="dateModified">La date de la derniere modification de l'entrepot</param>
    /// <param name="dateDeleted">La date de la suppression de l'entrepot</param>
    /// /// <param name="rowVersion">Valeur anti-concurrence ge la base de données.</param>


    protected Entrepot(
        int Id,
        string NomEntrepot,
        string Adresse,
        DateTime dateCreated,
        DateTime? dateModified,
        DateTime? dateDeleted,
        byte[] rowVersion)
        : this(Id , NomEntrepot, Adresse) {

        this.id = Id;
        this.dateCreated = dateCreated;
        this.dateModified = dateModified;
        this.dateDeleted = dateDeleted;
        this.rowVersion = rowVersion;
    }

    ///<summary>
    /// override de la methode ToString pour afficher les information de l'entrepot
    /// </summary>
    /// <return> un string representant un entrepot</return>

    public override string ToString() {
        return $"#{this.id} - {this.nomEntrepot} - {this.adresse}";
    }



}
