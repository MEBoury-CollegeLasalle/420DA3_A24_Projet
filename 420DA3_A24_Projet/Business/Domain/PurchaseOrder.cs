using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    public class PurchaseOrder
    {
        // FIXME: @MAROUANE - Attention: avec EF Core, il faut utiliser des propriétés publiques.
        // Là vous utilisez des champs privés. Faites attention aussi à la casse (PascalCase pour propriétés publiques)
        private int id;
        private PurchaseOrderStatusEnum status;
        private int productId;
        private int warehouseId;
        private int quantity;
        public DateTime? CompletionDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        private Product orderedProduct;
        private Warehouse warehouse;
        public byte[] RowVersion { get; set; } = null;

        public PurchaseOrder(PurchaseOrderStatusEnum status , int productId, int warehouseId  , int quantity , Product orderedProduct , Warehouse warehouse)
        {
            this.status = status;
            this.productId = productId;
            this.warehouseId = warehouseId;
            this.quantity = quantity;
            this.orderedProduct = orderedProduct;
            this.warehouse = warehouse;
        }

        // FIXME: @MAROUANE - Seules les propriétés de données doivent avoir des paramètres dans le constructeur.
        // pas les propriétés de navigation (donc pas celles de type Product et Warehouse ici).
        protected PurchaseOrder(int id , PurchaseOrderStatusEnum status, int productId, int warehouseId,
            int quantity, Product orderedProduct, Warehouse warehouse , byte[] rowVersion, DateTime? completionDate,
            DateTime dateCreated, DateTime? dateModified, DateTime? dateDeleted)
            : this(status, productId, warehouseId, quantity, orderedProduct, warehouse)
        {
            this.id = id;
            this.status = status;
            this.productId = productId;
            this.warehouseId = warehouseId;
            this.quantity = quantity;
            this.orderedProduct = orderedProduct;
            this.warehouse = warehouse;
            this.CompletionDate = completionDate;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateDeleted = dateDeleted;
            this.RowVersion = rowVersion;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (!ValidateId(value))
                {
                    throw new ArgumentOutOfRangeException("Id", "Id must be greater than or equal to 0.");
                }
                this.id = value;
            }
        }
        public int ProductId
        {
            get { return this.productId; }
            set
            {
                if (!ValidateId(value))
                {
                    throw new ArgumentOutOfRangeException("Id", "Id must be greater than or equal to 0.");
                }
                this.productId = value;
            }
        }
        public int WarehouseId 
        {
            get { return this.warehouseId; }
            set
            {
                if (!ValidateId(value))
                {
                    throw new ArgumentOutOfRangeException("Id", "Id must be greater than or equal to 0.");
                }
                this.warehouseId = value;
            }
        }










        public static bool ValidateId(int id)
        {
            return id >= 0;
        }
        public void Complete()
        {
            if(status == PurchaseOrderStatusEnum.New)
            {
                status = PurchaseOrderStatusEnum.Completed;
                CompletionDate = DateTime.Now;
                DateModified = DateTime.Now;

            }
        }
    }
}
