using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    public class ShippingOrder
    {
        private int id;
        private ShippingOrderStatusEnum status;
        private int sourceClientId;
        private int creatorEmployeeId;
        private int destinationAddressId;
        private int? fulfillerEmployeeId;
        private DateTime? shippingDate;
        private DateTime dateCreated;
        private DateTime? dateModified;
        private DateTime? dateDeleted;
        // private Client sourceClient;
        private Shipment? shipment;
        private User creatorEmployee;
        private User? fulfillerEmployee;
        private Adresse destinationAddress;
        // private List<ShippingOrderProduct> ShippingOrderProducts;
    }
}
