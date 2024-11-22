using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.Business.Domain.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Utilities.Enums;

namespace _420DA3_A24_Projet.DataAccess.Contexts;
internal class WsysDbContext : DbContext {

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<Fournisseur> Fournisseurs { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<ShippingOrder> ShippingOrders { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<ShippingOrderProduct> ShippingOrderProducts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);

        _ = optionsBuilder
            .UseSqlServer("") // TODO: Add connection string
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);


        #region USER

        _ = modelBuilder.Entity<User>()
            .ToTable(nameof(this.Users))
            .HasKey(user => user.Id);

        _ = modelBuilder.Entity<User>()
            .HasIndex(user => user.Username)
            .IsUnique(true);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.Id)
            .HasColumnName(nameof(User.Id))
            .HasColumnOrder(0)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.Username)
            .HasColumnName(nameof(User.Username))
            .HasColumnOrder(1)
            .HasColumnType($"nvarchar({User.USERNAME_MAX_LENGTH})")
            .HasMaxLength(User.USERNAME_MAX_LENGTH)
            .IsRequired(true);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.PasswordHash)
            .HasColumnName(nameof(User.PasswordHash))
            .HasColumnOrder(2)
            .HasColumnType($"nvarchar({User.PASSWORDHASH_MAX_LENGTH})")
            .HasMaxLength(User.PASSWORDHASH_MAX_LENGTH)
            .IsRequired(true);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.EmployeeWarehouseId)
            .HasColumnName(nameof(User.EmployeeWarehouseId))
            .HasColumnOrder(3)
            .HasColumnType("int")
            .IsRequired(false);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.DateCreated)
            .HasColumnName(nameof(User.DateCreated))
            .HasColumnOrder(4)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired(true);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.DateModified)
            .HasColumnName(nameof(User.DateModified))
            .HasColumnOrder(5)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.DateDeleted)
            .HasColumnName(nameof(User.DateDeleted))
            .HasColumnOrder(6)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<User>()
            .Property(user => user.RowVersion)
            .HasColumnName(nameof(User.RowVersion))
            .HasColumnOrder(7)
            .IsRowVersion();


        // TODO @PROF Faire config User-Warehouse 

        #endregion

        #region ROLE

        _ = modelBuilder.Entity<Role>()
            .ToTable(nameof(this.Roles))
            .HasKey(role => role.Id);

        _ = modelBuilder.Entity<Role>()
            .HasIndex(role => role.Name)
            .IsUnique(true);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.Id)
            .HasColumnName(nameof(Role.Id))
            .HasColumnOrder(0)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.Name)
            .HasColumnName(nameof(Role.Name))
            .HasColumnOrder(1)
            .HasColumnType($"nvarchar({Role.NAME_MAX_LENGTH})")
            .HasMaxLength(Role.NAME_MAX_LENGTH)
            .IsRequired(true);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.Description)
            .HasColumnName(nameof(Role.Description))
            .HasColumnOrder(2)
            .HasColumnType($"nvarchar({Role.DESCRIPTION_MAX_LENGTH})")
            .HasMaxLength(Role.DESCRIPTION_MAX_LENGTH)
            .IsRequired(true);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.DateCreated)
            .HasColumnName(nameof(Role.DateCreated))
            .HasColumnOrder(3)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired(true);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.DateModified)
            .HasColumnName(nameof(Role.DateModified))
            .HasColumnOrder(4)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.DateDeleted)
            .HasColumnName(nameof(Role.DateDeleted))
            .HasColumnOrder(5)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<Role>()
            .Property(role => role.RowVersion)
            .HasColumnName(nameof(Role.RowVersion))
            .HasColumnOrder(6)
            .IsRowVersion();


        #endregion

        #region SHIPPING_ORDER

        EnumToStringConverter<ShippingOrderStatusEnum> ShippingOrderStatusConverter = new EnumToStringConverter<ShippingOrderStatusEnum>();

        _ = modelBuilder.Entity<ShippingOrder>()
            .ToTable(nameof(this.ShippingOrders))
            .HasKey(so => so.Id);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.Id)
            .HasColumnName(nameof(ShippingOrder.Id))
            .HasColumnOrder(0)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.Status)
            .HasColumnName(nameof(ShippingOrder.Status))
            .HasColumnOrder(1)
            .HasColumnType("nvarchar(24)")
            .HasConversion(ShippingOrderStatusConverter)
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.SourceClientId)
            .HasColumnName(nameof(ShippingOrder.SourceClientId))
            .HasColumnOrder(2)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.CreatorEmployeeId)
            .HasColumnName(nameof(ShippingOrder.CreatorEmployeeId))
            .HasColumnOrder(3)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.DestinationAddressId)
            .HasColumnName(nameof(ShippingOrder.DestinationAddressId))
            .HasColumnOrder(4)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.FulfillerEmployeeId)
            .HasColumnName(nameof(ShippingOrder.FulfillerEmployeeId))
            .HasColumnOrder(5)
            .HasColumnType("int")
            .IsRequired(false);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.ShippingDate)
            .HasColumnName(nameof(ShippingOrder.ShippingDate))
            .HasColumnOrder(6)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.DateCreated)
            .HasColumnName(nameof(ShippingOrder.DateCreated))
            .HasColumnOrder(7)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.DateModified)
            .HasColumnName(nameof(ShippingOrder.DateModified))
            .HasColumnOrder(8)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.DateDeleted)
            .HasColumnName(nameof(ShippingOrder.DateDeleted))
            .HasColumnOrder(9)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<ShippingOrder>()
            .Property(so => so.RowVersion)
            .HasColumnName(nameof(ShippingOrder.RowVersion))
            .HasColumnOrder(10)
            .IsRowVersion();

        // TODO: @PROF Faire config des relations de ShippingOrder

        #endregion

        #region PURCHASE_ORDER

        EnumToStringConverter<PurchaseOrderStatusEnum> PurchaseOrderStatusConverter = new EnumToStringConverter<PurchaseOrderStatusEnum>();

        _ = modelBuilder.Entity<PurchaseOrder>()
            .ToTable(nameof(this.PurchaseOrders))
            .HasKey(po => po.Id);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.Id)
            .HasColumnName(nameof(PurchaseOrder.Id))
            .HasColumnOrder(0)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.Status)
            .HasColumnName(nameof(PurchaseOrder.Status))
            .HasColumnOrder(1)
            .HasColumnType("nvarchar(24)")
            .HasConversion(PurchaseOrderStatusConverter)
            .IsRequired(true);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.Quantity)
            .HasColumnName(nameof(PurchaseOrder.Quantity))
            .HasColumnOrder(2)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.OrderedProductId)
            .HasColumnName(nameof(PurchaseOrder.OrderedProductId))
            .HasColumnOrder(3)
            .HasColumnType("int")
            .IsRequired(true);


        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.DestinationWarehouseId)
            .HasColumnName(nameof(PurchaseOrder.DestinationWarehouseId))
            .HasColumnOrder(4)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.CompletionDate)
            .HasColumnName(nameof(PurchaseOrder.CompletionDate))
            .HasColumnOrder(5)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.DateCreated)
            .HasColumnName(nameof(PurchaseOrder.DateCreated))
            .HasColumnOrder(6)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired(true);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.DateModified)
            .HasColumnName(nameof(PurchaseOrder.DateModified))
            .HasColumnOrder(7)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.DateDeleted)
            .HasColumnName(nameof(PurchaseOrder.DateDeleted))
            .HasColumnOrder(8)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<PurchaseOrder>()
            .Property(po => po.RowVersion)
            .HasColumnName(nameof(PurchaseOrder.RowVersion))
            .HasColumnOrder(9)
            .IsRowVersion();

        // TODO: @PROF Faire config des relations de PurchaseOrder

        #endregion

        #region PIVOT - SHIPPING_ORDER_PRODUCTS (PIVOT)

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .ToTable(nameof(this.ShippingOrderProducts))
            .HasKey(sop => new { sop.ShippingOderId, sop.ProductId });

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .Property(sop => sop.ShippingOderId)
            .HasColumnName(nameof(ShippingOrderProduct.ShippingOderId))
            .HasColumnOrder(0)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .Property(sop => sop.ProductId)
            .HasColumnName(nameof(ShippingOrderProduct.ProductId))
            .HasColumnOrder(1)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .Property(sop => sop.Quantity)
            .HasColumnName(nameof(ShippingOrderProduct.Quantity))
            .HasColumnOrder(2)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .Property(sop => sop.RowVersion)
            .HasColumnName(nameof(ShippingOrderProduct.RowVersion))
            .HasColumnOrder(3)
            .IsRowVersion();


        // Relations un-à-plusieurs pour ShippingOrder à ShippingOrderProduct
        // et pour Product à ShippingOrderProduct

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .HasOne(sop => sop.ShippingOrder)
            .WithMany(so => so.ShippingOrderProducts)
            .HasForeignKey(sop => sop.ShippingOderId)
            .HasPrincipalKey(so => so.Id);

        _ = modelBuilder.Entity<ShippingOrderProduct>()
            .HasOne(sop => sop.Product)
            .WithMany(product => product.OrgderProducts)
            .HasForeignKey(sop => sop.ProductId)
            .HasPrincipalKey(p => p.Id);

        #endregion

        // TODO: @TOUTE_EQUIPE Faites la configuration de vos entités et de leur relations ici
        #region FOURNISSEUR

