using ExtraAdvancedMultiTier.Business.Abstractions.Daos;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    public class Warehouse
    {
        public const int WAREHOUSE_NAME_MAX_LENGTH = 128;
        public const int WAREHOUSE_NAME_MIN_LENGTH = 4;

        private int id;
        private string name;
        
        
        public int Id { 
        
        get { return id; }
        set {
                if (!ValidateId(value)) { 
                 throw new ArgumentOutOfRangeException("Id",$"Id must be greater or equal to 0.")
                }
                id = value; }
        }
        public string Name { 
            get {
                return this.name;
            }
            set {
                if (!ValidateWarehouseName(value)) {
                    throw new ArgumentOutOfRangeException("Name", $"Name length must be lower than or equal to {WAREHOUSE_NAME_MAX_LENGTH = 128;} characters.");
                }
                this.name = value;
            }
        }
        public int AddressId { get; set; }


        public DateTime DateCreated { get; set; };
        public DateTime? DateModified { get; set; };
        public DateTime? DateDeleted { get; set; };
        public byte[] RowVersion { get; set; } = null;


        public List<Client> clients { get; set; }=new List<Client>();
        public Adresse Address { get; set; };
        public virtual List<PurchaseOrder> RestockOrders { get; set; } = new List<PurchaseOrder>();
        public virtual List<User> WarehouseEmployees { get; set; } = new List<User>();
        public Warehouse(string name, int addressId) { 
            this.name = name;
            this.addressId = addressId;
        }
        protected Warehouse(int id,
            string name,
            int addressId,
            DateTime dateCreated,
            DateTime? dateDeleted,
            DateTime? dateModified,
            byte[] rowVersion)
            ) 
        :this(name, addressId){ 
            
         this.Id = id;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
        this.DateDeleted = dateDeleted;
        this.RowVersion = rowVersion;}
    public static bool ValidateId(int id) {
            return id >= 0;
        }
        public static bool ValidateWarehouseName(string warehousename) {
            return warehousename.Length<= WAREHOUSE_NAME_MAX_LENGTH; }

        

    }
}
