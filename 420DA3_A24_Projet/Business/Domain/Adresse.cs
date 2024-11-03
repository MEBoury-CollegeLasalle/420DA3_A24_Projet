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
        public const int CivicNumberMinLength = 1;
        public const int StreeMaxLength = 128;
        public const int StreeMinLength = 2;
        public const int CityMaxLength = 64;
        public const int CityMinLength = 3; 
        public const int StateMaxLength = 64;
        public const int StateMinLength = 4;
        public const int ContryMaxLength = 64;
        public const int ContryMinLength = 4;
        public const int PostalCodeMaxLength = 12;
        public const int PostalCodeMinLength = 6;

        private int id;
        //private AddressTypesEnum addressType;
        //private string adress;
        private string civicNumber;
        private string street;
        private string city;
        private string state;
        private string country;
        private string postalCode;



        //proprietes de donnees
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
       public  AddressTypesEnum AdressTypes 
       { get; set; }
        public string Adress 
        { get; set; }
        public string CivicNumber 
        {
            get {  return this.civicNumber; } 
            set 
            {
                if (!ValidateCivicNumber(value))
                {
                    throw new ArgumentOutOfRangeException("CivicNumber", $"CivicNumber length must be greater than or equal to {CivicNumberMinLength} characters and lower than or equal to {CivicNumberMaxLength} characters.");
                }
                this.civicNumber = value;
            }
                              
        }
        public string Street 
        {
            get
            {
                return this.street;
            }
            set
            {
                if (ValidateStreet(value))
                {
                    throw new ArgumentOutOfRangeException("Street", $"Street length must be greater than or equal to {StreeMinLength} characters and lower than or equal to {StreeMaxLength} characters.");
                }
                this.street = value;
            }
        }
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                if (ValidateCity(value))
                {
                    throw new ArgumentOutOfRangeException("City", $"City length must be greater than or equal to {CityMinLength} characters and lower than or equal to {CityMinLength} characters.");
                }
                this.city = value;
            }
        }
        public string State 
        {
            get
            {
                return this.state;
            }
            set
            {
                if (!ValidateState(value))
                {
                    throw new ArgumentOutOfRangeException("State", $"State length must be greater than or equal to {StateMinLength} characters and lower than or equal to {StateMaxLength} characters.");
                }
                this.state = value;
            }
        }
        public string Country 
        {
            get
            {
                return this.country;
            }
            set
            {
                if (!ValidateContry(value))
                {
                    throw new ArgumentOutOfRangeException("Country", $"Country length must be greater than or equal to {ContryMinLength} characters and lower than or equal to {ContryMaxLength} characters.");

                }
            } 
        }
        public string PostalCode 
        {
            get { return this.postalCode; }
            set
            {
                if (!ValidatePostalCode(value))
                {
                    throw new ArgumentOutOfRangeException("PostalCode", $"PostalCode length must be greater than or equal to {PostalCodeMinLength} characters and lower than or equal to {PostalCodeMaxLength} characters.");

                }
            }
        }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDelete { get; set; }
        public DateTime? DateModified { get; set; }
        public Warehouse? OwnerWarehouse { get; set; }
        public ShippingOrder? OwnerShipOrder {  get; set; } 

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
            this.AdressTypes= adressTypes;
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