_ = modelBuilder.Entity<Fournisseur>()
    .ToTable(nameof(this.Fournisseurs))
    .HasKey(fournisseur => fournisseur.Id);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.Id)
    .HasColumnName(nameof(Fournisseur.Id))
    .HasColumnOrder(0)
    .HasColumnType("int")
    .UseIdentityColumn(1, 1);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.Nom)
    .HasColumnName(nameof(Fournisseur.Nom))
    .HasColumnOrder(1)
    .HasColumnType("nvarchar(100)")
    .IsRequired(true);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.NomContact)
    .HasColumnName(nameof(Fournisseur.NomContact))
    .HasColumnOrder(2)
    .HasColumnType("nvarchar(50)")
    .IsRequired(true);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.PrenomContact)
    .HasColumnName(nameof(Fournisseur.PrenomContact))
    .HasColumnOrder(3)
    .HasColumnType("nvarchar(50)")
    .IsRequired(true);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.CourrielContact)
    .HasColumnName(nameof(Fournisseur.CourrielContact))
    .HasColumnOrder(4)
    .HasColumnType("nvarchar(100)")
    .IsRequired(true);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.TelephoneContact)
    .HasColumnName(nameof(Fournisseur.TelephoneContact))
    .HasColumnOrder(5)
    .HasColumnType("nvarchar(15)")
    .IsRequired(true);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.DateCreation)
    .HasColumnName(nameof(Fournisseur.DateCreation))
    .HasColumnOrder(6)
    .HasColumnType("datetime2")
    .HasPrecision(7)
    .HasDefaultValueSql("GETDATE()")
    .IsRequired(true);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.DateModification)
    .HasColumnName(nameof(Fournisseur.DateModification))
    .HasColumnOrder(7)
    .HasColumnType("datetime2")
    .HasPrecision(7)
    .IsRequired(false);

