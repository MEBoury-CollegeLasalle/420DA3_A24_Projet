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
        public int Id { get; set; };
        public ShippingOrderStatusEnum Status { get; set; };
        public int SourceClientId { get; set; };
        public int CreatorEmployeeId { get; set; };
        public int DestinationAddressId { get; set; };
        public int? FulfillerEmployeeId { get; set; };
        public DateTime? ShippingDate { get; set; };
        public DateTime DateCreated { get; set; };
        public DateTime? DateModified { get; set; };
        public DateTime? DateDeleted { get; set; };
        // private Client sourceClient;
        // TODO: @CINDY Les propriétés de navigation doivent être publiques et marquées 'virtual' pour permettre le lazy loading.
        public Shipment? sSipment { get; set; };
        public User CreatorEmployee { get; set; };
        public User? FulfillerEmployee { get; set; };
        public Adresse DestinationAddress { get; set; };
        public virtual List<ShippingOrderProduct> ShippingOrderProducts { get; set; }=new List<ShippingOrderProduct>();
    }
}
