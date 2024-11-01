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
        private string warehouseName;
        private int addressId;
        private DateTime dateCreated;
        private DateTime? dateModified;
        private DateTime? dateDeleted;
        //private List<Client> clients;
        private Adresse address;
        //private List<PurchaseOrder> RestockOrders;
        private List<User> warehouseEmployees;
    }
}