_ = modelBuilder.Entity<Fournisseur>()
    .Property(fournisseur => fournisseur.DateSuppression)
    .HasColumnName(nameof(Fournisseur.DateSuppression))
    .HasColumnOrder(8)
    .HasColumnType("datetime2")
    .HasPrecision(7)
    .IsRequired(false);

_ = modelBuilder.Entity<Fournisseur>()
    .HasMany(fournisseur => fournisseur.Produits)
    .WithOne(produit => produit.fournisseur)
    .HasForeignKey(produit => produit.fournisseur)
    .IsRequired(true)
    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region CLIENT

        _ = modelBuilder.Entity<Client>()
            .ToTable(nameof(this.Clients))
            .HasKey(client => client.Id);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.Id)
            .HasColumnName(nameof(Client.Id))
            .HasColumnOrder(0)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.NomCompagnie)
            .HasColumnName(nameof(Client.NomCompagnie))
            .HasColumnOrder(1)
            .HasColumnType("nvarchar(100)")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.NomContact)
            .HasColumnName(nameof(Client.NomContact))
            .HasColumnOrder(2)
            .HasColumnType("nvarchar(50)")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.PrenomContact)
            .HasColumnName(nameof(Client.PrenomContact))
            .HasColumnOrder(3)
            .HasColumnType("nvarchar(50)")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.CourrielContact)
            .HasColumnName(nameof(Client.CourrielContact))
            .HasColumnOrder(4)
            .HasColumnType("nvarchar(100)")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.TelephoneContact)
            .HasColumnName(nameof(Client.TelephoneContact))
            .HasColumnOrder(5)
            .HasColumnType("nvarchar(15)")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.DateCreation)
            .HasColumnName(nameof(Client.DateCreation))
            .HasColumnOrder(6)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.DateModification)
            .HasColumnName(nameof(Client.DateModification))
            .HasColumnOrder(7)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.DateSuppression)
            .HasColumnName(nameof(Client.DateSuppression))
            .HasColumnOrder(8)
            .HasColumnType("datetime2")
            .HasPrecision(7)
            .IsRequired(false);

        _ = modelBuilder.Entity<Client>()
            .Property(client => client.EntrepotId)
            .HasColumnName(nameof(Client.EntrepotId))
            .HasColumnOrder(9)
            .HasColumnType("int")
            .IsRequired(true);

        _ = modelBuilder.Entity<Client>()
            .HasOne(client => client.Entrepot)
            .WithMany(entrepot => entrepot.Client)
            .HasForeignKey(client => client.EntrepotId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = modelBuilder.Entity<Client>()
            .HasMany(client => client.Produits)
            .WithOne(produit => produit.Client)
            .HasForeignKey(produit => produit.ClientId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion


    }
}
