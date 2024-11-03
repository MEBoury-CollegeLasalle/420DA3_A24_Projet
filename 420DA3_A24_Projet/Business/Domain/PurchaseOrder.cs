using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    /// <summary>
    /// Classe représentant un odre de restockage de l'application.
    /// </summary>
    public class PurchaseOrder
    {
        // FIXME: @MAROUANE - Attention: avec EF Core, il faut utiliser des propriétés publiques.
        // Là vous utilisez des champs privés. Faites attention aussi à la casse (PascalCase pour propriétés publiques)

        private int id;
        private Product orderedProduct;
        private Warehouse warehouse;
        public int Quantity;
        public PurchaseOrderStatusEnum Status;



        #region Proprietes de donnees
        public int Id {
            get { return this.id; }
            set {
                if (!ValidateId(value)) {
                    throw new ArgumentOutOfRangeException("Id", "Id must be greater than or equal to 0.");
                }
                this.id = value;
            }
        }
        public int? ProductId { get; set; }
        public int? WarehouseId { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        #endregion

        #region Propriétés de navigation
        public virtual Product OrderedProduct { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        #endregion



        /// <summary>
        /// Constructeur orienté création ordre de restockage
        /// </summary>
        /// <param name="status">Le statut de l'ordre de restockage</param>
        /// <param name="quantity">La quantite de l'ordre</param>
        /// <param name="productId">L'id de prod </param>
        /// <param name="warehouseId">L'id d'entrepot </param>
        public PurchaseOrder(PurchaseOrderStatusEnum status , int productId, int warehouseId  , int quantity)
        {
            this.Status = status;
            this.ProductId = productId;
            this.WarehouseId = warehouseId;
            this.Quantity = quantity;
        }
        // FIXME: @MAROUANE - Seules les propriétés de données doivent avoir des paramètres dans le constructeur.
        // pas les propriétés de navigation (donc pas celles de type Product et Warehouse ici).


        /// <summary>
        /// Constructeur orienté entity framework
        /// </summary>
        /// <param name="id">L'identifiant de l'ordre de restockage.</param>
        /// <param name="quantity">La quantite de l'ordre de restockage</param>
        /// <param name="productId">L'id de prod </param>
        /// <param name="warehouseId">L'id d'entrepot </param>
        /// <param name="completionDate">La date de comlpetion de l'ordre de restockage dans la base de données.</param>
        /// <param name="dateCreated">La date de création de l'ordre de restockage dans la base de données.</param>
        /// <param name="dateModified">La date de dernière modification de l'ordre de restockage dans la base de données.</param>
        /// <param name="dateDeleted">La date de suppression de l'ordre de restockage dans la base de données.</param>
        /// <param name="rowVersion">Le numéro de version anti-concurrence de l'entrée dans la base de donnée.</param>
        protected PurchaseOrder(int id ,
            PurchaseOrderStatusEnum status,
            int productId,
            int warehouseId,
            int quantity ,
            byte[] rowVersion,
            DateTime? completionDate,
            DateTime dateCreated,
            DateTime? dateModified,
            DateTime? dateDeleted)
            : this(status, productId, warehouseId, quantity)
        {
            this.Id = id;         
            this.CompletionDate = completionDate;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateDeleted = dateDeleted;
            this.RowVersion = rowVersion;
        }


        #region Méthodes

        /// <summary>
        /// Méthode de validation d'ID
        /// </summary>
        /// <param name="id">Le numéro d'ID à valider</param>
        /// <returns><see langword="true"/> si valide, <see langword="false"/> sinon.</returns>
        public static bool ValidateId(int id)
        {
            return id >= 0;
        }

        /// <summary>
        /// Retourne un booléen indiquant si l'utilisateur est un employé d'entrepôt.
        /// </summary>
        /// <returns><see langword="true"/> si l'utilisateur possède le rôle d'employé d'entrepôt, <see langword="false"/> sinon.</returns>
        public void Complete()
        {
            if(Status == PurchaseOrderStatusEnum.New)
            {
                Status = PurchaseOrderStatusEnum.Completed;
                CompletionDate = DateTime.Now;
                DateModified = DateTime.Now;

            }
        }
        #endregion
    }
}
