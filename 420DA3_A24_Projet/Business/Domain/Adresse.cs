using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    public class Adresse
    {


        public const int AdresseMaxLength = 64;
        public const int CivicNumberMaxLength = 6;
        public const int StreeMaxLength = 128;
        public const int CityMaxLength = 64;
        public const int StateMaxLength = 64;
        public const int ContryMaxLength = 64;
        public const int PostalCodeMaxLength = 12;

        private int id;
        private string adressTypes;
        private string civicNumber;
        private string street;
        private string city;
        private string state;
        private string country;
        private string postalCode;



        //proprietes de donnees
       public int Id { get; set; }
       public  AddressTypesEnum AddressTypes { get; set; }
        public string Adress { get; set; }
        public string CivicNumber {  get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDelete { get; set; }
        public DateTime? DateModified { get; set; }
        //public Warehouse? OwnerWarehouse { get; set; }
        //public ShippingOrder? OwnerShipOrder {  get; set; } 

        public byte[] RowVersion { get; set; } = null!;


        public Adresse(AddressTypesEnum adressTypes,
            string adresse,
            string civicNumber,
            string street,
            string city,
            string state,
            string country,
            string postalCode)
        {
            this.AddressTypes= adressTypes;
            this.Adress = adresse;
            this.CivicNumber = civicNumber;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.PostalCode = postalCode;
        }



        protected Adresse(int id,
            AddressTypesEnum adressTypes, 
            string adresse,
            string civicNumber,
            string street,
            string city,
            string state,
            string country,
            string postalCode,
            DateTime dateCreated,
            DateTime? dateDelete,
            DateTime? dateModified,
            byte[] rowVersion):this (adressTypes, adresse, civicNumber, street, city, state, country,postalCode)
        {
            this.Id = id;
            this.DateCreated = dateCreated;
            this.DateDelete = dateDelete;
            this.DateModified = dateModified;
            this.RowVersion = rowVersion;
        }

        public static bool ValidateId(int id)
        {
            return id >= 0;
        }

        public static bool ValidateCivicNumber(string civicNumber)
        {
            return civicNumber.Length <= CivicNumberMaxLength;
        }

        public static bool ValidateStreet(string street)
        {
            return street.Length <=StreeMaxLength;
        }

        public static bool ValidateCity(string city)
        {
            return city.Length <= CityMaxLength;
        }

        public static bool ValidateState(string state)
        {
            return state.Length <= StateMaxLength;  
        }

        public static bool ValidateContry(string contry)
        {
            return contry.Length <= ContryMaxLength;
        }
        public static bool ValidatePostalCode(string postalCode)
        {
            return postalCode.Length <= PostalCodeMaxLength;
        }
    }
}
