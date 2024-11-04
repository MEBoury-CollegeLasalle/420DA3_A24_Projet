using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Domain;
public class Customer {
    public const int CUSTOMER_NAME_MAX_LENGTH = 128;
    public const int CUSTOMER_NAME_MIN_LENGTH = 1;
    public const int CONTACT_TELEPHONE_MAX_LENGTH = 15;
    public const int CONTACT_TELEPHONE_MIN_LENGTH = 10;
    public const int CONTACT_EMAIL_MAX_LENGTH = 128;
    public const int CONTACT_EMAIL_MIN_LENGTH = 10;
    public const int CONTACT_LAST_NAME_MAX_LENGTH = 32;
    public const int CONTACT_LAST_NAME_MIN_LENGTH = 4;
    public const int CONTACT_FIRST_NAME_MAX_LENGTH = 32;
    public const int CONTACT_FIRST_NAME_MIN_LENGTH = 4;

    private int id;
    private string customerName = null!;
    private string contactLastName = null!;
    private string contactFirstName = null!;
    private string contactEmail = null!;
    private string contactTelephone = null!;

    #region Proprietes de donnees
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public byte[] RowVersion { get; set; } = null;

    public int Id {
        get { return this.id; }
        set {
            if (value < 0) {
                throw new ArgumentOutOfRangeException(nameof(Id), "Id must be greater than or equal to 0.");
            }
            this.id = value;
        }
    }

    public string CustomerName {
        get { return this.customerName; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < CUSTOMER_NAME_MIN_LENGTH || value.Length > CUSTOMER_NAME_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(CustomerName), $"CustomerName length must be between {CUSTOMER_NAME_MIN_LENGTH} and {CUSTOMER_NAME_MAX_LENGTH} characters.");
            }
            this.customerName = value;
        }
    }

    public string ContactLastName {
        get { return this.contactLastName; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < CONTACT_LAST_NAME_MIN_LENGTH || value.Length > CONTACT_LAST_NAME_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(ContactLastName), $"ContactLastName length must be between {CONTACT_LAST_NAME_MIN_LENGTH} and {CONTACT_LAST_NAME_MAX_LENGTH} characters.");
            }
            this.contactLastName = value;
        }
    }

    public string ContactFirstName {
        get { return this.contactFirstName; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < CONTACT_FIRST_NAME_MIN_LENGTH || value.Length > CONTACT_FIRST_NAME_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(ContactFirstName), $"ContactFirstName length must be between {CONTACT_FIRST_NAME_MIN_LENGTH} and {CONTACT_FIRST_NAME_MAX_LENGTH} characters.");
            }
            this.contactFirstName = value;
        }
    }

    public string ContactTelephone {
        get { return this.contactTelephone; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < CONTACT_TELEPHONE_MIN_LENGTH || value.Length > CONTACT_TELEPHONE_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(ContactTelephone), $"ContactTelephone length must be between {CONTACT_TELEPHONE_MIN_LENGTH} and {CONTACT_TELEPHONE_MAX_LENGTH} characters.");
            }
            this.contactTelephone = value;
        }
    }

    public string ContactEmail {
        get { return this.contactEmail; }
        set {
            if (string.IsNullOrEmpty(value) || value.Length < CONTACT_EMAIL_MIN_LENGTH || value.Length > CONTACT_EMAIL_MAX_LENGTH) {
                throw new ArgumentOutOfRangeException(nameof(ContactEmail), $"ContactEmail length must be between {CONTACT_EMAIL_MIN_LENGTH} and {CONTACT_EMAIL_MAX_LENGTH} characters.");
            }
            this.contactEmail = value;
        }
    }
    #endregion

    #region Propriétés de navigation
    public virtual List<Product> Products { get; set; } = new List<Product>();
    #endregion

    /// <summary>
    /// Constructeur pour création de client
    /// </summary>
    public Customer(string customerName, string contactLastName, string contactFirstName, string contactEmail, string contactTelephone) {
        this.CustomerName = customerName;
        this.ContactLastName = contactLastName;
        this.ContactFirstName = contactFirstName;
        this.ContactEmail = contactEmail;
        this.ContactTelephone = contactTelephone;
    }

    /// <summary>
    /// Constructeur pour Entity Framework
    /// </summary>
    protected Customer(int id, string customerName, string contactLastName, string contactFirstName, string contactEmail, string contactTelephone, DateTime dateCreated, DateTime? dateModified, DateTime? dateDeleted, byte[] rowVersion)
        : this(customerName, contactLastName, contactFirstName, contactEmail, contactTelephone) {
        this.Id = id;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
        this.DateDeleted = dateDeleted;
        this.RowVersion = rowVersion;
    }
}


