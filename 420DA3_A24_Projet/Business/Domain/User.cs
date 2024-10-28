using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420DA3_A24_Projet.Business.Domain;

[Table("Users", Schema = "dbo")]
public class User {
    public const int UsernameMaxLength = 64;
    public const int PasswordHashMaxLength = 128;

    [Key]
    [Column(nameof(Id), TypeName = "int", Order = 0)]
    public int Id { get; set; }

    [Column(nameof(Username), Order = 1)]
    [MaxLength(UsernameMaxLength)]
    [Required]
    public string Username { get; set; }

    [Column(nameof(PasswordHash), Order = 2)]
    [MaxLength(PasswordHashMaxLength)]
    [Required]
    public string PasswordHash { get; set; }

    [Column(nameof(EmployeeWarehouseId), TypeName = "int", Order = 3)]
    public int? EmployeeWarehouseId { get; set; }

    [Column(nameof(DateCreated), TypeName = "datetime2(7)", Order = 4)]
    [Precision(7)]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }

    [Column(nameof(DateModified), TypeName = "datetime2(7)", Order = 5)]
    [Precision(7)]
    public DateTime? DateModified { get; set; }

    [Column(nameof(DateDeleted), TypeName = "datetime2(7)", Order = 6)]
    [Precision(7)]
    public DateTime? DateDeleted { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;



    // propriétés de navigation
    [ForeignKey(nameof(EmployeeWarehouseId))]
    [DeleteBehavior(DeleteBehavior.SetNull)]
    public Warehouse? EntrepotDeEmploye { get; set; }


    public User(
        string username,
        string passwordHash,
        int? employeeWarehouseId = null) {

        this.Username = username;
        this.PasswordHash = passwordHash;
        this.EmployeeWarehouseId = employeeWarehouseId;
    }

    protected User(int id,
        string username,
        string passwordHash,
        int? employeeWarehouseId,
        DateTime dateCreated,
        DateTime? dateModified,
        DateTime? dateDeleted,
        byte[] rowVersion)
        : this(username, passwordHash, employeeWarehouseId) {
        this.Id = id;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
        this.DateDeleted = dateDeleted;
        this.RowVersion = rowVersion;

    }

    // TODO: @PROF compléter propriétés de navigation
    // List<Role>
    // List<ShippingOrder> created
    // List<ShippingOrder> fulfilled

}
