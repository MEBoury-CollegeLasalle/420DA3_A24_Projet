﻿using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    public class Shipment
    {


        public const int TrackingNumberMaxLength = 32;
        public const int TrackingNumberMinLength = 1;




        private int id ;
        private ShipmentStatusEnum status ;
        private ShippingProvidersEnum shippingService ;
        private int shippingOrderld ;
        private string trackingNumber = null!;
        private DateTime dateCreated;
        private DateTime? dateDelete;
        private DateTime? dateModified;
        private ShippingOrder shippingOrder;



        public int Id 
        {

            get
            {
                return this.id;
            }
            set
            {
                if (!ValidateId(value))
                {
                    throw new ArgumentException("Id", $"Id must be greater than or equal to 0.");
                }
                this.id = value;
            }
        }
        public ShipmentStatusEnum Status { get; set; }
        public ShippingProvidersEnum ShippingService { get; set; }
        public  int ShippingOrderld { get; set; }
        public string TrackingNumber {
            get
            {
                return this.trackingNumber;
            }
            set
            {
                if (!ValidateTrackingNumber(value)){
                    throw new ArgumentOutOfRangeException("TrackingNumber", $"TrackingNumber length must be greater than or equal to {TrackingNumberMinLength} characters and lower than or equal to {TrackingNumberMaxLength} characters.");
                }
                this.trackingNumber = value;

            }
        }
        public DateTime  DateCreated { get; set; }
        public DateTime? DateDelete { get; set; }
        public DateTime? DateModified { get; set; }
        public ShippingOrder   ShippingOrder { get; set; }
        public byte[] RowVersion { get; set; } = null!;


        public  Shipment(ShipmentStatusEnum status, ShippingProvidersEnum shippingService,  int shippingOrderld, string trackingNumber)
        {
            this.Status = status;
            this.ShippingService = shippingService;
            this.ShippingOrderld= shippingOrderld;
            this.TrackingNumber = trackingNumber;
        }

        protected Shipment(int id,
            ShipmentStatusEnum status,
            ShippingProvidersEnum shippingService,
            int shippingOrderld,
            string trackingNumber,
            DateTime dateCreated,
            DateTime? dateDelete,
            DateTime? dateModified,
            byte[] rowVersion):this(status,shippingService,shippingOrderld,trackingNumber)
        {
            this.Id = id;
            this.RowVersion = rowVersion;
            this.DateCreated = dateCreated;
            this.DateDelete = dateDelete;
            this.DateModified = dateModified;
        }

        public static bool ValidateId(int id)
        {
            return id >= 0;
        }
        public static bool ValidateTrackingNumber(string trackingNumber)
        {
            return trackingNumber.Length <= TrackingNumberMaxLength;
        }



    }
}
