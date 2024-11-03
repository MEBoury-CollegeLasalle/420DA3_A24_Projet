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
        // TODO: @CINDY Attention: avec EF, il faut utiliser des propriétés publiques.
        // Là vous utilisez des champs privés. Faites attntion aussi à la casse (PascalCase pour propriétés publiques)
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
        // TODO: @CINDY Les propriétés de navigation doivent être publiques et marquées 'virtual' pour permettre le lazy loading.
        private Shipment? shipment;
        private User creatorEmployee;
        private User? fulfillerEmployee;
        private Adresse destinationAddress;
        // private List<ShippingOrderProduct> ShippingOrderProducts;
    }
}
