using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain
{
    public class Supplier
    {
        public const int SUPPLIER_NAME_MAX_LENGTH = 128;
        public const int SUPPLIER_NAME_MIN_LENGTH = 1;
        public const int CONTACT_TELEPHONE_MAX_LENGTH = 15;
        public const int CONTACT_TELEPHONE_MIN_LENGTH = 10;
        public const int CONTACT_EMAIL_MAX_LENGTH = 128;
        public const int CONTACT_EMAIL_MIN_LENGTH = 10;
        public const int CONTACT_LAST_NAME_MAX_LENGTH = 32;
        public const int CONTACT_LAST_NAME_MIN_LENGTH = 4;
        public const int CONTACT_FIRST_NAME_MAX_LENGTH = 32;
        public const int CONTACT_FIRST_NAME_MIN_LENGTH = 4;

        private int id;
        private string supplierName;
        private string contactLastName;
        private string contactFirstName;
        private string contactEmail;
        private string contactTelephone;
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public byte[] RowVersion { get; set; } = null;
        private virtual List<Product> Products { get; set; } = new List<Product>();

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

        public string SupplierName
        {
            get { return this.supplierName; }
            set
            {
                if (!ValidateSupplierName(value))
                {
                    throw new ArgumentOutOfRangeException("SupplierName", $"SupplierName length must be greater than or equal to" +
                        $"{SUPPLIER_NAME_MAX_LENGTH} characters and lower than or equal to {SUPPLIER_NAME_MAX_LENGTH} characters.");
                }
                this.supplierName = value;
            }
        }

        public string ContactLastName
        {
            get { return this.contactLastName; }
            set
            {
                if (!ValidateContactLastName(value))
                {
                    throw new ArgumentOutOfRangeException("ContactLastName", $"ContactLastName length must be greater than or equal to" +
                        $"{CONTACT_LAST_NAME_MIN_LENGTH} characters and lower than or equal to {CONTACT_LAST_NAME_MAX_LENGTH} characters.");
                }
                this.contactLastName = value;
            }
        }

        public string ContactFirstName
        {
            get { return this.contactFirstName; }
            set
            {
                if (!ValidateContactFirstName(value))
                {
                    throw new ArgumentOutOfRangeException("ContactFirstName", $"ContactFirstName length must be greater than or equal to" +
                        $"{CONTACT_FIRST_NAME_MIN_LENGTH} characters and lower than or equal to {CONTACT_FIRST_NAME_MAX_LENGTH} characters.");
                }
                this.contactFirstName = value;
            }
        }

        public string ContactTelephone
        {
            get { return this.contactTelephone; }
            set
            {
                if (!ValidateContactTelephone(value))
                {
                    throw new ArgumentOutOfRangeException("ContactTelephone", $"ContactTelephone length must be greater than or equal to" +
                        $"{CONTACT_TELEPHONE_MIN_LENGTH} characters and lower than or equal to {CONTACT_TELEPHONE_MAX_LENGTH} characters.");
                }
                this.contactTelephone = value;
            }
        }

        public string ContactEmail
        {
            get { return this.contactEmail; }
            set
            {
                if (!ValidateContactEmail(value))
                {
                    throw new ArgumentOutOfRangeException("ContactEmail", $"ContactEmail length must be greater than or equal to" +
                        $"{CONTACT_EMAIL_MIN_LENGTH} characters and lower than or equal to {CONTACT_EMAIL_MAX_LENGTH} characters.");
                }
                this.contactEmail = value;
            }
        }



        public Supplier(string supplierName , string contactLastName , string contactFisrtName , string contactEmail , string contactTelephone)
        {
            this.SupplierName = supplierName;
            this.ContactLastName = contactLastName;
            this.ContactFirstName = contactFisrtName;
            this.ContactEmail = contactEmail;
            this.ContactTelephone = contactTelephone;
        }
        protected Supplier(int id , string supplierName, string contactLastName, string contactFisrtName, string contactEmail,
            string contactTelephone, DateTime dateCreated , DateTime? dateModified , DateTime? dateDeleted , byte[] rowVersion)
            :this(supplierName , contactLastName, contactFisrtName , contactEmail , contactTelephone)
        {
            this.Id = id;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
            this.DateDeleted = dateDeleted;
            this.RowVersion = rowVersion;
        }

        public static bool ValidateId(int id)
        {
            return id >= 0;
        }
        public static bool ValidateSupplierName(string supplierName)
        {
            return supplierName.Length >= SUPPLIER_NAME_MIN_LENGTH &&
                supplierName.Length <= SUPPLIER_NAME_MAX_LENGTH;
        }
        public static bool ValidateContactLastName(string contactLastName)
        {
            return contactLastName.Length >= CONTACT_LAST_NAME_MIN_LENGTH &&
                contactLastName.Length <= CONTACT_LAST_NAME_MAX_LENGTH;
        }
        public static bool ValidateContactFirstName(string contactFirstName)
        {
            return contactFirstName.Length >= CONTACT_FIRST_NAME_MIN_LENGTH &&
                contactFirstName.Length <= CONTACT_FIRST_NAME_MAX_LENGTH;
        }
        public static bool ValidateContactEmail(string contactEmail)
        {
            return contactEmail.Length >= CONTACT_EMAIL_MIN_LENGTH &&
                contactEmail.Length <= CONTACT_EMAIL_MAX_LENGTH;
        }
        public static bool ValidateContactTelephone(string contactTelephone)
        {
            return contactTelephone.Length >= CONTACT_TELEPHONE_MIN_LENGTH &&
                contactTelephone.Length <= CONTACT_TELEPHONE_MAX_LENGTH;
        }


    }
}
