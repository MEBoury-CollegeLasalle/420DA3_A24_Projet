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
        public int Id { get; set; }
        public ShippingOrderStatusEnum Status { get; set; }
        public int SourceClientId { get; set; }
        public int CreatorEmployeeId { get; set; }
        public int DestinationAddressId { get; set; }
        public int? FulfillerEmployeeId { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public byte[] RowVersion { get; set; } = null;

        public virtual Shipment? Shipment { get; set; }
        public  virtual User CreatorEmployee { get; set; }
        public virtual User? FulfillerEmployee { get; set; }
        public virtual Adresse DestinationAddress { get; set; }

        // Au Prof: Je ne sais pas a quel niveau se trouve l'erreur, J'ai essaye dee la reparer sanas succes.
        public virtual List<ShippingOrderProduct> ShippingOrderProducts { get; set; } = new List<ShippingOrderProduct>();
    }
}
